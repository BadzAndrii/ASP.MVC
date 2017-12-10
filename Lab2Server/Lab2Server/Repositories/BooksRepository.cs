using Lab2Server.Entities;

namespace Lab2Server.Repositories
{
    public class BooksRepository : BaseRepository<Book>
    {
        public BooksRepository(DataContext context) : base(context) { }
    }
}