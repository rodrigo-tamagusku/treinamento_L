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
    public class MainWindowViewModel: ObservableObject
    {
        public ICommand CreateCommand { get; private set; }
        public ICommand ReadCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public FinancialProductViewModel ProdutoFinVM { get; set; }
      
        public ObservableCollection<FinancialProduct> listProduct   //busca lista na ViewModel de produto criada
        {
            get
            {
                return ProdutoFinVM.FinancialProducts;      //FinancialProducts é o public que retorna a Lista de Prod.Financ.
            }
        }

        public List<string> testeString { get; set; }

        public MainWindowViewModel()
        {
            testeString = new List<string>();
            ProdutoFinVM = new FinancialProductViewModel();
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
            ProdutoFinVM.AddFinancialProductToList("NEW", "NEW");
            testeString.Add("testeCampo");
            testeString = new List<string>(testeString);
            OnPropertyChanged("testeString");
            //MessageBox.Show("Cadastro Efetuado");
            //CreateWindow createWindow = new CreateWindow();
            //createWindow.DataContext = window.DataContext;       
            //createWindow.Show();
            //if (!listProduct.Any())
        }
        private void ReadLine(object itemTabela)
        {
            MessageBox.Show("Nome: " + ((FinancialProduct)itemTabela).name + "\n" +
                            "Código: " + ((FinancialProduct)itemTabela).code,"Visualizar");
        }
        private void UpdateLine(object itemTabela)
        {
            ProdutoFinVM.UpdateFinancialProduct((FinancialProduct)itemTabela);
        }
        private void DeleteLine(object itemTabela)
        {
            ProdutoFinVM.DeleteFinancialProduct((FinancialProduct)itemTabela);
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
