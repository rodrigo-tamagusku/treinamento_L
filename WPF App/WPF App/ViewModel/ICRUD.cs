using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Model;

namespace WPF_App.ViewModel
{
    //Interface que define o que é obrigatório para adicionar um Banco de Dados ao meu programa
    public interface ICRUD
    {
        bool AddShareToList(ICollection<IFinancialProduct> listProducts);
        Fund CreateFund();
        bool DeleteFinancialProduct(ICollection<IFinancialProduct> listProducts, IFinancialProduct financialProduct);
        void preencheListaComExemplos(ICollection<IFinancialProduct> listProducts);
        void UpdateFinancialProduct(ICollection<IFinancialProduct> listProducts, IFinancialProduct recebido);
        ICollection<IFinancialProduct> UpdateTheListView(ICollection<IFinancialProduct> listProducts);
    }
}
