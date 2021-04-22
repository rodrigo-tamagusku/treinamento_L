
namespace WPF_App.Model
{
    using System;                               //Permite manipular evento
    using System.ComponentModel;                //Da Biblioteca .NET, permite herdar o INotifyPropertyChanged para usar PropertyChangedEventHandler e PropertyChangedEventArgs
    using WPF_App.Command;

    public class Stock : FinancialProduct,IFinancialProduct //Herdo
    {
        
    }

}
