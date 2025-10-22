using SQLite;
using DatabaseApp.Models;

namespace DatabaseApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeAsync()
        {
           await _db.CreateTableAsync<User>();
        }

        public Task<int> AddUserAsync(User user)
        {
            return _db.InsertAsync(user);
        } 

        public Task<List<User>> GetUsersAsync()
        {
            return _db.Table<User>().ToListAsync();
        }
    }
}
