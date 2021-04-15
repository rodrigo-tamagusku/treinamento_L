using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_NET_Framework.ViewModels
{
    class StockViewModel
    {
        private List<Stock> _stocks;
        public void StockRepository() {   //construtor
            _stocks = new List<Stock>
            {
            new Stock() { name = "Petrobras PETR3", code = "PETR3" },
            new Stock() { name = "Petrobras PETR4", code = "PETR4" }
            };
        }
        public List<Stock> GetStocks()
        {
            return _stocks;   
        }
        public void UpdateStocks(Stock SelectedStock)
        {
            Stock stockToChange = _stocks.Single(s => s.code == SelectedStock.code);
            stockToChange = SelectedStock;
        }
    }
}
