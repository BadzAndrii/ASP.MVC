using System.Linq;
using System.Collections.Generic;
using Lab2Server.Entities;

namespace Lab2Server.Repositories
{
    public class SagesRepository : BaseRepository<Sage>, ISageRepository
    {
        public SagesRepository(DataContext dataContext) : base(dataContext) { }

        public IDictionary<int, string> GetAuthorsDictionary()
        {
            return _context.GetData<Sage>().Select(s => new { s.Id, s.Name }).ToDictionary(k => k.Id, v => v.Name);
        }
    }
}