
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

namespace WPF_App.ViewModel
{

    public class FinancialProductViewModel : BaseNotifyPropertyChanged
    {
        private ICRUD _crud;       //Tipo de CRUD: Com banco de dados SQLite ou sem
        public ICRUD crud
        {
            get
            {
                return _crud;
            }
            set
            {
                _crud = value;
                //OnPropertyChanged("crud");
            }
        }
        //public FinancialProductViewModel()
        //{
        //    FinancialProducts = new ObservableCollection<IFinancialProduct>();
        //}
        public FinancialProductViewModel(ICRUD crud)
        {
            FinancialProducts = new ObservableCollection<IFinancialProduct>();
            this.crud = crud;
            UpdateTheListView();        //atualizo a tela
            //preencheListaComExemplos();
        }

        private void UpdateTheListView()
        {
            crud.UpdateTheListView(FinancialProducts);
        }
        public void preencheListaComExemplos()
        {
            crud.preencheListaComExemplos(FinancialProducts);
        }

        public void AddShareToList()
        {
            crud.AddShareToList(FinancialProducts);

        }
        public void AddFundToList()
        {
            crud.AddFundToList(FinancialProducts);
        }

        public void DeleteFinancialProduct(IFinancialProduct financialProduct)
        {
            crud.DeleteFinancialProduct(FinancialProducts, financialProduct);
        }

        public void UpdateFinancialProduct(IFinancialProduct recebido)
        {
            crud.UpdateFinancialProduct(FinancialProducts, recebido);
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
