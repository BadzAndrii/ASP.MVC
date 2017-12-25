﻿using System.Linq;
using System.Collections.Generic;

using Lab2Server.Models;
using Lab2Server.Entities;
using Lab2Server.Extensions;
using Lab2Server.Models.api;

namespace Lab2Server.Mappers
{
    public static class SageMapper
    {
        public static Sage MapToSage(this SageModel model, Sage sage)
        {
            sage.Name = model.Name;
            sage.Age = model.Age;
            sage.City = model.City;
            //sage.Photo = model.PhotoUpload?.InputStream.ToBlob() ?? sage.Photo;
            return sage;
        }

        public static Sage MapToSage(this EditSageModel model, Sage sage)
        {
            MapToSage(model as SageModel, sage);

            sage.Photo = model.PhotoUpload?.InputStream.ToBlob() ?? sage.Photo;

            return sage;
        }

        public static Sage MapToSage(this SaveSageModel model, Sage sage)
        {
            sage.Name = model.Name;
            sage.Age = model.Age;
            sage.City = model.City;

            sage.Photo = model.PhotoUpload ?? sage.Photo;

            return sage;
        }
    }

    public static class SageModelMapper
    {
        public static SageModel MapToSageModel(this Sage sage)
        {
            return new SageModel
            {
                Id = sage.Id,
                Age = sage.Age,
                Name = sage.Name,
                City = sage.City,
                Photo = sage.Photo.ToImageSource() ?? "/Content/no-sage-preview.png"
            };
        }

        public static EditSageModel MapToEditSageModel(this Sage sage)
        {
            return new EditSageModel
            {
                Id = sage.Id,
                Age = sage.Age,
                Name = sage.Name,
                City = sage.City,
                Photo = sage.Photo.ToImageSource() ?? "/Content/no-sage-preview.png"
            };
        }

        public static List<SageModel> MapToListSageModel(this List<Sage> sages)
        {
            return sages.Select(s => s.MapToSageModel()).ToList();
        }

        public static DetailedSageModel MapToDynamiSageModel(this Sage sage)
        {
            return new DetailedSageModel
            {
                Id = sage.Id,
                Age = sage.Age,
                Name = sage.Name,
                City = sage.City,
                Photo = sage.Photo?.ToImageSource() ?? "/Content/no-sage-preview.png",
            };
        }
    }

}