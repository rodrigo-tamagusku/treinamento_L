namespace WPF_App.Commands
{
    using System.Windows.Input;
    using WPF_App.Stock.ViewModel;
    internal class StockUpdateCommand : ICommand
    {
        public StockUpdateCommand(StockViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        private StockViewModel _ViewModel;

        # region ICommand Members

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)    //Para permitir uso de botão
        {
            return _ViewModel.CanUpdate;
        }
        public void Execute(object parameter)
        {
            _ViewModel.SaveChanges();
        }
        #endregion
    }
}
