using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Model;

namespace WPF_App.ViewModel
{
    public class SQLiteCRUD : ICRUD
    {
        public SQLiteCRUD()
        {

        }
        public void UpdateTheListView(ObservableCollection<IFinancialProduct> listProducts)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Share>();
                connection.CreateTable<Fund>();
                listProducts = ReadDatabase(listProducts);
            }
        }
        public void preencheListaComExemplos(ObservableCollection<IFinancialProduct> listProducts)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                //connection.DeleteAll<Share>();
                //connection.DeleteAll<Fund>();
                //connection.Insert(new Share("Petrobras PETR3", "PETR3"));
                //connection.Insert(new Fund("Fundos Imobiliários BTLG11", "Imobiliário", "Lmóvel (Híbrido)"));
                //connection.Insert(new Fund("Vinci Shopping Centers", "Imobiliário", "Shoppings"));
                //connection.Insert(new Share("Tesla, Inc.", "TSLA"));
                //connection.Insert(new Fund("Brb Liquidez FI Renda FIxa", "Renda Fixa", "Bancário"));
                //connection.Insert(new Fund("BB MULTIMERCADO LP FX BALANCED INVESTIMENTO NO EXTERIOR PRIVATE", "Multimercado", "Investimento no Exterior"));
                connection.CreateTable<Share>();
                connection.CreateTable<Fund>();
                listProducts = ReadDatabase(listProducts);
            }
        }
        private ObservableCollection<IFinancialProduct> ReadDatabase(ObservableCollection<IFinancialProduct> listProducts)
        {

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                //conn.CreateTable<Share>();
                //FinancialProducts = new ObservableCollection<IFinancialProduct>();
                listProducts.Clear();
                List<IFinancialProduct> listAtivos = new List<IFinancialProduct>(conn.Table<Share>().ToList());
                foreach (var ativos in listAtivos)
                {
                    listProducts.Add(ativos);
                }
                //conn.CreateTable<Fund>();
                listAtivos = new List<IFinancialProduct>(conn.Table<Fund>().ToList());
                foreach (var ativos in listAtivos)
                {
                    listProducts.Add(ativos);
                }
                //this.Shares = new List<Share>(this.Shares);

            }
            return listProducts;
        }
        public void AddShareToList(ObservableCollection<IFinancialProduct> listProducts)
        {
            //listProducts.Add(new Share()); 
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.Insert(new Share());
                listProducts.Add(new Share());
                //pegar id
                //listProducts = ReadDatabase(listProducts);
            }

        }
        public void AddFundToList(ObservableCollection<IFinancialProduct> listProducts)
        {
            //listProducts.Add(new Fund());
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.Insert(new Fund());
                listProducts.Add(new Fund());
                //pegar id
                //listProducts = ReadDatabase(listProducts);
            }
        }
        public void DeleteFinancialProduct(ObservableCollection<IFinancialProduct> listProducts,IFinancialProduct financialProduct)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.Delete(financialProduct);
                listProducts = ReadDatabase(listProducts);
            }
        }
        public void UpdateFinancialProduct(ObservableCollection<IFinancialProduct> listProducts,IFinancialProduct financialProduct)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                //connection.Delete(financialProduct);
                //listProducts = ReadDatabase(listProducts);
            }
            //if (cliente.Id != null)
            //{
            //    connection.CommandText = "UPDATE Clientes SET Nome=@Nome, Email=@Email WHERE Id=@Id";
            //    connection.Parameters.AddWithValue("@Id", cliente.Id);
            //    connection.Parameters.AddWithValue("@Nome", cliente.Nome);
            //    connection.Parameters.AddWithValue("@Email", cliente.Email);
            //    connection.ExecuteNonQuery();

            //}
        }
    }
}
