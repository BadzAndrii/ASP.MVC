using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab2Server
{
    class DataContext : DbContext
    {
        public DataContext()
            : base("DbConnection")
        { }
        public DbSet<Sage> Sages { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
