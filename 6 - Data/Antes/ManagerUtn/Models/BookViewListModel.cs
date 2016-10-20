using System.Linq;
using ManagerUtn.Entities;

namespace ManagerUtn.Models
{
    public class BookViewListModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Image { get; set; }
        public string Descripcion { get; set; }
        public int CountComentarios { get; set; } = 0;

        public BookViewListModel()
        {

        }

        public BookViewListModel(Book book)
        {
            Id = book.Id;
            Titulo = book.Titulo;
            Image = book.Image;
            Descripcion = book.Descripcion;
            if (book.Comentarios != null)
                CountComentarios = book.Comentarios.Count();
        }
    }
}