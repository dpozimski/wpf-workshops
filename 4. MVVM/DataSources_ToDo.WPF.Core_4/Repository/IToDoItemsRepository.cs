using System;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.WPF.Core.Repository
{
    public interface IToDoItemsRepository
    {
        Task<IQueryable<ToDoItem>> GetAllAsync();
        Task UpdateAsync(ToDoItem entity);
        Task<ToDoItem> AddAsync(ToDoItem entity);
    }
}
