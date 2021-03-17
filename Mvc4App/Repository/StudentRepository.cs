using Mvc4App.DataAccess;
using Mvc4App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Mvc4App.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId);
        }
        public int AddStudent(Student studentEntity)
        {
            int result = -1;

            if (studentEntity != null)
            {
                _context.Students.Add(studentEntity);
                _context.SaveChanges();
                result = studentEntity.Id;
            }
            return result;

        }
        public int UpdateStudent(Student studentEntity)
        {
            int result = -1;

            if (studentEntity != null)
            {
                _context.Entry(studentEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = studentEntity.Id;
            }
            return result;
        }
        public void DeleteStudent(int studentId)
        {
            Student StudentEntity = _context.Students.Find(studentId);
            _context.Students.Remove(StudentEntity);
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