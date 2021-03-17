using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4App.Repository
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        int AddStudent(Student studentIdEntity);
        int UpdateStudent(Student studentIdEntity);
        void DeleteStudent(int studentId);  
    }
}