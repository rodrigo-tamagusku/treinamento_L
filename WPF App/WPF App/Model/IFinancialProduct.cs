//using
using WPF_App.Command;

namespace WPF_App.Model
{
    public interface IFinancialProduct
    {
        int Id { get; set; }
        string name { get; set; }
        string categoria { get; set; }
        void AtualizaEmNovaJanela();       //obrigo a ter uma janela para atualizar, idealmente
    }

}
