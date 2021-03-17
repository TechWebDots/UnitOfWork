using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4App.Repository
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void AddBook(Book bookEntity);
        void UpdateBook(Book bookEntity);
        void DeleteBook(int bookId);
        void Save();
    }
}