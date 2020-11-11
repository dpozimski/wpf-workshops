namespace ToDo.WPF.Core.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private TodosViewModel _todosViewModel;
        private BaseViewModel _currentViewModel;

        public TodosViewModel TodoViewModel
        {
            get => _todosViewModel;
            private set => SetProperty(ref _todosViewModel, value);
        }
        
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set => SetProperty(ref _currentViewModel, value);
        }

        public ShellViewModel(TodosViewModel todosViewModel)
        {
            _todosViewModel = todosViewModel;

            _currentViewModel = _todosViewModel;
        }
    }
}
