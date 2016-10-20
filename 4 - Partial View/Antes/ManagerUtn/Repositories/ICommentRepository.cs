using System.Collections.Generic;
using ManagerUtn.Entities;

namespace ManagerUtn.Repositories
{
    public interface ICommentRepository
    {
        Comment Add(Comment comment, int bookId);
        void Dispose();
        List<Comment> GetAll(int idBook);
        Comment GetById(int id);
        Comment Remove(int id, int bookId);
        bool Update(Comment comment);
    }
}