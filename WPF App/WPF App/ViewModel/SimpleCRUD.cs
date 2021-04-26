using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Model;

namespace WPF_App.ViewModel
{
    public class SimpleCRUD : ICRUD
    {
        public SimpleCRUD()
        {

        }
        public void UpdateTheListView(ObservableCollection<IFinancialProduct> listProducts)
        {
            listProducts.Clear();
        }

        public void preencheListaComExemplos(ObservableCollection<IFinancialProduct> listProducts)
        {
            listProducts.Clear();
            listProducts.Add(new Share("Petrobras PETR3", "PETR3"));
            listProducts.Add(new Fund("Fundos Imobiliários BTLG11", "Imobiliário", "Lmóvel (Híbrido)"));
            listProducts.Add(new Fund("Vinci Shopping Centers", "Imobiliário", "Shoppings"));
            listProducts.Add(new Share("Tesla, Inc.", "TSLA"));
            listProducts.Add(new Fund("Brb Liquidez FI Renda FIxa", "Renda Fixa", "Bancário"));
            listProducts.Add(new Fund("BB MULTIMERCADO LP FX BALANCED INVESTIMENTO NO EXTERIOR PRIVATE", "Multimercado", "Investimento no Exterior"));
        }

        public void AddShareToList(ObservableCollection<IFinancialProduct> listProducts)
        {
            listProducts.Add(new Share());
        }
        public void AddFundToList(ObservableCollection<IFinancialProduct> listProducts)
        {
            listProducts.Add(new Fund());
        }

        public void DeleteFinancialProduct(ObservableCollection<IFinancialProduct> listProducts,IFinancialProduct financialProduct)
        {
            listProducts.Remove(financialProduct);
        }

        //public void AtualizaTelaPorModificarList()
        //{
        //    //this.Stock = new List<Stock>(this.Stock);
        //    //OnPropertyChanged("FinancialProducts");
        //    this.Produtos = new List<IFinancialProduct>(this.Produtos);
        //    OnPropertyChanged("Shares");
        //}

        public void UpdateFinancialProduct(ObservableCollection<IFinancialProduct> listProducts,IFinancialProduct recebido)
        {
            recebido.AtualizaEmNovaJanela();
            //if (recebido.categoria == "Ação")
            //{
            //    UpdateShareWindow updateWindow = new UpdateShareWindow(recebido);
            //    updateWindow.Show();
            //}
            //else if (recebido.categoria == "Fundo")
            //{
            //    UpdateFundWindow updateWindow = new UpdateFundWindow(recebido);
            //    updateWindow.Show();
            //}
            //MainWindow updateWindow = new UpdateWindow(recebido);
            //updateWindow.Show();
            //listStock.Find(x => x.code == code);
            //AtualizaTelaPorModificarList();
            //listStock.Remove(listStock.Single(x => x.code == code));

            //if(!listStock.Any())
        }
    }
}
