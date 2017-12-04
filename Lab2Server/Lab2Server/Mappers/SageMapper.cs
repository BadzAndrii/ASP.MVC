using System.Linq;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Entities;
using Lab2Server.Extensions;

namespace Lab2Server.Mappers
{
    public static class SageModelMapper
    {
        public static SageModel MapToSageModel(this Sage sage)
        {
            return new SageModel { Id = sage.Id, Age = sage.Age, Name = sage.Name, City = sage.City, Photo = sage.Photo.ToBase64String() };
        }

        public static List<SageModel> MapToListSageModel(this List<Sage> sages, Dictionary<int, string> authorsDictionary)
        {
            return sages.Select(s => s.MapToSageModel()).ToList();
        }
    }

    public static class SageMapper
    {
        public static Sage MapToSage(this SageModel model, Sage sage)
        {
            sage.Name = model.Name;
            sage.Age = model.Age;
            sage.City = model.City;

            return sage;
        }
    }
}