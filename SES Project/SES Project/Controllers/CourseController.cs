using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SES.Domain.Entities;
using SES.Domain.Interfaces;
using SES.Domain.Repositories;

namespace SES_Project.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository courseRepo = new EFCourseRepository();

        public ActionResult List()
        {
            var courses = courseRepo.Courses;
            return View(courses);
        }

        public ActionResult Index(int id)
        {
            var course = courseRepo.Get(id);
            if(course == null)
            {
                return new HttpNotFoundResult();
            }
            return View(course);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}