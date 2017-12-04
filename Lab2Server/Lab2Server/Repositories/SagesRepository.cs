using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2Server.Repositories
{
    public class SagesRepository : IRepository<SageModel, ListSageModels>
    {
        private readonly DataContext<Sage> _sageDataContext = new DataContext<Sage>();
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        private Sage GetEntity(int id)
        {
            return _sageDataContext.Data.FirstOrDefault(x => x.Id == id);
        }

        public SageModel Get(int id)
        {
            return GetEntity(id).MapToSageModel();
        }

        public ListSageModels GetAdminList()
        {
            throw new NotImplementedException();
        }

        public List<SageModel> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save(ListSageModels entity)
        {
            throw new NotImplementedException();
        }
    }
}