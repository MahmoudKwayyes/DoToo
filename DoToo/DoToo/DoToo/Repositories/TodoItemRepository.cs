using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace DoToo.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private SQLiteAsyncConnection connection;
        public event EventHandler<TodoItem> OnItemAdded;
        public event EventHandler<TodoItem> OnItemUpdated;

        public async Task CreateConnectoin()
        {
            if (connection != null)
                return;
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TodoItems.db");
            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<TodoItem>();
            if (await connection.Table<TodoItem>().CountAsync() == 0)
                await connection.InsertAsync(new TodoItem()
                {
                    Title = "Welcom to DoToo",
                    Due = DateTime.Now
                });
        }

        public async Task<List<TodoItem>> GetItems()
        {
            await CreateConnectoin();
            return await connection.Table<TodoItem>().ToListAsync();
        }

        public async Task AddItem(TodoItem item)
        {
            await CreateConnectoin();
            await connection.InsertAsync(item);
            OnItemAdded?.Invoke(this, item);
        }

        public async Task UpdateItem(TodoItem item)
        {
            await CreateConnectoin();
            await connection.UpdateAsync(item);
            OnItemUpdated?.Invoke(this, item);
        }

        public async Task AddOrUpdateItem(TodoItem item)
        {
            if (item.Id == 0)
                await AddItem(item);
            else
                await UpdateItem(item);
        }

    }
}
