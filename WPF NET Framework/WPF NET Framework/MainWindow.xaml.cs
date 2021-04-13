using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_NET_Framework
{
    public class Stock
    {
        public string name
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
    }
    class Fund
    {
        string name
        {
            get;
            set;
        }
        string code
        {
            get;
            set;
        }
    }
    public class StockRepository
    {
        private List<Stock> _stocks;
        public StockRepository() {   //construtor
            _stocks = new List<Stock>
            {
            new Stock() { name = "Petrobras PETR3", code = "PETR3" },
            new Stock() { name = "Petrobras PETR4", code = "PETR4" }
            };
        }
        public List<Stock> GetStocks()
        {
            return _stocks;   
        }
        public void UpdateStocks(Stock SelectedStock)
        {
            Stock stockToChange = _stocks.Single(s => s.code == SelectedStock.code);
            stockToChange = SelectedStock;
        }
    }
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Cadastrar(object sender, RoutedEventArgs e)
        {
            if (FundRadio.IsChecked == true)
            {
                CreateWindow createWindow = new CreateWindow();
                createWindow.Show();
                //MessageBox.Show("Entre com o nome do Fundo de Investimento.", "Cadastrar");
            }
            else if (StockRadio.IsChecked == true)
            {
                MessageBox.Show("Entre com o nome da Ação.", "Cadastrar");
            }
        }

        private void StockRadioChecked(object sender, RoutedEventArgs e)
        {

        }

        private void FundRadio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FundRadio.IsChecked == true)
            {
                ReadWindow readWindow = new ReadWindow();
                readWindow.Show();
                //MessageBox.Show("Entre com o nome do Fundo de Investimento.", "Cadastrar");
            }
            else if (StockRadio.IsChecked == true)
            {
                MessageBox.Show("Entre com o nome da Ação.", "Cadastrar");
            }
        }
    }
}
