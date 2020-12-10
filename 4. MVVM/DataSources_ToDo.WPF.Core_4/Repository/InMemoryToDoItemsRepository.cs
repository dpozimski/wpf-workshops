using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.WPF.Core.Repository
{
    public class InMemoryToDoItemsRepository : IToDoItemsRepository
    {
        private List<ToDoItem> _items = new List<ToDoItem>();

        public Task<IQueryable<ToDoItem>> GetAllAsync() => Task.FromResult<IQueryable<ToDoItem>>(_items.AsQueryable());

        public Task UpdateAsync(ToDoItem entity)
        {
            var record = _items.FirstOrDefault(x => x.Id == entity.Id);

            if (record is null) throw new TodoAppException("ToDo item does not exists");

            record.Done = entity.Done;
            record.Task = entity.Task;

            return Task.CompletedTask;
        }

        public Task<ToDoItem> AddAsync(ToDoItem entity)
        {
            if(entity is null || string.IsNullOrEmpty(entity.Task))
            {
                throw new TodoAppException("Invalid entity state");
            }

            _items.Add(entity);

            return Task.FromResult(entity);
        }
    }
}
