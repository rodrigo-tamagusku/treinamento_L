using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Model;
using System.Windows;
using System.Data.SQLite;

namespace WPF_App.ViewModel
{
    //Nota: Não é garantido criar tabela ou arquivo. Admito que eles estão criados
    public class SQLiteCRUD : ICRUD
    {
        private string ConnectionString; 
        private System.Data.SQLite.SQLiteConnection connection;
        private System.Data.SQLite.SQLiteCommand cmd;
        private System.Data.SQLite.SQLiteDataReader allRead;
        public SQLiteCRUD()
        {
            ConnectionString = @"Data Source=C:\Users\digo_\Documents\ProdutosFin.db;Version=3"; 
            connection = new System.Data.SQLite.SQLiteConnection(ConnectionString);
        }
        public ICollection<IFinancialProduct> UpdateTheListView(ICollection<IFinancialProduct> listProducts)
        {
            try
            {
                connection.Open();
                cmd = new System.Data.SQLite.SQLiteCommand(connection);
                //cmd.Prepare();
                //connection.CreateTable<Stock>();
                //connection.CreateTable<Fund>();
                cmd.CommandText = "SELECT * FROM Stock";
                try
                {
                    allRead = cmd.ExecuteReader();
                    while (allRead.Read())
                    {
                        listProducts.Add(new Stock(allRead.GetInt32(0), allRead.GetString(1), allRead.GetString(2), allRead.GetString(3)));
                        //listProducts.Add(new Stock((int)allRead["Id"], (string)allRead["categoria"], (string)allRead["name"], (string)allRead["code"])); //Isso não converte.
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao montar a lista de ações: " + e.Message);
                    return null;
                }
                cmd = new System.Data.SQLite.SQLiteCommand(connection);
                //cmd.Prepare();
                //connection.CreateTable<Stock>();
                //connection.CreateTable<Fund>();
                cmd.CommandText = "SELECT * FROM Fund";
                try
                {
                    allRead = cmd.ExecuteReader();
                    while (allRead.Read())
                    {
                        listProducts.Add(new Fund(allRead.GetInt32(0), allRead.GetString(1), allRead.GetString(2), allRead.GetString(3), allRead.GetString(4)));
                        //listProducts.Add(new Fund(
                        //(int)allRead["Id"],
                        //(string)allRead["categoria"],
                        //(string)allRead["name"],
                        //(string)allRead["code"])); //Isso não converte.
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao montar a lista de Fundos: " + e.Message);
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao acessar Banco de Dados: " + e);
                return null;
            }
            finally
            {
                connection.Close();
            }
            return listProducts;
        }
        public void preencheListaComExemplos(ICollection<IFinancialProduct> listProducts)
        {
            //using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(databasePath))
            //{
            //    //connection.DeleteAll<Stock>();
            //    //connection.DeleteAll<Fund>();
            //    connection.Insert(new Stock("Petrobras PETR3", "PETR3"));
            //    connection.Insert(new Fund("Fundos Imobiliários BTLG11", "Imobiliário", "Lmóvel (Híbrido)"));
            //    connection.Insert(new Fund("Vinci Shopping Centers", "Imobiliário", "Shoppings"));
            //    connection.Insert(new Stock("Tesla, Inc.", "TSLA"));
            //    connection.Insert(new Fund("Brb Liquidez FI Renda FIxa", "Renda Fixa", "Bancário"));
            //    connection.Insert(new Fund("BB MULTIMERCADO LP FX BALANCED INVESTIMENTO NO EXTERIOR PRIVATE", "Multimercado", "Investimento no Exterior"));
            //    connection.CreateTable<Stock>();
            //    connection.CreateTable<Fund>();
            //    listProducts = ReadDatabase(listProducts);
            //}
        }
        public bool AddShareToList(ICollection<IFinancialProduct> listProducts)
        {
            //listProducts.Add(new Share()); 
            //using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            //{
            //    connection.Insert(new Stock());
            //    //IdInserido = connection.last_insert_rowid; //Fui enganado, não tem
            //    listProducts.Add(new Stock());
            //    //pegar id
            //    //listProducts = ReadDatabase(listProducts);
            //}
            try
            {
                connection.Open();
                int IdInserido;
                cmd = new System.Data.SQLite.SQLiteCommand(connection);
                Stock stock = new Stock();
                cmd.CommandText = "INSERT INTO Stock (categoria,name,code) VALUES (@categoria,@name,@code)";
                //cmd.Prepare();
                //cmd.Parameters.AddWithValue("@Id", stock.Id);
                cmd.Parameters.AddWithValue("@categoria", stock.categoria);
                cmd.Parameters.AddWithValue("@name", stock.name);
                cmd.Parameters.AddWithValue("@code", stock.code);
                try
                {
                    cmd.ExecuteNonQuery();
                    IdInserido = (int)connection.LastInsertRowId;
                    listProducts.Add(new Stock(IdInserido));
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro em executar comando: " + e.Message);
                    return false;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro em conexão do banco de dados: " + e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Fund AddFundToList(ICollection<IFinancialProduct> listProducts)
        {
            try
            {
                connection.Open();
                int IdInserido;
                cmd = new System.Data.SQLite.SQLiteCommand(connection);
                {
                    Fund fund = new Fund();
                    cmd.CommandText = "INSERT INTO Fund (categoria,name,tipo,setor) VALUES (@categoria,@name,@tipo,@setor)";
                    //cmd.Prepare();
                    //cmd.Parameters.AddWithValue("@Id", fund.Id);
                    cmd.Parameters.AddWithValue("@categoria", fund.categoria);
                    cmd.Parameters.AddWithValue("@name", fund.name);
                    cmd.Parameters.AddWithValue("@tipo", fund.tipo);
                    cmd.Parameters.AddWithValue("@setor", fund.setor);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        IdInserido = (int)connection.LastInsertRowId;
                        Fund fundoCriado = new Fund(IdInserido);
                        listProducts.Add(fundoCriado);
                        return fundoCriado;

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro ao inserir fundo: " + e);
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro em conexão do banco de dados: " + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteFinancialProduct(ICollection<IFinancialProduct> listProducts,IFinancialProduct financialProduct)
        {
            try
            {
                connection.Open();
                cmd = new System.Data.SQLite.SQLiteCommand(connection);
                {
                    if (financialProduct.categoria == "Stock")
                    {
                        cmd.CommandText = "DELETE FROM Stock WHERE Id=@Id";
                    }
                    else
                    {
                        if (financialProduct.categoria == "Fund")
                        {
                            cmd.CommandText = "DELETE FROM Fund WHERE Id=@Id";
                        }
                        else
                        {
                            MessageBox.Show("Produto de categoria desconhecida");
                            return false;
                        }
                    }
                    //cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Id", financialProduct.Id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        listProducts.Remove(financialProduct);
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro ao remover fundo: " + e);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro em conexão do banco de dados: " + e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            //using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(databasePath))
            //{
            //    connection.Delete(financialProduct);
            //    listProducts = ReadDatabase(listProducts);
            //}
        }
        public void UpdateFinancialProduct(ICollection<IFinancialProduct> listProducts,IFinancialProduct financialProduct)
        {
            try{
                if (financialProduct.categoria == "Stock")
                {
                    financialProduct.AtualizaEmNovaJanela();            //Não deveria atualizar ainda
                    Stock stock = (Stock)financialProduct;
                    connection.Open();
                    cmd = new System.Data.SQLite.SQLiteCommand(connection);
                    {
                        if (stock.Id != 0)
                        {
                            cmd.CommandText = "UPDATE Stock SET name=@name, code=@code WHERE Id=@Id";
                            //cmd.Prepare();
                            cmd.Parameters.AddWithValue("@Id", stock.Id);
                            //cmd.Parameters.AddWithValue("@categoria", stock.categoria);
                            cmd.Parameters.AddWithValue("@name", stock.name);
                            cmd.Parameters.AddWithValue("@code", stock.code);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Erro ao atualizar ação: " + e);
                            }
                        }
                    }
                }
                else
                {
                    if (financialProduct.categoria == "Fund")
                    {
                        financialProduct.AtualizaEmNovaJanela();        //Não deveria atualizar ainda
                        Fund fund = (Fund)financialProduct;
                        connection.Open();
                        cmd = new System.Data.SQLite.SQLiteCommand(connection);
                        {
                            if (fund.Id > 0)
                            {
                                cmd.CommandText = "UPDATE Fund SET name=@name, tipo=@tipo, setor=@setor WHERE Id=@Id";
                                //cmd.Prepare();
                                cmd.Parameters.AddWithValue("@Id", fund.Id);
                                cmd.Parameters.AddWithValue("@name", fund.name);
                                cmd.Parameters.AddWithValue("@tipo", fund.tipo);
                                cmd.Parameters.AddWithValue("@setor", fund.setor);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Erro ao atualizar fundo: " + e);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Produto de categoria desconhecida: ");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao estabelecer conexão com banco de dados: " + e);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
