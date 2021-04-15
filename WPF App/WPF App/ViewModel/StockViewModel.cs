
namespace WPF_App.Stock.ViewModel
{
    using System;
    using WPF_App.Stock.Model;
    using System.Diagnostics;

    internal class StockViewModel
    {
        private Stock _Stock;
        public string nome { get; set; }
        public StockViewModel()
        {
            _Stock = new Stock("Petrobras PETR3");
            this.nome = "Rodrigo";
        }
        
        public Stock Stock
        {
            get{
                return _Stock;
            }
        }
        public void SaveChanges()
        {
            Debug.Assert(false, string.Format("{0} foi atualizado.", Stock.name));
        }
    }
}
