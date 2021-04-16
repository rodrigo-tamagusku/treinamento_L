
namespace WPF_App.Stock.ViewModel
{
    using System;
    using WPF_App.Stock.Model;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class StockViewModel
    {
        public StockViewModel()
        {
            listStock = new List<Stock>();
            listStock.Add(new Stock("Petrobras PETR3", "PETR3"));
            listStock.Add(new Stock("Petrobras PETR4", "PETR4"));
            listStock.Add(new Stock("Rodrigo", "RODR"));
        }

        private List<Stock> listStock;

        public List<Stock> Stock
        {
            get
            {
                return listStock;
            }
        }

    }
}
