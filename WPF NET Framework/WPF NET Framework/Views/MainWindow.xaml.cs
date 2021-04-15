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
