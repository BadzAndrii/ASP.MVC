using Lab2Server.Entities;
using System.Collections.Generic;

namespace Lab2Server.Repositories
{
    public interface ISageRepository : IRepository<Sage>
    {
        IDictionary<int, string> GetAuthorsDictionary();
    }
}
