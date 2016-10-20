using ManagerUtn.Entities;

namespace ManagerUtn.Models
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comentario)
        {
            this.Comentario = comentario.Comentario;
        }
        public string Comentario { get; set; }

        public CommentViewModel()
        {
            
        }
    }
}