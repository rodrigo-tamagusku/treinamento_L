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
using System.Windows.Shapes;
using WPF_App.Stock.ViewModel;

namespace WPF_App.View
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        private StockViewModel Dados;
        public CreateWindow(StockViewModel Dados)
        {
            InitializeComponent();
            this.Dados=Dados;

        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Detalhes do Fundo: ", caixaName.Text);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            Dados.CreateStock(caixaName.Text, caixaCode.Text);
            MessageBox.Show(caixaCode.Text + "adicionado", "Cadastro");
            //this.DataContext.CreateStock(caixaName.Text, caixaCode.Text);
        }
    }
}
