
//namespace WPF_App.ViewModel
//{
//    using System;
//    using System.Diagnostics;
//    using System.Collections.Generic;
//    using System.Windows.Input;
//    using WPF_App.Model;
//    using System.Collections.Specialized;
//    using System.Collections.ObjectModel;
//    using System.Linq;
//    using System.ComponentModel;
//    using WPF_App.Command;
//    using WPF_App.View;

//    public class FundViewModel : ObservableObject
//    {
//        public FundViewModel()
//        {
//            listFund = new ObservableCollection<Fund>();
//            listFund.Add(new Fund("Iridium Recebíveis Imobiliário", "IRDM11"));
//            listFund.Add(new Fund("Hectare Crédito Estruturado", "HCTR11"));
//            listFund.Add(new Fund("Banestes Recebíveis Imobiliários", "BCRI11"));
//            //UpdateCommand = new StockUpdateCommand(this);
//        }

//        public void CreateFund(string nameCreate, string codeCreate)
//        {
//            listFund.Add(new Fund(nameCreate, codeCreate));

//            //AtualizaTelaPorModificarList();
//            /*
//            if (CollectionChanged != null)
//            {
//                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.CreateStock));
//            }
//            */
//        }

//        public void DeleteStock(Fund fund)
//        {
//            listFund.Remove(fund);
//        }

//public void AtualizaTelaPorModificarList()
//{
//    this.Stock = new List<Stock>(this.Stock);
//    OnPropertyChanged("Stock");
//}

//        public void DeleteStockFromCode(string code)nt
//        {
//            //listStock.Remove(listStock.Find(x => x.code == code));
//            //AtualizaTelaPorModificarList();
//            listFund.Remove(listFund.Single(x => x.code == code));

//            //if(!listStock.Any())
//        }
//        public void UpdateFund(Fund recebido)
//        {
//            //UpdateWindow updateWindow = new UpdateWindow(recebido);
//            //updateWindow.Show();
//            //listStock.Find(x => x.code == code);
//            //AtualizaTelaPorModificarList();
//            //listStock.Remove(listStock.Single(x => x.code == code));

//            //if(!listStock.Any())
//        }

//        public Fund GetFundFromCode(string code)
//        {
//            //return listStock.Find(x => x.code == code);
//            return listFund.Single(x => x.code == code);

//        }
//        private string _stringTeste;

//        public string stringTeste
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_stringTeste))
//                    return "TesteDefault";
//                return _stringTeste;
//            }
//            set
//            {
//                _stringTeste = value;
//                OnPropertyChanged("stringTeste");
//            }
//        }

//        public bool CanUpdate
//        {
//            get;
//            set;
//        }

//        private ObservableCollection<Fund> listFund;

//        public ObservableCollection<Fund> Fund
//        {
//            get
//            {
//                return listFund;
//            }
//            private set
//            {
//                listFund = value;
//                OnPropertyChanged("Fund");
//            }
//        }

//        public ICommand UpdateCommand
//        {
//            get;
//            set;
//        }

//        public void SaveChanges()
//        {
//            //Debug.Assert(false, String.Format("{0} was updated", Stock.name));
//        }
//        /*
//        #region INotifyCollectionChanged
//        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
//        {
//            if (this.CollectionChanged != null)
//            {
//                this.CollectionChanged(this, args);
//            }
//        }
//        public event NotifyCollectionChangedEventHandler CollectionChanged;
//        #endregion INotifyCollectionChanged
//        /*
//        /*
//        #region INotifyCollectionChanged Members  
//        public event NotifyCollectionChangedEventHandler CollectionChanged;
//        #endregion
//        */

//    }
//}
