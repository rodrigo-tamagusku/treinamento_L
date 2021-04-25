using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_App.ViewModel;
using WPF_App.Command;
using WPF_App.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WPF_App.MainWindow.ViewModel
{
    public class MainWindowViewModel: BaseNotifyPropertyChanged
    {
        public ICommand CreateShareCommand { get; private set; }
        public ICommand CreateFundCommand { get; private set; }
        public ICommand ReadCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public FinancialProductViewModel ProdutoFinVM { get; set; }
      
        //public ObservableCollection<FinancialProduct> listProduct   //busca lista na ViewModel de produto criada
        //{
        //    get
        //    {
        //        return ProdutoFinVM.FinancialProducts;      //FinancialProducts é o public que retorna a Lista de Prod.Financ.
        //    }
        //}

        //public List<string> testeString { get; set; }

        public MainWindowViewModel()
        {
            ProdutoFinVM = new FinancialProductViewModel();
            this.InstanciaComandos();
        }

        private void InstanciaComandos()
        {
            CreateShareCommand = new RelayCommand(CreateShareLine);
            CreateFundCommand = new RelayCommand(CreateFundLine);
            ReadCommand = new RelayCommand(ReadLine, HasItemSelected);
            UpdateCommand = new RelayCommand(UpdateLine, HasItemSelected);
            DeleteCommand = new RelayCommand(DeleteLine, HasItemSelected);
        }

        private void CreateShareLine(object itemListView)
        {
            ProdutoFinVM.AddShareToList();
            //testeString.Add("testeCampo");
            //testeString = new List<string>(testeString);
            //OnPropertyChanged("testeString");
            //MessageBox.Show("Cadastro Efetuado");
            //CreateWindow createWindow = new CreateWindow();
            //createWindow.DataContext = window.DataContext;       
            //createWindow.Show();
            //if (!listProduct.Any())
        }
        private void CreateFundLine(object itemListView)
        {
            ProdutoFinVM.AddFundToList();
            //testeString.Add("testeCampo");
            //testeString = new List<string>(testeString);
            //OnPropertyChanged("testeString");
            //MessageBox.Show("Cadastro Efetuado");
            //CreateWindow createWindow = new CreateWindow();
            //createWindow.DataContext = window.DataContext;       
            //createWindow.Show();
            //if (!listProduct.Any())
        }
        private void ReadLine(object itemListView)
        {
            MessageBox.Show("Nome: " + ((IFinancialProduct)itemListView).name,"Visualizar");
        }
        private void UpdateLine(object itemListView)
        {
            ProdutoFinVM.UpdateFinancialProduct((IFinancialProduct)itemListView);
        }
        private void DeleteLine(object itemListView)
        {
            ProdutoFinVM.DeleteFinancialProduct((IFinancialProduct)itemListView);
        }
        public bool HasItemSelected(object itemListView)
        {
            if (itemListView == null)
            {
                return false;
            //}
            //else if (!listProduct.Any()) //há itens na lista
            //{
            //    return false;
            }
            else
                return true;
        }
    }
}
