using Mvc4App.DataAccess;
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
        //private IStudentRepository _studentRepository;
        private IUnitOfWork unitOfWork;

        //public StudentController()
        //{
        //    _studentRepository = new StudentRepository(new DataAccess.AppDbContext());
        //}
        public StudentController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public ActionResult Index()
        {
            var model = unitOfWork.StudentRepository.GetAll();
            return View(model);
        }

    }
}
