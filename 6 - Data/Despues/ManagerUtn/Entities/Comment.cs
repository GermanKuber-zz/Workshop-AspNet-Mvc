using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerUtn.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Comentario { get; set; }
        [Required]
        public string UserName { get; set; }
        public int BookId { get; set; }
    }

}