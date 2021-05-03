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
        public ICommand SimpleDataCommand { get; private set; }
        public ICommand SQLiteDataCommand { get; private set; }
        public FinancialProductViewModel ProdutoFinVM { get; set; }
        public ICRUD sqlitecrud { get; set; }
        public ICRUD simplecrud { get; set; }

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
            //ProdutoFinVM = new FinancialProductViewModel();
            sqlitecrud = new SQLiteCRUD();
            simplecrud = new SimpleCRUD();
            ProdutoFinVM = new FinancialProductViewModel(sqlitecrud);
            //ProdutoFinVM = new FinancialProductViewModel(simplecrud);
            this.InstanciaComandos();
            //try
            //{
            //    UpdateCommand.Execute(null);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Erro: " + e);
            //}
        }
        public MainWindowViewModel(ICRUD icrud)
        {
            ProdutoFinVM = new FinancialProductViewModel(icrud);
            this.InstanciaComandos();
        }

        private void InstanciaComandos()
        {
            CreateShareCommand = new RelayCommand(CreateShareLine,HasDatabase);
                                    //RelayCommand(Execute,CanExecute);
            CreateFundCommand = new RelayCommand(CreateFundLine,HasDatabase);
            ReadCommand = new RelayCommand(ReadLine, HasItemSelected);
            UpdateCommand = new RelayCommand(UpdateLine, HasItemSelected);
            DeleteCommand = new RelayCommand(DeleteLine, HasItemSelected);
            //SimpleDataCommand = new RelayCommand(changeCRUDToSimple, IsNotSimple);
            //SQLiteDataCommand = new RelayCommand(changeCRUDToSQLite, IsNotSQLite);
        }

        private void CreateShareLine(object itemListView)
        {
            ProdutoFinVM.AddShareToList();
        }
        private void CreateFundLine(object itemListView)
        {
            var retorno = ProdutoFinVM.AddFundToList();
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
        //private void changeCRUDToSimple(object itemListView) //Ação do relay command "Dados Runtime"
        //{
        //    ProdutoFinVM = new FinancialProductViewModel(simplecrud);
        //    OnPropertyChanged("ProdutoFinVM");
        //    //this.InstanciaComandos();
        //    ProdutoFinVM.UpdateTheListView();
        //}
        //private void changeCRUDToSQLite(object itemListView) //Ação do relay command "Dados SQLite"
        //{
        //    ProdutoFinVM = new FinancialProductViewModel(sqlitecrud);
        //    OnPropertyChanged("ProdutoFinVM");
        //    //this.InstanciaComandos();
        //    ProdutoFinVM.UpdateTheListView();
        //}
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

        public bool HasDatabase(object itemListView)
        {
            if (ProdutoFinVM is null)
                return false;
            else if (ProdutoFinVM.crud is SimpleCRUD)
                return true;
            else if (ProdutoFinVM.crud is SQLiteCRUD)
                return true;
            else
                return false;
        }
        public bool IsNotSimple(object itemListView)
        {
            if (ProdutoFinVM is null)
                return true; 
            else if (ProdutoFinVM.crud is SimpleCRUD)
                return false;
            else
                return true;
        }
        public bool IsNotSQLite(object itemListView)
        {
            if (ProdutoFinVM is null)
                return true; 
            else if (ProdutoFinVM.crud is SQLiteCRUD)
                return false;
            else
                return true;
        }
    }
}
