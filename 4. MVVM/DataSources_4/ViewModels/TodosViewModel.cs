using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.Core.Models;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core.ViewModels
{
    public class TodosViewModel : BaseViewModel
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;

        private ToDoItemModelCollection _toDoItems;
        private ToDoItemModelCollection _inputTasks;

        public ToDoItemModelCollection InputTasks
        {
            get => _inputTasks;
            set => SetProperty(ref _inputTasks, value);
        }

        public ToDoItemModelCollection ToDoItems
        {
            get => _toDoItems;
            private set => SetProperty(ref _toDoItems, value);
        }

        public ICommand ShowAllCommand { get; }
        public ICommand ShowActiveCommand { get; }
        public ICommand ShowCompletedCommand { get; }

        public ICommand AddTasksCommand { get; }

        public TodosViewModel(IToDoItemsRepository toDoItemsRepository)
        {
            _toDoItems = new ToDoItemModelCollection();
            _toDoItemsRepository = toDoItemsRepository;

            ShowAllCommand = new RelayCommand(ShowAllAsync);
            ShowActiveCommand = new RelayCommand(ShowActive);
            ShowCompletedCommand = new RelayCommand(ShowCompleted);
            AddTasksCommand = new RelayCommand(AddTasks);
        }

        private async void AddTasks(object obj)
        {
            foreach (var item in InputTasks)
            {
                await _toDoItemsRepository.AddAsync(item.Entity);
                ToDoItems.Insert(0, new ToDoItemModel(item.Entity));
            }

            var entities = await _toDoItemsRepository.GetAllAsync();
            UpdateCollection(entities);
        }

        private async void ShowCompleted(object obj)
        {
            var entities = await _toDoItemsRepository.GetAllAsync();
            UpdateCollection(entities.Where(s => s.Done));
        }

        private async void ShowActive(object obj)
        {
            var entities = await _toDoItemsRepository.GetAllAsync();
            UpdateCollection(entities.Where(s => !s.Done));
        }

        private async void ShowAllAsync(object obj)
        {
            var entities = await _toDoItemsRepository.GetAllAsync();
            UpdateCollection(entities);
        }

        private void UpdateCollection(IQueryable<ToDoItem> entities)
        {
            var vms = entities.Select(e => new ToDoItemModel(e));
            ToDoItems = new ToDoItemModelCollection(vms);
        }
    }
}
