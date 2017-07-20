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
    public class AdminController : Controller
    {
        private StudentRegContext db = new StudentRegContext();


        public async Task<ActionResult> Login()
        {
            return View(await db.SysAdmins.ToListAsync());
        }
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            return View(await db.SysAdmins.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysAdmin sysAdmin = await db.SysAdmins.FindAsync(id);
            if (sysAdmin == null)
            {
                return HttpNotFound();
            }
            return View(sysAdmin);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AdminName,Password")] SysAdmin sysAdmin)
        {
            if (ModelState.IsValid)
            {
                db.SysAdmins.Add(sysAdmin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sysAdmin);
        }

        // GET: Admin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysAdmin sysAdmin = await db.SysAdmins.FindAsync(id);
            if (sysAdmin == null)
            {
                return HttpNotFound();
            }
            return View(sysAdmin);
        }

        // POST: Admin/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AdminName,Password")] SysAdmin sysAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysAdmin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sysAdmin);
        }

        // GET: Admin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysAdmin sysAdmin = await db.SysAdmins.FindAsync(id);
            if (sysAdmin == null)
            {
                return HttpNotFound();
            }
            return View(sysAdmin);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SysAdmin sysAdmin = await db.SysAdmins.FindAsync(id);
            db.SysAdmins.Remove(sysAdmin);
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
