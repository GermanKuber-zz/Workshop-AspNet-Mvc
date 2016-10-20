using System.Collections.Generic;
using System.Linq;
using ManagerUtn.Entities;

namespace ManagerUtn.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Image { get; set; }
        public string Descripcion { get; set; }
        public List<CommentViewModel> Comentarios { get; set; }

        public BookViewModel()
        {

        }

        public BookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Titulo = book.Titulo;
            this.Image = book.Image;
            this.Descripcion = book.Descripcion;

            this.Comentarios = book?.Comentarios?.Select(x => new CommentViewModel(x)).ToList();
        }
    }
}