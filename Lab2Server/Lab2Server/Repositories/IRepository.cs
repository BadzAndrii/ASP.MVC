using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Server.Repositories
{
   public interface IRepository<TModel, TListModel> where TModel : class, new() where TListModel : class, new()
    {
        TModel Get(int id);

        List<TModel> GetList();
        TListModel GetAdminList();

        void Save(TListModel entity);
        void Delete(int id);
    }
}
