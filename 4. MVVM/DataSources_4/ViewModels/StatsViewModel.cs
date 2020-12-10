using Microsoft.Win32;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.Core.Models;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        private string _xamlFile;
        private int _allTasksCount, _activeTasksCount, _completedTasksCount;
        private bool _filePicked;
        private readonly IToDoItemsRepository _repository;

        public ICommand PickupFileCommand { get; }

        public string XamlFile
        {
            get => _xamlFile;
            set => SetProperty(ref _xamlFile, value);
        }

        public int AllTasksCount
        {
            get => _allTasksCount;
            protected set => SetProperty(ref _allTasksCount, value);
        }

        public int ActiveTasksCount
        {
            get => _activeTasksCount;
            protected set => SetProperty(ref _activeTasksCount, value);
        }

        public int CompletedTasksCount
        {
            get => _completedTasksCount;
            protected set => SetProperty(ref _completedTasksCount, value);
        }

        public bool FilePicked
        {
            get => _filePicked;
            protected set => SetProperty(ref _filePicked, value);
        }

        public StatsViewModel(IToDoItemsRepository repository)
        {
            PickupFileCommand = new RelayCommand(PickupFile, c => string.IsNullOrEmpty(_xamlFile));
            _repository = repository;
        }

        public async override Task OnNavigatedToAsync()
        {
            var items = await _repository.GetAllAsync();

            AllTasksCount = items.Count();
            ActiveTasksCount = items.Count(x => !x.Done);
            CompletedTasksCount = items.Count(x => x.Done);
        }

        private void PickupFile(object obj)
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                XamlFile = fileDialog.FileName;
                FilePicked = true;
            }
        }
    }
}
