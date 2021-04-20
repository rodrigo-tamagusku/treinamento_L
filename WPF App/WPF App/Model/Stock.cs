
namespace WPF_App.Stock.Model
{
    using System;                               //Permite manipular evento
    using System.ComponentModel;                //Da Biblioteca .NET, permite herdar o INotifyPropertyChanged para usar PropertyChangedEventHandler e PropertyChangedEventArgs
    public class Stock : INotifyPropertyChanged //Herdo
    {
        
        public Stock(string stockName,string stockCode)          //Construtor
        {
            name = stockName;
            code = stockCode;
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
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion
    }
}
