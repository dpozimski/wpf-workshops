using System;
using System.Windows.Input;
using ToDo.WPF.Core.Models;

namespace ToDo.WPF.Core.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private StatsViewModel _statsViewModel;
        private TodosViewModel _todosViewModel;
        private TodoNotesViewModel _todoNotesViewModel;
        private BaseViewModel _currentViewModel;
        private bool _isFlyoutOpenned;

        public StatsViewModel StatsViewModel
        {
            get => _statsViewModel;
            private set => SetProperty(ref _statsViewModel, value);
        }

        public TodoNotesViewModel TodoNotesViewModel
        {
            get => _todoNotesViewModel;
            private set => SetProperty(ref _todoNotesViewModel, value);
        }

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

        public bool IsFlyoutOpenned
        {
            get => _isFlyoutOpenned;
            private set => SetProperty(ref _isFlyoutOpenned, value);
        }

        public ICommand ToggleFlyoutCommand { get; }

        public ICommand NavigationCommand { get; }

        public ShellViewModel(StatsViewModel statsViewModel, TodosViewModel todosViewModel, TodoNotesViewModel todoNotesViewModel)
        {
            _statsViewModel = statsViewModel;
            _todosViewModel = todosViewModel;
            _todoNotesViewModel = todoNotesViewModel;
            _currentViewModel = _todosViewModel;

            ToggleFlyoutCommand = new RelayCommand(ToggleFlyout);
            NavigationCommand = new RelayCommand(Navigation);
        }

        private async void Navigation(object obj)
        {
            var param = obj as string;

            var previousViewModel = CurrentViewModel;

            if (param == "Todos") CurrentViewModel = _todosViewModel;
            else if (param == "Stats") CurrentViewModel = _statsViewModel;
            else if (param == "Notes") CurrentViewModel = _todoNotesViewModel;
            else if (param == "Exit") System.Windows.Application.Current.Shutdown();

            IsFlyoutOpenned = false;

            await previousViewModel.OnNavigatedFromAsync();
            await CurrentViewModel.OnNavigatedToAsync();
        }

        private void ToggleFlyout(object obj)
        {
            IsFlyoutOpenned = !IsFlyoutOpenned;
        }
    }
}
