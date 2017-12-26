using Lab2Server.Entities;
using System.Data.Entity;

namespace Lab2Server
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection")
        {
        }

        public DbSet<Book> BookContext { get; set; }
        public DbSet<Sage> SageContext { get; set; }

        public DbSet<TResult> GetData<TResult>() where TResult : class, new()
        {
            return BookContext as DbSet<TResult> ?? SageContext as DbSet<TResult>;
        }
    }
}
