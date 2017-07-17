using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModels;
using InitDatabase;

namespace Register_Online.Controllers
{
    public class StudentsController : Controller
    {
        private StudentRegContext db = new StudentRegContext();

        // GET: Students
        public async Task<ActionResult> Index()
        {
            var students = db.Students.Include(s => s.Acc).Include(s => s.Category).Include(s => s.Nation).Include(s => s.Specialty);
            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.StudentAccId = new SelectList(db.StudentAccs, "StudentAccId", "StuAcc");
            ViewBag.CategoryId = new SelectList(db.Period_Categorys, "Id", "CategoryName");
            ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName");
            ViewBag.SpecialtyId = new SelectList(db.Specialtys, "SpecialtyId", "SpecialtyName");
            return View();
        }

        // POST: Students/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,CardNumber,StudentName,Sex,NationId,Birthday,NativePlace,TelNumber,SchoolName,Adress,ZipCode,Patriarch,Pat_Telnum,Mandator,UnifiedScore,TotalPoints,PicUrl,SpecialtyId,CategoryId,StudentAccId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StudentAccId = new SelectList(db.StudentAccs, "StudentAccId", "StuAcc", student.StudentAccId);
            ViewBag.CategoryId = new SelectList(db.Period_Categorys, "Id", "CategoryName", student.CategoryId);
            ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName", student.NationId);
            ViewBag.SpecialtyId = new SelectList(db.Specialtys, "SpecialtyId", "SpecialtyName", student.SpecialtyId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentAccId = new SelectList(db.StudentAccs, "StudentAccId", "StuAcc", student.StudentAccId);
            ViewBag.CategoryId = new SelectList(db.Period_Categorys, "Id", "CategoryName", student.CategoryId);
            ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName", student.NationId);
            ViewBag.SpecialtyId = new SelectList(db.Specialtys, "SpecialtyId", "SpecialtyName", student.SpecialtyId);
            return View(student);
        }

        // POST: Students/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,CardNumber,StudentName,Sex,NationId,Birthday,NativePlace,TelNumber,SchoolName,Adress,ZipCode,Patriarch,Pat_Telnum,Mandator,UnifiedScore,TotalPoints,PicUrl,SpecialtyId,CategoryId,StudentAccId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudentAccId = new SelectList(db.StudentAccs, "StudentAccId", "StuAcc", student.StudentAccId);
            ViewBag.CategoryId = new SelectList(db.Period_Categorys, "Id", "CategoryName", student.CategoryId);
            ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName", student.NationId);
            ViewBag.SpecialtyId = new SelectList(db.Specialtys, "SpecialtyId", "SpecialtyName", student.SpecialtyId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
