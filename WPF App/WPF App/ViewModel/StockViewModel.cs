
namespace WPF_App.Stock.ViewModel
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Windows.Input;
    using WPF_App.Commands;
    using WPF_App.Stock.Model;
    using System.Collections.Specialized;

    public class StockViewModel : INotifyCollectionChanged
    {
        public StockViewModel()
        {
            listStock = new List<Stock>();
            listStock.Add(new Stock("Petrobras PETR3", "PETR3"));
            listStock.Add(new Stock("Petrobras PETR4", "PETR4"));
            listStock.Add(new Stock("Rodrigo", "RODR"));
            UpdateCommand = new StockUpdateCommand(this);
        }

        public void CreateStock(string nameCreate, string codeCreate)
        {
            listStock.Add(new Stock(nameCreate, codeCreate));
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
                //this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.CreateStock));
            }
        }
        public void DeleteStockFromCode(string code)
        {
            listStock.Remove(listStock.Find(x => x.code == code));
        }

        public Stock GetStockFromCode(string code)
        {
            return listStock.Find(x => x.code == code);
        }

        public bool CanUpdate
        {
            get;
            set;
        }

        private List<Stock> listStock;

        public List<Stock> Stock
        {
            get
            {
                return listStock;
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
        */
        #region INotifyCollectionChanged Members  
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
    }
}
