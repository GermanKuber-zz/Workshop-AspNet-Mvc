using ManagerUtn.Entities;

namespace ManagerUtn.Models
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comentario)
        {
            Comentario = comentario.Comentario;
            UserName = comentario.UserName;
        }
        public string Comentario { get; set; }
        public string UserName { get; set; }

        public CommentViewModel()
        {
            
        }
    }
}