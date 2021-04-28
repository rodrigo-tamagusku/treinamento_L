using System;                               //Permite manipular evento
using System.ComponentModel;                //Da Biblioteca .NET, permite herdar o INotifyPropertyChanged para usar PropertyChangedEventHandler e PropertyChangedEventArgs
using WPF_App.Command;
using WPF_App.View;

namespace WPF_App.Model
{
    public class Stock : BaseNotifyPropertyChanged, IFinancialProduct //Herdo
    {
        public Stock()
        {
            this.categoria = "Stock";
        }
        public Stock(string name)
        {
            this.categoria = "Stock";
            this.name = name;
        }
        public Stock(int Id)
        {
            this.categoria = "Stock";
            this.Id = Id;
        }
        public Stock(string name,string code)
        {
            this.categoria = "Stock"; 
            this.name = name;
            this.code = code;
        }
        public Stock(int Id, string categoria, string name, string code)
        {
            this.Id = Id;
            this.categoria = categoria;
            this.name = name;
            this.code = code;
        }

        private string stringNula()
        {
            return "_vazio_";
        }
        private int _Id;
        //[PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                OnPropertyChanged("Id");
            }
        }
        private string _categoria;
        public string categoria
        {
            get
            {
                return _categoria;
            }
            set
            {
                _categoria = value;
                OnPropertyChanged("categoria");
            }
        }
        private string _name;
        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return stringNula();

                }
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        private string _code;
        public string code
        {
            get
            {
                if (string.IsNullOrEmpty(_code))
                {
                    return stringNula();
                }
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("code");
            }
        }
        public void AtualizaEmNovaJanela()
        {
            UpdateShareWindow updateWindow = new UpdateShareWindow(this);
            updateWindow.ShowDialog();
        }
    }

}
