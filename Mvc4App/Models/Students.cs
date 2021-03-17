using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc4App.Models
{ 
    public class Student
    {        
        public int Id { get; set; }        
        public string Name { get; set; }       
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}