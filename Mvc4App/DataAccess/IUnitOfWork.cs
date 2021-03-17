using Mvc4App.GenericRepository;
using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4App.DataAccess
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        void Save();
    }
}