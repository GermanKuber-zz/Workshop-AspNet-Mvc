using System.Web.Mvc;
using ManagerUtn.Models;
using ManagerUtn.Repositories;

namespace ManagerUtn.Controllers
{
    public class HomeController : Controller
    {
        private BookRepository _bookRepository;

        public HomeController()
        {
            this._bookRepository = new BookRepository();
        }
        public ActionResult Index()
        {
            var book = this._bookRepository.GetBookWithMoreComments();
            var bookModel = new BookViewListModel(book);
            return View(bookModel);
        }

    }
}