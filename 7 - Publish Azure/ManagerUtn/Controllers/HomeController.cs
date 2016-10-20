using System.Web.Mvc;
using ManagerUtn.Models;
using ManagerUtn.Repositories.DB;
using ManagerUtn.Repositories.Interfaces;

namespace ManagerUtn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController()
        {
            this._bookRepository = new BookDbRepository();
        }
        public ActionResult Index()
        {
            var book = this._bookRepository.GetBookWithMoreComments();
            var bookModel = new BookViewListModel(book);
            return View(bookModel);
        }

    }
}