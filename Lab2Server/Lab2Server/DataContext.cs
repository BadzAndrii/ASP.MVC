using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Lab2Server.Models;

namespace Lab2Server
{
    public class DataContext<TEntity> : DbContext where TEntity : class, new()
    {
        public DataContext() : base("DbConnection") { }

        public DbSet<TEntity> Data { get; set; }
    }
}
