using Mvc4App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4App.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentController()
        {
            _studentRepository = new StudentRepository(new DataAccess.AppDbContext());
        }
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ActionResult Index()
        {
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

    }
}
