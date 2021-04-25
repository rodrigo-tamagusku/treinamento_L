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
using WPF_App.Model;
using WPF_App.UpdateWindow.ViewModel;

namespace WPF_App.View
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class UpdateFundWindow : Window
    {
        //public UpdateWindow()
        //{
        //    InitializeComponent();
        //}
        public UpdateFundWindow(IFinancialProduct financialProduct)
        {
            InitializeComponent();
            DataContext = financialProduct;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
