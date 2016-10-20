using System.Collections.Generic;

namespace ManagerUtn.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Image { get; set; }
        public string Descripcion { get; set; }
        public List<Comment> Comentarios { get; set; }
    }
}