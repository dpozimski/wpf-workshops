using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ToDo.WPF.Core.Models
{
    public class ToDoItemModel : INotifyPropertyChanged
    {
        private ToDoItem _entity;

        public event PropertyChangedEventHandler PropertyChanged;

        public ToDoItem Entity => _entity;

        public string Task
        {
            get => _entity.Task;
            set
            {
                _entity.Task = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Task)));
            }
        }

        public bool Done
        {
            get => _entity.Done;
            set
            {
                _entity.Done = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Done)));
            }
        }

        public ToDoItemModel(ToDoItem entity)
        {
            _entity = entity;
        }
    }
}