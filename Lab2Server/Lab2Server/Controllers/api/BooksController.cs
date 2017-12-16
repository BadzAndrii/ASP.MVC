using Lab2Server.Entities;
using Lab2Server.Mappers;
using Lab2Server.Models;
using Lab2Server.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Lab2Server.Controllers.api
{
    public class BooksController : ApiController
    {
        private readonly ISageRepository _sageRepository;
        private readonly IRepository<Book> _booksRepository;

        public BooksController(ISageRepository sageRepository, IRepository<Book> booksRepository)
        {
            _sageRepository = sageRepository;
            _booksRepository = booksRepository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public dynamic Get(int id)
        {
            var book = _booksRepository.Get(id) ?? new Book();
            var authors = _sageRepository.GetAuthorsDictionary();

            return book.MapToDynamiBookModel(authors);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}