
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Input;
using WPF_App.Model;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using WPF_App.Command;
using WPF_App.View;
using System.Windows;
using SQLite;
namespace WPF_App.ViewModel
{

    public class FinancialProductViewModel : BaseNotifyPropertyChanged
    {
        //public List<IFinancialProduct> Produtos { get; set; }        
        public CRUD crud;
        public FinancialProductViewModel()
        {
            listProducts = new ObservableCollection<IFinancialProduct>();
            //crud = new SimpleCRUD();
            crud = new SQLiteCRUD();
            crud.preencheListaComExemplos(FinancialProducts);
            //UpdateCommand = new StockUpdateCommand(this);
            //CriaTabelaSQLite();
        }

        private void CriaTabelaSQLite()
        {
            //Produtos = new List<IFinancialProduct>();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.DeleteAll<Share>();
                connection.DeleteAll<Fund>();
                connection.Insert(new Share("Petrobras PETR3", "PETR3"));
                connection.Insert(new Fund("Fundos Imobiliários BTLG11", "Imobiliário", "Lmóvel (Híbrido)"));
                connection.Insert(new Fund("Vinci Shopping Centers", "Imobiliário", "Shoppings"));
                connection.Insert(new Share("Tesla, Inc.", "TSLA"));
                connection.Insert(new Fund("Brb Liquidez FI Renda FIxa", "Renda Fixa", "Bancário"));
                connection.Insert(new Fund("BB MULTIMERCADO LP FX BALANCED INVESTIMENTO NO EXTERIOR PRIVATE", "Multimercado", "Investimento no Exterior"));
                connection.CreateTable<Share>();
                connection.CreateTable<Fund>();
                ReadDatabase();
            }
        }
        void ReadDatabase()
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
                //OnPropertyChanged("Produtos");
            }
            //if (Produtos != null)
            //{
            //    //SharesListView.ItemsSource = Shares;
            //}
        }

        public void preencheListaComExemplos()
        {
            listProducts.Add(new Share("Petrobras PETR3", "PETR3"));
            listProducts.Add(new Fund("Fundos Imobiliários BTLG11","Imobiliário", "Lmóvel (Híbrido)"));
            listProducts.Add(new Fund("Vinci Shopping Centers", "Imobiliário","Shoppings"));
            listProducts.Add(new Share("Tesla, Inc.", "TSLA"));
            listProducts.Add(new Fund("Brb Liquidez FI Renda FIxa", "Renda Fixa", "Bancário"));
            listProducts.Add(new Fund("BB MULTIMERCADO LP FX BALANCED INVESTIMENTO NO EXTERIOR PRIVATE", "Multimercado", "Investimento no Exterior"));
        }

        //public IFinancialProduct CreateFinancialProduct(string nameCreate,string codeCreate)
        //{
        //    return new Share(nameCreate, codeCreate);
        //}

        //public void AddFinancialProductToList(string nameCreate, string codeCreate)
        //{
        //    listProducts.Add(CreateFinancialProduct(nameCreate, codeCreate));

        //    //AtualizaTelaPorModificarList();
        //    /*
        //    if (CollectionChanged != null)
        //    {
        //        CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.CreateStock));
        //    }
        //    */
        public void AddShareToList()
        {
            //listProducts.Add(new Share()); 
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.Insert(new Share());
                ReadDatabase();
            }

        }
        public void AddFundToList()
        {
            //listProducts.Add(new Fund());
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.Insert(new Fund());
                ReadDatabase();
            }
        }

        public void DeleteFinancialProduct(IFinancialProduct financialProduct)
        {
            listProducts.Remove(financialProduct);
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.Delete(financialProduct);
                ReadDatabase();
            }
        }

        public void AtualizaTelaPorModificarList()
        {
            //this.Stock = new List<Stock>(this.Stock);
            //OnPropertyChanged("FinancialProducts");
            //this.Produtos = new List<IFinancialProduct>(this.Produtos);
            OnPropertyChanged("Produtos");
        }

        //public void DeleteFinancialProductFromCode(string code)
        //{
        //    //listStock.Remove(listStock.Find(x => x.code == code));
        //    //AtualizaTelaPorModificarList();
        //    listProducts.Remove(listProducts.Single(x => x.code == code));

        //    //if(!listStock.Any())
        //}
        public void UpdateFinancialProduct(IFinancialProduct recebido)
        {
            recebido.AtualizaEmNovaJanela();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                //connection.Delete(financialProduct);
                ReadDatabase();
            }
            //if (recebido.categoria == "Ação")
            //{
            //    UpdateShareWindow updateWindow = new UpdateShareWindow(recebido);
            //    updateWindow.Show();
            //}
            //else if (recebido.categoria == "Fundo")
            //{
            //    UpdateFundWindow updateWindow = new UpdateFundWindow(recebido);
            //    updateWindow.Show();
            //}
            //MainWindow updateWindow = new UpdateWindow(recebido);
            //updateWindow.Show();
            //listStock.Find(x => x.code == code);
            //AtualizaTelaPorModificarList();
            //listStock.Remove(listStock.Single(x => x.code == code));

            //if(!listStock.Any())
        }

        //public IFinancialProduct GetFinancialProductFromCode(string code)
        //{
        //    //return listStock.Find(x => x.code == code);
        //    return listProducts.Single(x => x.code == code);

        //}

        //public bool CanUpdate
        //{
        //    get;
        //    set;
        //}

        private ObservableCollection<IFinancialProduct> listProducts;

        public ObservableCollection<IFinancialProduct> FinancialProducts
        {
            get
            {
                return listProducts;
            }
            private set
            {
                listProducts = value;
                //OnPropertyChanged("FinancialProducts");       //Apenas para list<>
            }
        }

        //public ICommand UpdateCommand
        //{
        //    get;
        //    set;
        //}

        //public void SaveChanges()
        //{
        //    //Debug.Assert(false, String.Format("{0} was updated", Stock.name));
        //}
        ///*
        //#region INotifyCollectionChanged
        //private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        //{
        //    if (this.CollectionChanged != null)
        //    {
        //        this.CollectionChanged(this, args);
        //    }
        //}
        //public event NotifyCollectionChangedEventHandler CollectionChanged;
        //#endregion INotifyCollectionChanged
        /*
        /*
        #region INotifyCollectionChanged Members  
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
        */
        
    }
}
