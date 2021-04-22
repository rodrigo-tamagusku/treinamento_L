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
    public class MainWindowViewModel
    {
        public ICommand CreateCommand { get; private set; }
        public ICommand ReadCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        private FinancialProductViewModel _Dados;
        public FinancialProductViewModel Dados
        {
            get
            {
                return _Dados;
            }
            private set
            {
                _Dados = value;
            }
        }
        public ObservableCollection<FinancialProduct> listProduct   //busca lista na ViewModel de produto criada
        {
            get
            {
                return Dados.FinancialProducts;
            }
        }

        public MainWindowViewModel()
        {
            Dados = new FinancialProductViewModel();
            this.InstanciaComandos();
        }

        private void InstanciaComandos()
        {
            CreateCommand = new RelayCommand(CreateLine);
            ReadCommand = new RelayCommand(ReadLine, HasItemSelected);
            UpdateCommand = new RelayCommand(UpdateLine, HasItemSelected);
            DeleteCommand = new RelayCommand(DeleteLine, HasItemSelected);
        }

        private void CreateLine(object itemTabela)
        {
            Dados.AddFinancialProductToList("NEW", "NEW");
            //MessageBox.Show("Cadastro Efetuado");
            //CreateWindow createWindow = new CreateWindow();
            //createWindow.DataContext = window.DataContext;       
            //createWindow.Show();
            //if (!listProduct.Any())
        }
        private void ReadLine(object itemTabela)
        {
            MessageBox.Show("Nome: " + ((FinancialProduct)itemTabela).name + "\n" +"Código: " + ((FinancialProduct)itemTabela).code,"Visualizar");
        }
        private void UpdateLine(object itemTabela)
        {
            Dados.UpdateFinancialProduct((FinancialProduct)itemTabela);
        }
        private void DeleteLine(object itemTabela)
        {
            Dados.DeleteFinancialProduct((FinancialProduct)itemTabela);
        }
        public bool HasItemSelected(object itemTabela)
        {
            if (itemTabela == null)
            {
                return false;
            }
            else if (!listProduct.Any()) //há itens na lista
            {
                return false;
            }
            else
                return true;
        }
    }
}
