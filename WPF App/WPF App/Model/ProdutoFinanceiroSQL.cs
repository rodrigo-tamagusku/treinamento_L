using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Command;
using WPF_App.View;

namespace WPF_App.Model
{
    public class ProdutoFinanceiroSQL:BaseNotifyPropertyChanged,IFinancialProduct
    {
        public ProdutoFinanceiroSQL()
        {
            this.categoria = "Ação";
        }
        public ProdutoFinanceiroSQL(string name)
        {
            this.categoria = "Ação";
            this.name = name;
        }
        public ProdutoFinanceiroSQL(string name, string code)
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
            if (this.categoria == "Ação")
            {
                UpdateShareWindow updateWindow = new UpdateShareWindow(this);
                updateWindow.Show();
            }
            else if (this.categoria == "Fundo")
            {
                UpdateFundWindow updateWindow = new UpdateFundWindow(this);
                updateWindow.Show();
            }
        }
    }
}
