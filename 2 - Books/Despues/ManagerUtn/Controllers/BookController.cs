using System.Collections.Generic;
using System.Web.Mvc;
using ManagerUtn.Entities;
using ManagerUtn.Models;
using ManagerUtn.Repositories;

namespace ManagerUtn.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository BookRepository { get; }
        public BookController()
        {
            this.BookRepository = new BookRepository();
        }

        public ActionResult Index()
        {
            var books = BookRepository.GetAll();
            var returnBook = new List<BookViewModel>();
            if (books != null)
            {
                foreach (var item in books)
                {
                    returnBook.Add(new BookViewModel(item));
                }
            }

            return View(returnBook);
        }

  
        public ActionResult Details(int id)
        {
            Book book = BookRepository.GetById(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(new BookViewModel(book));
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descripcion")] Book book)
        {
            if (ModelState.IsValid)
            {
                BookRepository.Add(book);
                
                return RedirectToAction("Index");
            }

            return View(new BookViewModel(book));
        }


        public ActionResult Edit(int id)
        {
            Book book = BookRepository.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(new BookViewModel(book));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descripcion")] Book book)
        {
            if (ModelState.IsValid)
            {
                BookRepository.Update(book);
                return RedirectToAction("Index");
            }
            return View(new BookViewModel(book));
        }

        public ActionResult Delete(int id)
        {
            Book book = BookRepository.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(new BookViewModel(book));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            BookRepository.Remove(id);
       
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BookRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
