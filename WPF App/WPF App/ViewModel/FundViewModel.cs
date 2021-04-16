
namespace WPF_App.Fund.ViewModel
{
    using System;
    using WPF_App.Fund.Model;
    using System.Diagnostics;

    internal class FundViewModel
    {
        private Fund _Fund;
        public string nome { get; set; }
        public FundViewModel()
        {
            _Fund = new Fund("BTG Pactual");
            this.nome = "Rodrigo";
        }

        public Fund Fund
        {
            get
            {
                return _Fund;
            }
        }
        public void SaveChanges()
        {
            Debug.Assert(false, string.Format("{0} foi atualizado.", Fund.name));
        }
    }
}
