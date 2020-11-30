using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core.ViewModels
{
    public class TodoNotesViewModel : BaseViewModel
    {
        private readonly IToDoItemsRepository _repository;
        private ObservableCollection<DockViewModel> _documents;

        public ObservableCollection<DockViewModel> Documents
        {
            get => _documents;
            set => SetProperty(ref _documents, value);
        }


        public TodoNotesViewModel(IToDoItemsRepository repository)
        {
            _repository = repository;
        }

        public override async Task OnNavigatedToAsync()
        {
            var models = await _repository.GetAllAsync();
            var documentVms = models.Select(m => new TodoNoteItemDockViewModel(_repository, m)).ToList();

            InitializeDocuments(documentVms);
        }

        private void InitializeDocuments(List<TodoNoteItemDockViewModel> documentVms)
        {
            Documents = new ObservableCollection<DockViewModel>();

            foreach (var documentVm in documentVms)
            {
                documentVm.PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == nameof(TodoNoteItemDockViewModel.IsClosed))
                    {
                        if (documentVm.IsClosed)
                        {
                            Documents.Add(documentVm);
                        }
                        else
                        {
                            Documents.Remove(documentVm);
                        }
                    }
                };

                Documents.Add(documentVm);
            }
        }
    }
}
