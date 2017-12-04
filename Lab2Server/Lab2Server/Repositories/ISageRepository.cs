using Lab2Server.Entities;
using System.Collections.Generic;

namespace Lab2Server.Repositories
{
    public interface ISageRepository : IRepository<Sage>
    {
        List<Sage> Get(params int[] ids);
        IDictionary<int, string> GetAuthorsDictionary();
    }
}
