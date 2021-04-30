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
        public void UpdateTheListView(ICollection<IFinancialProduct> listProducts)
        {
            listProducts.Clear();
        }

        public void preencheListaComExemplos(ICollection<IFinancialProduct> listProducts)
        {
            listProducts.Clear();
            listProducts.Add(new Stock("Petrobras PETR3", "PETR3"));
            listProducts.Add(new Fund("Fundos Imobiliários BTLG11", "Lmóvel (Híbrido)", "Imobiliário"));
            listProducts.Add(new Fund("Vinci Shopping Centers", "Shoppings", "Imobiliário"));
            listProducts.Add(new Stock("Tesla, Inc.", "TSLA"));
            listProducts.Add(new Fund("Brb Liquidez FI Renda FIxa", "Bancário", "Renda Fixa"));
            listProducts.Add(new Fund("BB MULTIMERCADO LP FX BALANCED INVESTIMENTO NO EXTERIOR PRIVATE", "Investimento no Exterior", "Multimercado"));
        }

        public bool AddShareToList(ICollection<IFinancialProduct> listProducts)
        {
            //return listProducts.Add(new Stock());
            listProducts.Add(new Stock());
            return true;
        }
        public void AddFundToList(ICollection<IFinancialProduct> listProducts)
        {
            listProducts.Add(new Fund());
        }

        public bool DeleteFinancialProduct(ICollection<IFinancialProduct> listProducts,IFinancialProduct financialProduct)
        {
            return listProducts.Remove(financialProduct);
        }

        //public void AtualizaTelaPorModificarList()
        //{
        //    //this.Stock = new List<Stock>(this.Stock);
        //    //OnPropertyChanged("FinancialProducts");
        //    this.Produtos = new List<IFinancialProduct>(this.Produtos);
        //    OnPropertyChanged("Shares");
        //}

        public void UpdateFinancialProduct(ICollection<IFinancialProduct> listProducts,IFinancialProduct recebido)
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
