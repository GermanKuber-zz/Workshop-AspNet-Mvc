using System.Collections.Generic;
using ManagerUtn.Entities;

namespace ManagerUtn.Repositories
{
    public interface IBookRepository
    {
        Book Add(Book book);
        List<Book> GetAll();
        Book GetBookWithMoreComments();
        Book GetById(int id);
        Book Remove(Book book);
        Book Remove(int id);
        bool Update(Book book);
        void Dispose();
    }
}