using System;
using System.Collections.Generic;
using System.Linq;
using ManagerUtn.Entities;
using ManagerUtn.Repositories.Interfaces;

namespace ManagerUtn.Repositories.Memory
{
    public class CommentMemoryRepository : ICommentRepository
    {

        public List<Comment> GetAll(int idBook)
        {
            return DbContext.Books.FirstOrDefault(x => x.Id == idBook)?.Comentarios?.ToList();
        }
        public Comment GetById(int id)
        {
            return DbContext.Books.SelectMany(x => x.Comentarios.Where(s => s.Id == id)).FirstOrDefault();
        }

        Comment Remove(Comment comment, int bookId)
        {
            return RemoveById(comment.Id, bookId);
        }

        private static Comment RemoveById(int id, int bookId)
        {
            if (DbContext.Books != null && DbContext.Books.Count > 0)
            {
                var bookDelete =
                    (DbContext.Books.FirstOrDefault(x => x.Id == bookId)?.Comentarios)
                        .FirstOrDefault(s => s.Id == id);

                DbContext.Books.FirstOrDefault(x => x.Id == bookId)?.Comentarios?.Remove(bookDelete);
                return bookDelete;
            }
            return null;
        }

        public Comment Remove(int id, int bookId)
        {
            return RemoveById(id, bookId);
        }

        public Comment Add(Comment comment, int bookId)
        {
            var book = DbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (book != null)
            {
                if (book.Comentarios == null)
                    book.Comentarios = new List<Comment>();
                var random = new Random();

                comment.Id = random.Next(0, 230);
                book.Comentarios.Add(comment);

            }
            return comment;
        }
        public bool Update(Comment comment)
        {

          

            if (DbContext.Books != null && DbContext.Books.Count > 0)
            {
                var commetUpdate = DbContext.Books.SelectMany(x => x.Comentarios.Where(s => s.Id == comment.Id)).FirstOrDefault();
                var book = DbContext.Books.FirstOrDefault(x => x.Comentarios.Any(s => s.Id == comment.Id));
                book.Comentarios.Remove(commetUpdate);
                book.Comentarios.Add(comment);
                return true;
            }
            return false;
        }

        public void Dispose()
        {

        }


    }
}