using System.Linq;
using System.Collections.Generic;
using Lab2Server.Entities;
using Lab2Server.Repositories.DTOs;
using Lab2Server.Extensions;

namespace Lab2Server.Repositories
{
    public class SagesRepository : BaseRepository<Sage>, ISageRepository
    {
        public SagesRepository(DataContext dataContext) : base(dataContext) { }

        public IDictionary<int, string> GetAuthorsDictionary()
        {
            return _context.GetData<Sage>().Select(s => new { s.Id, s.Name }).ToDictionary(k => k.Id, v => v.Name);
        }

        public IEnumerable<SageDTO> GetAuthorDTOs()
        {
            return _context.GetData<Sage>()
                .ToList()
                .Select(b => new SageDTO
            {
                Id = b.Id,
                Name = b.Name,
                City = b.City,
                Age = b.Age,
                Photo = b.Photo.ToImageSource() ?? "/Content/no-sage-preview.png",
            });
        }
    }
}