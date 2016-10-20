using ManagerUtn.Entities;

namespace ManagerUtn.Models
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comentario)
        {
            this.Comentario = comentario.Comentario;
            this.UserName = comentario.UserName;
        }
        public string Comentario { get; set; }
        public string UserName { get; set; }

        public CommentViewModel()
        {
            
        }
    }
}