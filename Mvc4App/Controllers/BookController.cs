using Mvc4App.DataAccess;
using Mvc4App.Models;
using Mvc4App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4App.Controllers
{
    public class BookController : Controller
    {
        //private IBookRepository _bookRepository;
        ///private UnitOfWork unitOfWork = new UnitOfWork();
        private IUnitOfWork unitOfWork;

        //public BookController()
        //{
        //    _bookRepository = new BookRepository(new DataAccess.AppDbContext());
        //}
        //public BookController(IBookRepository bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}

        public BookController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public ActionResult Index()
        {            
            //var model = _bookRepository.GetAllBooks();
            var model = unitOfWork.BookRepository.GetAll();
            return View(model);
        }
        public ActionResult AddBook()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Book Failed";
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.BookRepository.Insert(book);
                    unitOfWork.Save();
                    //_bookRepository.AddBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }     
            catch (Exception ex)
            {
                //Log the error
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                TempData["Failed"] = "Failed";                
            }
            return View(book);
            //return RedirectToAction("AddBook", "Book");
        }
        public ActionResult EditBook(int BookId)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Book Failed";
            }
            Book book = unitOfWork.BookRepository.GetById(BookId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(book);
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.BookRepository.Update(book);
                    unitOfWork.Save();
                    //_bookRepository.UpdateBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the error
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                TempData["Failed"] = "Failed";                
            }
            return View(book);
        }
        public ActionResult DeleteBook(bool? saveChangesError = false, int BookId=0)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Book Failed";
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Book book = unitOfWork.BookRepository.GetById(BookId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(book);
        }
        [HttpPost]
        public ActionResult DeleteBook(Book book)
        {
            try
            {
                //_bookRepository.DeleteBook(book.BookId);
                //_bookRepository.Save();
                unitOfWork.BookRepository.Delete(book.BookId);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                TempData["Failed"] = "Delete Book Failed";
                //Log the error
                return RedirectToAction("Delete", new { id = book.BookId, saveChangesError = true });                
            }
                       
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            //_bookRepository.Dispose();
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
