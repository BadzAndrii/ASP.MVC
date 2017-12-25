using System.Linq;
using System.Collections.Generic;

using Lab2Server.Entities;
using Lab2Server.Repositories.DTOs;
using Lab2Server.Extensions;

namespace Lab2Server.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(DataContext context) : base(context) { }

        public IEnumerable<BookDTO> GetBookDTOs()
        {
            return _context.GetData<Book>().Select(b => new BookDTO
            {
                Id = b.Id,
                Name = b.Name,
                Year = b.Year,
                Description = b.Description,
                Photo = b.Photo.ToImageSource() ?? "/Content/no-book-preview.png",
                Authors = string.Join(",", b.Sages.Select(s => s.Name))
            });
        }
    }
}