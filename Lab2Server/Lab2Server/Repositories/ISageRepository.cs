using System.Collections.Generic;
using Lab2Server.Entities;
using Lab2Server.Repositories.DTOs;

namespace Lab2Server.Repositories
{
    public interface ISageRepository : IRepository<Sage>
    {
        IDictionary<int, string> GetAuthorsDictionary();

        IEnumerable<SageDTO> GetAuthorDTOs();
    }
}
