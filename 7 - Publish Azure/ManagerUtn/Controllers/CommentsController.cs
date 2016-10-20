using System.Web.Mvc;
using ManagerUtn.Entities;
using ManagerUtn.Mapper;
using ManagerUtn.Models;
using ManagerUtn.Repositories.DB;
using ManagerUtn.Repositories.Interfaces;

namespace ManagerUtn.Controllers
{

    public class CommentsController : Controller
    {
    

        private readonly ICommentRepository _commentRepository;
        private readonly IBookRepository _bookRepository;
        public CommentsController()
        {
            this._commentRepository = new CommentDbRepository();
            this._bookRepository = new BookDbRepository();
        }

        [HttpGet]
        [Route("comments/create/{bookId}")]
        [Authorize]
        public ActionResult Create(int bookId)
        {
            var book = VerifyData(bookId);
            if (book == null)
                return HttpNotFound("El Id bo corresponde a un Book");

         

            return View(new CommentViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("comments/create/{bookId}")]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Comentario")] CommentViewModel comment, int bookId)
        {
            if (ModelState.IsValid)
            {
       
                _commentRepository.Add(CommentMapper.Map(comment,User.Identity.Name),bookId);

                var book = VerifyData(bookId);
                if (book == null)
                    return HttpNotFound("El Id bo corresponde a un Book");

                return RedirectToAction("Create","Comments",new { bookId  = bookId});
            }

            return View();
        }


        private Book VerifyData(int bookId)
        {
            var book = this._bookRepository.GetById(bookId);
            ViewBag.Book = new BookViewModel(book);
            return book;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
            base.Dispose(disposing);
        }
    }
}
