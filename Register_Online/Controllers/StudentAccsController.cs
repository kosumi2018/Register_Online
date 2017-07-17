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
    public class StudentAccsController : Controller
    {
        private StudentRegContext db = new StudentRegContext();

        // GET: StudentAccs
        public async Task<ActionResult> Index()
        {
            return View(await db.StudentAccs.ToListAsync());
        }

        // GET: StudentAccs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAcc studentAcc = await db.StudentAccs.FindAsync(id);
            if (studentAcc == null)
            {
                return HttpNotFound();
            }
            return View(studentAcc);
        }

        // GET: StudentAccs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentAccs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentAccId,StuAcc,Password")] StudentAcc studentAcc)
        {
            if (ModelState.IsValid)
            {
                db.StudentAccs.Add(studentAcc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(studentAcc);
        }

        // GET: StudentAccs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAcc studentAcc = await db.StudentAccs.FindAsync(id);
            if (studentAcc == null)
            {
                return HttpNotFound();
            }
            return View(studentAcc);
        }

        // POST: StudentAccs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentAccId,StuAcc,Password")] StudentAcc studentAcc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAcc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studentAcc);
        }

        // GET: StudentAccs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAcc studentAcc = await db.StudentAccs.FindAsync(id);
            if (studentAcc == null)
            {
                return HttpNotFound();
            }
            return View(studentAcc);
        }

        // POST: StudentAccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentAcc studentAcc = await db.StudentAccs.FindAsync(id);
            db.StudentAccs.Remove(studentAcc);
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
