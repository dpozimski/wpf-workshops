using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ToDo.WPF.Core.Options;
using Dapper;

namespace ToDo.WPF.Core.Repository
{
    public class DapperToDoItemsRepository : IToDoItemsRepository
    {
        private RepositoryConfiguration _options;

        public DapperToDoItemsRepository(IOptions<RepositoryConfiguration> options)
        {
            _options = options.Value;
        }

        public async Task<ToDoItem> AddAsync(ToDoItem entity)
        {
            const string sql = "INSERT INTO ToDoItems (Task, Done) " +
                      "OUTPUT INSERTED.* " +
                      "VALUES(@Task, @Done)";
            using (var connection = new SqlConnection(_options.ConnectionString))
            {
                return await connection.QuerySingleAsync<ToDoItem>(sql, entity);
            }
        }

        public async Task<IQueryable<ToDoItem>> GetAllAsync()
        {
            const string sql = "SELECT * FROM ToDoItems ORDER BY ID DESC";

            using (var connection = new SqlConnection(_options.ConnectionString))
            {
                //iqueryable not supported in dapper
                var result = await connection.QueryAsync<ToDoItem>(sql);
                return result.AsQueryable();
            }
        }

        public async Task UpdateAsync(ToDoItem entity)
        {
            const string sql = "UPDATE ToDoItems " +
                "SET Task = @Task " +
                "WHERE Id = @Id";

            using (var connection = new SqlConnection(_options.ConnectionString))
            {
                await connection.ExecuteAsync(sql, entity);
            }
        }
    }
}
