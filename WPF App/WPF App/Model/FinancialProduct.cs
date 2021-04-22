
namespace WPF_App.Model
{
    using System;                               //Permite manipular evento
    using System.ComponentModel;                //Da Biblioteca .NET, permite herdar o INotifyPropertyChanged para usar PropertyChangedEventHandler e PropertyChangedEventArgs
    using WPF_App.Command;

    public class FinancialProduct : ObservableObject, IFinancialProduct //Herdo
    {
        public FinancialProduct()
        {

        }
        public FinancialProduct(string productName, string productCode)          //Construtor
        {
            name = productName;
            code = productCode;
        }

        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("code");
            }
                
        }
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");     // verifico se name mudou atraves de evento
            }
        }
    }

}
