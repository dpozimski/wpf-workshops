using System.Windows.Input;
using ToDo.WPF.Core.Models;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core.ViewModels
{

    public class TodoNoteItemDockViewModel : DockViewModel
    {
        private ToDoItem _model;
        private readonly IToDoItemsRepository _repository;

        public string Task => _model?.Task;

        public string Notes
        {
            get => _model.Notes;
            set
            {
                _model.Notes = value;
                OnPropertyChanged(nameof(_model));
            }
        }

        public ICommand SaveCommand { get; }

        public TodoNoteItemDockViewModel(IToDoItemsRepository repository, ToDoItem model)
        {
            _model = model;
            _repository = repository;
            SaveCommand = new RelayCommand(Save);
        }

        private async void Save(object obj)
        {
            await _repository.UpdateAsync(_model);
        }
    }
}
