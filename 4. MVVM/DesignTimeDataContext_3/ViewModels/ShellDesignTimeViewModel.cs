using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using ToDo.WPF.Core.Models;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core.ViewModels
{
    public class ShellDesignTimeViewModel : ShellViewModel
    {
        private static IToDoItemsRepository Repository = Substitute.For<IToDoItemsRepository>();

        static ShellDesignTimeViewModel()
        {
            Repository.GetAllAsync().Returns((new List<ToDoItem>()
            {
                new ToDoItem() { Task = "1", Done = false},
                new ToDoItem() { Task = "2", Done = true}
            }).AsQueryable());
        }

        public ShellDesignTimeViewModel() : base(new StatsViewModel(Repository), new TodosViewModel(Repository))
        {
            TodoViewModel.InputTasks = new ToDoItemModelCollection(new List<ToDoItemModel>() 
            {
                new ToDoItemModel(new ToDoItem(){ Task = "InputTask1" }),
                new ToDoItemModel(new ToDoItem(){ Task = "InputTask2" })
            });
            TodoViewModel.AddTasksCommand.Execute(null);
        }
    }
}
