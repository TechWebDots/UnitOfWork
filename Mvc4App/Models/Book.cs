using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc4App.Models
{ 
    public class Book
    {        
        public int BookId { get; set; }        
        public string BookTitle { get; set; }       
        public string Standard { get; set; }       
        public string Subject { get; set; }       
        public string Author { get; set; }
    }
}