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
using Register_Online.Filters;

namespace Register_Online.Controllers
{
    [Admin]
    public class SpecialtiesController : Controller
    {
        private StudentRegContext db = new StudentRegContext();

        // GET: Specialties
        public async Task<ActionResult> Index()
        {
            var specialtys = db.Specialtys.Include(s => s.Period_Category);
            return View(await specialtys.ToListAsync());
        }

        // GET: Specialties/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialty specialty = await db.Specialtys.FindAsync(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        // GET: Specialties/Create
        public ActionResult Create()
        {
            ViewBag.Period_CategoryId = new SelectList(db.Period_Categorys, "Period_CategoryId", "CategoryName");
            return View();
        }

        // POST: Specialties/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SpecialtyId,SpecialtyName,Period_CategoryId,Tuition")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                db.Specialtys.Add(specialty);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Period_CategoryId = new SelectList(db.Period_Categorys, "Period_CategoryId", "CategoryName", specialty.Period_CategoryId);
            return View(specialty);
        }

        // GET: Specialties/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialty specialty = await db.Specialtys.FindAsync(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            ViewBag.Period_CategoryId = new SelectList(db.Period_Categorys, "Period_CategoryId", "CategoryName", specialty.Period_CategoryId);
            return View(specialty);
        }

        // POST: Specialties/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SpecialtyId,SpecialtyName,Period_CategoryId,Tuition")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialty).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Period_CategoryId = new SelectList(db.Period_Categorys, "Period_CategoryId", "CategoryName", specialty.Period_CategoryId);
            return View(specialty);
        }

        // GET: Specialties/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialty specialty = await db.Specialtys.FindAsync(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        // POST: Specialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Specialty specialty = await db.Specialtys.FindAsync(id);
            db.Specialtys.Remove(specialty);
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
