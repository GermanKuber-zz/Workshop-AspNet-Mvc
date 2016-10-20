using System.Collections.Generic;
using System.Linq;
using ManagerUtn.Entities;
using ManagerUtn.Repositories.Interfaces;

namespace ManagerUtn.Repositories.Memory
{
    public class BookMemoryRepository : IBookRepository
    {

      public List<Book> GetAll()
        {
            return DbContext.Books.ToList();
        }
        public Book GetById(int id)
        {
            return DbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        Book IBookRepository.Remove(Book book)
        {
            return RemoveById(book.Id);
        }

        private static Book RemoveById(int id)
        {
            if (DbContext.Books != null && DbContext.Books.Count > 0)
            {
                var bookDelete = DbContext.Books.FirstOrDefault(x => x.Id == id);
                DbContext.Books.Remove(bookDelete);
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
            if (DbContext.Books != null && DbContext.Books.Count > 0)
                book.Id = DbContext.Books.Last().Id + 1;
            DbContext.Books.Add(book);
            return book;
        }

        public Book GetBookWithMoreComments( )
        {
            var book = DbContext.Books.OrderByDescending(x => x.Comentarios?.Count()).First();
            return book;
        }

        public bool Update(Book book)
        {
            if (DbContext.Books != null && DbContext.Books.Count > 0)
            {
                var bookUpdate = DbContext.Books.FirstOrDefault(x => x.Id == book.Id);

                DbContext.Books.Remove(bookUpdate);
                DbContext.Books.Add(book);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            
        }

       
    }
}