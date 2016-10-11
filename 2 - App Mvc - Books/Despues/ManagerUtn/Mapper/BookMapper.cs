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
                Comentarios = book?.Comentarios.Select(x => new Comment {Comentario = x.Comentario}).ToList()

            };
            return returnData;
        }
    }
}