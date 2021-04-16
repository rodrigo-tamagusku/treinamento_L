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
using WPF_App.Stock.ViewModel;

namespace WPF_App.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StockViewModel();
        }

        private void StockRadioChecked(object sender, RoutedEventArgs e)
        {

        }
        private void FundRadio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Cadastrar(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Visualizar(object sender, RoutedEventArgs e)
        {
            if (FundRadio.IsChecked == true)
            {
                ReadWindow readWindow = new ReadWindow();
                readWindow.DataContext= this.DataContext;        //necessário para usar mesma DataContext
                readWindow.Show();
                //MessageBox.Show("Entre com o nome do Fundo de Investimento.", "Cadastrar");
            }
            else if (StockRadio.IsChecked == true)
            {
                ReadWindow readWindow = new ReadWindow();
                readWindow.DataContext = this.DataContext;      //necessário para usar mesma DataContext
                readWindow.Show();
                //MessageBox.Show("Entre com o nome do Fundo de Investimento.", "Cadastrar");
            }
        }

        private void Button_Click_Deletar(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Atualizar(object sender, RoutedEventArgs e)
        {

        }

    }
}
