using System.Linq.Expressions;
using SQLite;
using YahooScraper.Models.Db;

namespace YahooScraper.Implementation.Db;

public class DatabaseContext : IAsyncDisposable
{
    private const string DbName = "YF_DB.db3";
    private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

    private SQLiteAsyncConnection? _connection;

    private SQLiteAsyncConnection Database =>
        _connection ??= new SQLiteAsyncConnection(DbPath,
            SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);

    public async Task InitializeAsync()
    {
        await CreateTableIfNotExists<CompanyInfoDto>();
        await CreateTableIfNotExists<CompanyPriceInfoDto>();
    }

    private async Task CreateTableIfNotExists<TTable>() where TTable : class, new()
    {
        await Database.CreateTableAsync<TTable>();
    }

    private AsyncTableQuery<TTable> GetTable<TTable>() where TTable : class, new()
    {
        return Database.Table<TTable>();
    }

    public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
    {
        var table = GetTable<TTable>();
        return await table.ToListAsync();
    }

    public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate,
        Expression<Func<TTable, object>>? orderBy = null)
        where TTable : class, new()
    {
        var table = GetTable<TTable>();
        table = table.Where(predicate);
        if (orderBy != null)
            table = table.OrderByDescending(orderBy);
        return await table.ToListAsync();
    }

    private async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
    {
        return await action();
    }

    public async Task<TTable?> GetItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
    {
        return await Execute<TTable, TTable>(async () => await Database.GetAsync<TTable>(primaryKey));
    }

    public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
    {
        return await Execute<TTable, bool>(async () => await Database.InsertAsync(item) > 0);
    }

    public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
    {
        return await Database.UpdateAsync(item) > 0;
    }

    public async Task<bool> DeleteAllAsync<TTable>() where TTable : class, new()
    {
        return await Database.DeleteAllAsync<TTable>() > 0;
    }

    public async Task<bool> DeleteItemAsync<TTable>(TTable item) where TTable : class, new()
    {
        return await Database.DeleteAsync(item) > 0;
    }

    public async Task<bool> DeleteItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
    {
        return await Database.DeleteAsync<TTable>(primaryKey) > 0;
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            await _connection.CloseAsync();
            GC.SuppressFinalize(this);
        }
    }
}