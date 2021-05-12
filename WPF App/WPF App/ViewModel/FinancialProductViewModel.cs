
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            FinancialProducts = new List<IFinancialProduct>();
            this.crud = crud;
            UpdateTheListView();        //atualizo a tela
            //preencheListaComExemplos();
        }
        public bool NotificaTelaSePrecisa(ICollection<IFinancialProduct> FinancialProducts)
        {
            if (FinancialProducts is INotifyCollectionChanged)  //Caso ObservableCollection e alguns outros
            {
                                                                //MessageBox.Show("Não precisa atualizar");
                return false;
            }
            else
            {                                                   //Caso List, Collection e outros
                                                                //MessageBox.Show("Notifica tela");
                this.FinancialProducts = new List<IFinancialProduct>(FinancialProducts); //Tem um tipo melhor que List?
                OnPropertyChanged("FinancialProducts");
            }
            return true;
        }

        private void UpdateTheListView()
        {
            FinancialProducts = crud.UpdateTheListView(FinancialProducts);
        }
        public void preencheListaComExemplos()
        {
            crud.preencheListaComExemplos(FinancialProducts);
        }

        public bool AddShareToList()
        {
            bool adicionou;
            adicionou = crud.AddShareToList(FinancialProducts);
            NotificaTelaSePrecisa(FinancialProducts);
            return adicionou;
        }
        public Fund AddFundToList()
        {
            Fund fundoRetorno = null;
            fundoRetorno = crud.CreateFund();
            if (fundoRetorno != null)
            {
                FinancialProducts.Add(fundoRetorno);
                NotificaTelaSePrecisa(FinancialProducts);
            }
            return fundoRetorno;
        }

        public bool DeleteFinancialProduct(IFinancialProduct financialProduct)
        {
            bool removeu;
            removeu = crud.DeleteFinancialProduct(FinancialProducts, financialProduct);
            NotificaTelaSePrecisa(FinancialProducts);
            return removeu;
        }

        public void UpdateFinancialProduct(IFinancialProduct recebido)
        {
            crud.UpdateFinancialProduct(FinancialProducts, recebido);
            NotificaTelaSePrecisa(FinancialProducts);
        }

        private ICollection<IFinancialProduct> listProducts;

        public ICollection<IFinancialProduct> FinancialProducts
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
        
    }
}
