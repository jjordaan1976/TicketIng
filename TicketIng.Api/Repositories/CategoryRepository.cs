using System.Data;
using TicketIng.Models;
using Dapper;

namespace TicketIng.Api.Repositories
{
    public class CategoryRepository
    {
        private readonly IDbConnection _db;
        public CategoryRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Category";
            return await _db.QueryAsync<Category>(sql);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.Category WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Category>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Category entity)
        {
            const string sql = @"
                INSERT INTO dbo.Category (Name, Description)
                VALUES (@Name, @Description);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            const string sql = "UPDATE dbo.Category SET Name=@Name, Description=@Description WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.Category WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
