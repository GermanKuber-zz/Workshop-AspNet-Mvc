using System.Linq;
using ManagerUtn.Entities;
using ManagerUtn.Models;

namespace ManagerUtn.Mapper
{
    public static class BookMapper
    {
        public static Book Map(BookViewModel book)
        {
            var returnData = new Book
            {
                Descripcion = book.Descripcion,
                Id = book.Id,
                Titulo = book.Titulo,
                Image = book.Image,
                Comentarios = book?.Comentarios?.Select(x => new Comment {Comentario = x.Comentario}).ToList()

            };
            return returnData;
        }
    }

    public static class CommentMapper
    {
        public static Comment Map(CommentViewModel comment)
        {
            var returnData = new Comment()
            {
                Comentario = comment.Comentario

            };
            return returnData;
        }
        public static Comment Map(CommentViewModel comment,string userName)
        {
            var returnData = new Comment()
            {
                Comentario = comment.Comentario,
                UserName =  userName

            };
            return returnData;
        }
    }
}