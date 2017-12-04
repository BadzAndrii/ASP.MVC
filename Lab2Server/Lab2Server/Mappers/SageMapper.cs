using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2Server.Mappers
{
    public static class SageMapper
    {
        public static Sage MapFromModel(this SageModel model, Sage sage)
        {
            sage.Name = model.Name;
            sage.Age = model.Age;
            sage.City = model.City;

            return sage;
        }

        public static SageModel MapToSageModel(this Sage sage)
        {
            return new SageModel
            {
                Id = sage.Id,
                Name = sage.Name,
                City = sage.City,
            };
        }
        public static ListSageModels MapTolistSageModel(this List<Sage> sages, Dictionary<int, string> authorsDictionary)
        {
            var model = new ListSageModels();

            model.Sages.AddRange(sages.Select(x => new SageModel { Name = x.Name, Id = x.Id, City = x.City, Age = x.Age }));

            return model;
        }
    }
}