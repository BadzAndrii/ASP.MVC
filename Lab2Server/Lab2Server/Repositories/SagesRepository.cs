using System.Linq;
using System.Collections.Generic;
using Lab2Server.Entities;

namespace Lab2Server.Repositories
{
    public class SagesRepository : BaseRepository<Sage>, ISageRepository
    {
        public List<Sage> Get(params int[] ids)
        {
            return _context.Data.Where(s => ids.Contains(s.Id)).ToList();
        }

        public IDictionary<int, string> GetAuthorsDictionary()
        {
            return _context.Data.Select(s => new { s.Id, s.Name }).ToDictionary(k => k.Id, v => v.Name);
        }
    }
}