
namespace WPF_App.Stock.ViewModel
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Windows.Input;
    using WPF_App.Commands;
    using WPF_App.Stock.Model;
    using System.Collections.Specialized;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ComponentModel;
    using WPF_App.Command;

    public class StockViewModel : INotifyPropertyChanged
    {
        public StockViewModel()
        {
            listStock = new List<Stock>();
            listStock.Add(new Stock("Petrobras PETR3", "PETR3"));
            listStock.Add(new Stock("Petrobras PETR4", "PETR4"));
            listStock.Add(new Stock("Rodrigo", "RODR"));
            //UpdateCommand = new StockUpdateCommand(this);
        }

        public void CreateStock(string nameCreate, string codeCreate)
        {
            listStock.Add(new Stock(nameCreate, codeCreate));
            
            AtualizaTelaPorModificarList();
            /*
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.CreateStock));
            }
            */
        }

        public void AtualizaTelaPorModificarList()
        {
            this.Stock = new List<Stock>(this.Stock);
            OnPropertyChanged("Stock");
        }

        public void DeleteStockFromCode(string code)
        {
            listStock.Remove(listStock.Find(x => x.code == code));
            AtualizaTelaPorModificarList();
            //listStock.Remove(listStock.Single(x => x.code == code));

            //if(!listStock.Any())
        }

        public Stock GetStockFromCode(string code)
        {
            return listStock.Find(x => x.code == code);
            //return listStock.Single(x => x.code == code);

        }
        private string _stringTeste;

        public string stringTeste
        {
            get
            {
                if (string.IsNullOrEmpty(_stringTeste))
                    return "TesteDefault";
                return _stringTeste;
            }
            set
            {
                _stringTeste = value;
                OnPropertyChanged("stringTeste");
            }
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
            private set
            {
                listStock = value;
                //OnPropertyChanged("Stock");
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
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion
    }
}
