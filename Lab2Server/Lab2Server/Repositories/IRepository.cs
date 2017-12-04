using System.Collections.Generic;

namespace Lab2Server.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity Get(int id);
        List<TEntity> List(int page, int count);
        void Save(TEntity entity);
        void Delete(int id);
    }
}
