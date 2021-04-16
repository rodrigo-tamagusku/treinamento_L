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

namespace WPF_App.View
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class ReadWindow : Window
    {
        public ReadWindow()
        {
            InitializeComponent();
        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Detalhes do Fundo: ", Detalhes.Text);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
