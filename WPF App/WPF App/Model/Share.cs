using System;                               //Permite manipular evento
using System.ComponentModel;                //Da Biblioteca .NET, permite herdar o INotifyPropertyChanged para usar PropertyChangedEventHandler e PropertyChangedEventArgs
using WPF_App.Command;
using WPF_App.View;
using SQLite;

namespace WPF_App.Model
{
    public class Share : BaseNotifyPropertyChanged, IFinancialProduct //Herdo
    {
        public Share()
        {
            this.categoria = "Ação";
        }
        public Share(string name)
        {
            this.categoria = "Ação"; 
            this.name = name;
        }
        public Share(string name,string code)
        {
            this.categoria = "Ação"; 
            this.name = name;
            this.code = code;
        }

        private string stringNula()
        {
            return "_vazio_";
        }
        private int _Id;
        [PrimaryKey, AutoIncrement]
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
