using Lab2Server.Mappers;
using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2Server.Repositories
{
    public class BooksRepository : IRepository<BookModel, ListBookModels>
    {
        private readonly DataContext<Book> _bookDataContext = new DataContext<Book>();
        private readonly DataContext<Sage> _sageDataContext = new DataContext<Sage>();

        public void Delete(int id)
        {
            var book = GetEntity(id);

            _bookDataContext.Data.Remove(book);

            _bookDataContext.SaveChanges();
        }

        private Book GetEntity(int id)
        {
            return _bookDataContext.Data.FirstOrDefault(x => x.Id == id);
        }

        public BookModel Get(int id)
        {
            return GetEntity(id).MapToBookModel();
        }

        public List<BookModel> GetList()
        {
            return _bookDataContext.Data.Select(x => x.MapToBookModel()).ToList();
        }

        public ListBookModels GetAdminList()
        {
            var authors = _sageDataContext.Data
                    .Select(x => new { Id = x.Id, Name = x.Name })
                    .OrderBy(x => x.Name)
                    .ToDictionary(key => key.Id, val => val.Name);

            return _bookDataContext.Data.ToList().MapTolistBookModel(authors);
        }

        public void Save(BookModel model)
        {
            var authors = _sageDataContext
                   .Data
                   .Where(author => model.Authors.Contains(author.Id))
                   .ToList();
            
            Book book = model.Id > 0
                ? model.MapFromModel(GetEntity(model.Id), authors)
                : model.MapFromModel(new Book(), authors);

            _bookDataContext.Data.Add(book);
            _bookDataContext.SaveChanges();
        }
    }
}