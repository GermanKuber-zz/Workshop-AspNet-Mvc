using System.Collections.Generic;
using System.Linq;
using ManagerUtn.Entities;
using ManagerUtn.Models;
using ManagerUtn.Repositories.Interfaces;

namespace ManagerUtn.Repositories.DB
{
    public class BookDbRepository : IBookRepository
    {
        private ApplicationDbContext _dbContext;

        public BookDbRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
      public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }
        public Book GetById(int id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        Book IBookRepository.Remove(Book book)
        {
            return RemoveById(book.Id);
        }

        private  Book RemoveById(int id)
        {
            if (_dbContext.Books != null && _dbContext.Books.Any())
            {
                var bookDelete = _dbContext.Books.FirstOrDefault(x => x.Id == id);
                _dbContext.Books.Remove(bookDelete);
                _dbContext.SaveChanges();
                return bookDelete;
            }
            return null;
        }

        public Book Remove(int id)
        {
            return RemoveById(id);
        }

        public Book Add(Book book)
        {
            if (_dbContext.Books != null && _dbContext.Books.Any())
                book.Id = _dbContext.Books.Last().Id + 1;
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public Book GetBookWithMoreComments( )
        {
            var book = _dbContext.Books.OrderByDescending(x => x.Comentarios.Count).First();
            return book;
        }

        public bool Update(Book book)
        {
            if (_dbContext.Books != null && _dbContext.Books.Any())
            {
                var bookUpdate = _dbContext.Books.FirstOrDefault(x => x.Id == book.Id);

                _dbContext.Books.Remove(bookUpdate);
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            
        }

       
    }
}