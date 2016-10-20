using System.Web.Mvc;
using ManagerUtn.Entities;
using ManagerUtn.Mapper;
using ManagerUtn.Models;
using ManagerUtn.Repositories;

namespace ManagerUtn.Controllers
{

    public class CommentsController : Controller
    {
    

        private ICommentRepository _commentRepository;
        private IBookRepository _bookRepository;
        public CommentsController()
        {
            this._commentRepository = new CommentRepository();
            this._bookRepository = new BookRepository();
        }

        [HttpGet]
        [Route("comments/create/{bookId}")]
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
        public ActionResult Create([Bind(Include = "Id,Comentario")] CommentViewModel comment, int bookId)
        {
            if (ModelState.IsValid)
            {
          
                _commentRepository.Add(CommentMapper.Map(comment),bookId);

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
