using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc4App.DataAccess
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext() : base("DefaultConnection") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}