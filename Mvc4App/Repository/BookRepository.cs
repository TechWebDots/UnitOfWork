using Mvc4App.DataAccess;
using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Mvc4App.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }
        public void AddBook(Book bookEntity)
        {
            if (bookEntity != null)
            {
                _context.Books.Add(bookEntity);
            }
        }
        public void UpdateBook(Book bookEntity)
        {
            if (bookEntity != null)
            {
                _context.Entry(bookEntity).State = EntityState.Modified;
            }
        }
        public void DeleteBook(int bookId)
        {
            Book BookEntity = _context.Books.Find(bookId);
            _context.Books.Remove(BookEntity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }  
    }
}