using System.ComponentModel;

namespace ToDo.WPF.Core
{
    public class ToDoItemModel : INotifyPropertyChanged
    {
        private string _task;
        private bool _done;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Task
        {
            get => _task;
            set
            {
                _task = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Task)));
            }
        }

        public bool Done
        {
            get => _done;
            set
            {
                _done = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Done)));
            }
        }
    }
}