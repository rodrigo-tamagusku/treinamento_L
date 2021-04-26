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
        void AddShareToList(ObservableCollection<IFinancialProduct> listProducts);
        void AddFundToList(ObservableCollection<IFinancialProduct> listProducts);
        void DeleteFinancialProduct(ObservableCollection<IFinancialProduct> listProducts, IFinancialProduct financialProduct);
        void preencheListaComExemplos(ObservableCollection<IFinancialProduct> listProducts);
        void UpdateFinancialProduct(ObservableCollection<IFinancialProduct> listProducts, IFinancialProduct recebido);
        void UpdateTheListView(ObservableCollection<IFinancialProduct> listProducts);
    }
}
