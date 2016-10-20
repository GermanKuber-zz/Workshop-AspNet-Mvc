using System;
using System.Collections.Generic;
using System.Linq;
using ManagerUtn.Entities;
using ManagerUtn.Models;
using ManagerUtn.Repositories.Interfaces;

namespace ManagerUtn.Repositories.DB
{
    public class CommentDbRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentDbRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
        public List<Comment> GetAll(int idBook)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == idBook)?.Comentarios?.ToList();
        }
        public Comment GetById(int id)
        {
            return _dbContext.Books.SelectMany(x => x.Comentarios.Where(s => s.Id == id)).FirstOrDefault();
        }

        Comment Remove(Comment comment, int bookId)
        {
            return RemoveById(comment.Id, bookId);
        }

        private  Comment RemoveById(int id, int bookId)
        {
            if (_dbContext.Books != null && _dbContext.Books.Any())
            {
                var bookDelete =
                    (_dbContext.Books.FirstOrDefault(x => x.Id == bookId)?.Comentarios)
                        .FirstOrDefault(s => s.Id == id);

                _dbContext.Books.FirstOrDefault(x => x.Id == bookId)?.Comentarios?.Remove(bookDelete);
                _dbContext.SaveChanges();
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
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (book != null)
            {
                if (book.Comentarios == null)
                    book.Comentarios = new List<Comment>();
                var random = new Random();

                comment.Id = random.Next(0, 230);
                book.Comentarios.Add(comment);
                _dbContext.SaveChanges();

            }
            return comment;
        }
        public bool Update(Comment comment)
        {

          

            if (_dbContext.Books != null && _dbContext.Books.Any())
            {
                var commetUpdate = _dbContext.Books.SelectMany(x => x.Comentarios.Where(s => s.Id == comment.Id)).FirstOrDefault();
                var book = _dbContext.Books.FirstOrDefault(x => x.Comentarios.Any(s => s.Id == comment.Id));
                book.Comentarios.Remove(commetUpdate);
                book.Comentarios.Add(comment);
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