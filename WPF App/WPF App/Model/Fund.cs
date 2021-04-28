using System;                               //Permite manipular evento
using System.ComponentModel;                //Da Biblioteca .NET, permite herdar o INotifyPropertyChanged para usar PropertyChangedEventHandler e PropertyChangedEventArgs
using WPF_App.Command;
using WPF_App.View;
using System.Data.SQLite;

namespace WPF_App.Model
{

    public class Fund : BaseNotifyPropertyChanged, IFinancialProduct //Herdo
    {
        public Fund()
        {
            this.categoria = "Fund";
        }
        public Fund(int Id)
        {
            this.categoria = "Fund";
            this.Id = Id;
        }
        public Fund(string name,string setor, string tipo)
        {
            this.categoria = "Fund";
            this.name = name;
            this.setor = setor;
            this.tipo = tipo;

        }
        public Fund(int Id, string categoria, string name, string setor, string tipo)
        {
            this.Id = Id;
            this.categoria = categoria;
            this.name = name;
            this.setor = setor;
            this.tipo = tipo;

        }
        private string stringNula()
        {
            return "_vazio_"; //#N/A
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
        private string _setor;
        public string setor
        {
            get
            {
                if (string.IsNullOrEmpty(_setor))
                {
                    return stringNula();

                }
                return _setor;
            }
            set
            {
                _setor = value;
                OnPropertyChanged("setor");
            }
        }
        private string _tipo;
        public string tipo
        {
            get
            {
                if (string.IsNullOrEmpty(_tipo))
                {
                    return stringNula();
                }
                return _tipo;
            }
            set
            {
                _tipo = value;
                OnPropertyChanged("tipo");
            }
        }
        public void AtualizaEmNovaJanela()
        {
            UpdateFundWindow updateWindow = new UpdateFundWindow(this);
            updateWindow.ShowDialog();
        }
    }
}
