using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerUtn.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public virtual ICollection<Comment> Comentarios { get; set; }
    }
}