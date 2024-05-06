using System.Data.Common;
using BlazorHybrid.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

// public class TodoContext(string connectionString) : DbContext
public class TodoContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();
    // public string DbPath { get; }

    readonly DbConnection _dbConnection;
    // readonly string _connectionString;

    // public TodoContext()
    // {
    //     DbPath = ":memory:";
    //     // DbPath = "UnitTest1.db;mode=memory;";
    // }

    public TodoContext(string connectionString)
    {
        _dbConnection = new SqliteConnection(connectionString);
        _dbConnection.Open();
    }

    //     void test1() {
    //   if (_db == null)
    //         {
    //             var conn = new SqliteConnection("Data Source=:memory:");
    //             conn.Open();
    //             _db = new TodoContext(conn);
    //             _db.Database.EnsureCreated();
    //         }
    //         return _db;
    //     }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(_dbConnection);
}
