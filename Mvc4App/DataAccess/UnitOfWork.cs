using Mvc4App.DataAccess;
using Mvc4App.GenericRepository;
using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4App.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context = new AppDbContext();
        public IGenericRepository<Book> bookRepository;
        public IGenericRepository<Student> studentRepository;

        public IGenericRepository<Book> BookRepository
        {
            get
            {

                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(_context);
                }
                return bookRepository;
            }
        }

        public IGenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(_context);
                }
                return studentRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
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
    }
}