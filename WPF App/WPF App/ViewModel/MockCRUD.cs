using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Model;

namespace WPF_App.ViewModel
{
    public class MockCRUD :ICRUD
    {
        public bool RetornaBooleanoParaReturnDoAdd { get; set; }
        public bool RetornaBooleanoParaReturnDoDelete { get; set; }
        public Fund RetornoFundoCriado { get; set; }
        public ICollection<IFinancialProduct> RetornoListaBD { get; set; }
        public bool AddShareToList(ICollection<IFinancialProduct> listProducts)
        {
            return RetornaBooleanoParaReturnDoAdd;
        }
        public Fund CreateFund() 
        {
            return RetornoFundoCriado;
        }
        public bool DeleteFinancialProduct(ICollection<IFinancialProduct> listProducts, IFinancialProduct financialProduct) 
        {
            return RetornaBooleanoParaReturnDoDelete;
        }
        public void preencheListaComExemplos(ICollection<IFinancialProduct> listProducts)
        {

        }
        public void UpdateFinancialProduct(ICollection<IFinancialProduct> listProducts, IFinancialProduct recebido)
        {

        }
        public ICollection<IFinancialProduct> UpdateTheListView(ICollection<IFinancialProduct> listProducts)
        {
            return RetornoListaBD;
        }
    }
}
