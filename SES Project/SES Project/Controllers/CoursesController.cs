using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SES.Domain.DatabaseContext;
using SES.Domain.Entities;
using SES.Domain.Repositories;

namespace SES_Project.Controllers
{
    public class CoursesController : Controller
    {
        //private EFDBContext db = new EFDBContext();
        private EFCourseRepository courseRepo = new EFCourseRepository();

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            return View(await courseRepo.GetAllAsync());
        }

        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await courseRepo.GetByIdAsync(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Code,Name,Description,Duration,DurationUnit,Price,Type,Venue,IsActive,IsPublicVisible")] Course course)
        {
            if (ModelState.IsValid)
            {
                course.Created = DateTime.Now;
                await courseRepo.CreateAsync(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await courseRepo.GetByIdAsync(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Code,Name,Description,Duration,DurationUnit,Price,Type,Venue,IsActive,IsPublicVisible")] Course course)
        {
            if (ModelState.IsValid)
            {
                await courseRepo.UpdateAsync(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await courseRepo.GetByIdAsync(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Course course = await courseRepo.GetByIdAsync(id);
            await courseRepo.DeleteAsync(course);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courseRepo.DisposeDbContext();
            }
            base.Dispose(disposing);
        }
    }
}
