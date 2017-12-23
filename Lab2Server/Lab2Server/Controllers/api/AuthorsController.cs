using Lab2Server.Entities;
using Lab2Server.Extensions;
using Lab2Server.Mappers;
using Lab2Server.Models;
using Lab2Server.Models.api;
using Lab2Server.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lab2Server.Controllers.api
{
    public class AuthorsController : ApiController
    {
        private readonly ISageRepository _sageRepository;

        public AuthorsController(ISageRepository sageRepository)
        {
            _sageRepository = sageRepository;
        }


        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>
        public IEnumerable<SageDTO> Get()
        {
            //TODO: move to mapper
            return _sageRepository.List(1, 1000).Select(b => new SageDTO
            {
                Id = b.Id,
                Name = b.Name,
                City = b.City,
                Age = b.Age,
                Photo = b.Photo.ToImageSource() ?? "/Content/no-sage-preview.png",
            });
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/<controller>/5
        public DetailedSageModel Get(int id)
        {
            var sage = _sageRepository.Get(id) ?? new Sage();
            var authors = _sageRepository.GetAuthorsDictionary();

            return sage.MapToDynamiSageModel();
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        // POST api/<controller>
        public async Task Post()
        {
            var sage = new Sage();

            var model = await ReadFormDataToSaveSageModel();

            model.MapToSage(sage);

            _sageRepository.Save(sage);
        }


        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        public async Task Put(int id)
        {
            var sage = _sageRepository.Get(id);

            var model = await ReadFormDataToSaveSageModel();
            model.Id = id;

            model.MapToSage(sage);

            _sageRepository.Save(sage);
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _sageRepository.Delete(id);
        }

        private async Task<SaveSageModel> ReadFormDataToSaveSageModel()
        {
            var provider = new InMemoryMultipartFormDataStreamProvider();

            await Request.Content.ReadAsMultipartAsync(provider);

            var photoStream = await provider.Files[0].ReadAsStreamAsync();

            return new SaveSageModel
            {
                Age = Convert.ToInt32(provider.FormData[nameof(SaveSageModel.Age)]),

                Name = provider.FormData[nameof(SaveSageModel.Name)],
                City = provider.FormData[nameof(SaveSageModel.City)],

                PhotoUpload = photoStream.ToBlob()
            };
        }
    }
}