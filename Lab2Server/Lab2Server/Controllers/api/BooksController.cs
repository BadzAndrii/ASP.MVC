using System;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Lab2Server.Mappers;
using Lab2Server.Entities;
using Lab2Server.Extensions;
using Lab2Server.Models.api;
using Lab2Server.Repositories;
using Lab2Server.Repositories.DTOs;

namespace Lab2Server.Controllers.api
{
    public class BooksController : ApiController
    {
        private readonly ISageRepository _sageRepository;
        private readonly IBookRepository _booksRepository;

        public BooksController(ISageRepository sageRepository, IBookRepository booksRepository)
        {
            _sageRepository = sageRepository;
            _booksRepository = booksRepository;
        }

        // GET api/<controller>
        public IEnumerable<BookDTO> Get()
        {
            return _booksRepository.GetBookDTOs();
        }

        // GET api/<controller>/5
        public DetailedBookModel Get(int id)
        {
            var book = _booksRepository.Get(id) ?? new Book();
            var authors = _sageRepository.GetAuthorsDictionary();

            return book.MapToDynamiBookModel(authors);
        }

        // POST api/<controller>
        public async Task Post()
        {
            var book = new Book();

            var model = await ReadFormDataToSaveBookModel();

            var bookAuthors = _sageRepository.Get(model.SelectedAuthorsIds);

            model.MapToBook(book, bookAuthors);

            _booksRepository.Save(book);
        }

        // PUT api/<controller>/5
        public async Task Put(int id)
        {
            var book = _booksRepository.Get(id);

            var model = await ReadFormDataToSaveBookModel();
                model.Id = id;

            var bookAuthors = _sageRepository.Get(model.SelectedAuthorsIds);

            model.MapToBook(book, bookAuthors);

            _booksRepository.Save(book);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _booksRepository.Delete(id);
        }

        private async Task<SaveBookModel> ReadFormDataToSaveBookModel()
        {
            var provider = new InMemoryMultipartFormDataStreamProvider();

            await Request.Content.ReadAsMultipartAsync(provider);
            
            var photoStream = await provider.Files[0].ReadAsStreamAsync();

            return new SaveBookModel
            {
                Year = Convert.ToInt32(provider.FormData[nameof(SaveBookModel.Year)]),

                Name = provider.FormData[nameof(SaveBookModel.Name)],
                Description = provider.FormData[nameof(SaveBookModel.Description)],
                SelectedAuthorsIds = provider.FormData[nameof(SaveBookModel.SelectedAuthorsIds)].Split(',').Select(i => Convert.ToInt32(i)).ToArray(),

                PhotoUpload = photoStream.ToBlob()
            };
        }
    }
}