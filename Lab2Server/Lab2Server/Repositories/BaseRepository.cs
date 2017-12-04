using System.Linq;
using System.Collections.Generic;
using Lab2Server.Entities;

namespace Lab2Server.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : KeyEntity, new()
    {
        protected readonly DataContext<TEntity> _context = new DataContext<TEntity>();

        public TEntity Get(int id)
        {
            return _context.Data.FirstOrDefault(x => x.Id == id);
        }

        public List<TEntity> List(int page, int count)
        {
            return _context.Data.Skip(page * count).Take(count).ToList();
        }

        public void Save(TEntity entity)
        {
            _context.Data.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Data.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}