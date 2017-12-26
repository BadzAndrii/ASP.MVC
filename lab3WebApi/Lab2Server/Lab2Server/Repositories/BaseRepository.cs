using System.Linq;
using System.Collections.Generic;
using Lab2Server.Entities;

namespace Lab2Server.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : KeyEntity, new()
    {
        protected readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }

        public TEntity Get(int id)
        {
            return _context.GetData<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public List<TEntity> Get(params int[] ids)
        {
            return _context.GetData<TEntity>().Where(s => ids.Contains(s.Id)).ToList();
        }

        public List<TEntity> List(int page, int count)
        {
            if (page <= 0)
                throw new System.ArgumentException("Must be greater than 0", nameof(page));

            if(count <= 0)
                throw new System.ArgumentException("Must be greater than 0", nameof(count));

            return _context.GetData<TEntity>().OrderBy(e => e.Id).Skip(page * count - count).Take(count).ToList();
        }

        public int Count()
        {
            return _context.GetData<TEntity>().Count();
        }

        public void Save(TEntity entity)
        {
            if (entity.Id == 0)
            {
                _context.GetData<TEntity>().Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.GetData<TEntity>().Remove(Get(id));
            _context.SaveChanges();
        }
    }
}