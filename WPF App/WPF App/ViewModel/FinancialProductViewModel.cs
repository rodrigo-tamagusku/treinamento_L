
namespace WPF_App.ViewModel
{
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

    public class FinancialProductViewModel : ObservableObject
    {
        public FinancialProductViewModel()
        {
            listProducts = new ObservableCollection<FinancialProduct>();
            listProducts.Add(new FinancialProduct("Petrobras PETR3", "PETR3"));
            listProducts.Add(new FinancialProduct("Petrobras PETR4", "PETR4"));
            listProducts.Add(new FinancialProduct("Rodrigo", "RODR"));
            //UpdateCommand = new StockUpdateCommand(this);
        }

        public FinancialProduct CreateFinancialProduct(string nameCreate,string codeCreate)
        {
            return new FinancialProduct(nameCreate, codeCreate);
        }

        public void AddFinancialProductToList(string nameCreate, string codeCreate)
        {
            listProducts.Add(CreateFinancialProduct(nameCreate, codeCreate));
            
            //AtualizaTelaPorModificarList();
            /*
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.CreateStock));
            }
            */
        }

        public void DeleteFinancialProduct(FinancialProduct financialProduct)
        {
            listProducts.Remove(financialProduct);
        }

        public void AtualizaTelaPorModificarList()
        {
            //this.Stock = new List<Stock>(this.Stock);
            OnPropertyChanged("FinancialProducts");
        }

        public void DeleteFinancialProductFromCode(string code)
        {
            //listStock.Remove(listStock.Find(x => x.code == code));
            //AtualizaTelaPorModificarList();
            listProducts.Remove(listProducts.Single(x => x.code == code));

            //if(!listStock.Any())
        }
        public void UpdateFinancialProduct(IFinancialProduct recebido)
        {
            UpdateWindow updateWindow = new UpdateWindow(recebido);
            updateWindow.Show();
            //listStock.Find(x => x.code == code);
            //AtualizaTelaPorModificarList();
            //listStock.Remove(listStock.Single(x => x.code == code));

            //if(!listStock.Any())
        }

        public FinancialProduct GetFinancialProductFromCode(string code)
        {
            //return listStock.Find(x => x.code == code);
            return listProducts.Single(x => x.code == code);

        }

        public bool CanUpdate
        {
            get;
            set;
        }

        private ObservableCollection<FinancialProduct> listProducts;

        public ObservableCollection<FinancialProduct> FinancialProducts
        {
            get
            {
                return listProducts;
            }
            private set
            {
                listProducts = value;
                OnPropertyChanged("FinancialProducts");
            }
        }

        public ICommand UpdateCommand
        {
            get;
            set;
        }

        public void SaveChanges()
        {
            //Debug.Assert(false, String.Format("{0} was updated", Stock.name));
        }
        /*
        #region INotifyCollectionChanged
        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion INotifyCollectionChanged
        /*
        /*
        #region INotifyCollectionChanged Members  
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
        */
        
    }
}
