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

namespace WPF_NET_Framework
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cadastro efetivado!");
            this.Close();
        }
    }
}
