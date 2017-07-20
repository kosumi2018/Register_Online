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
using X.PagedList;
using X.PagedList.Mvc;
using Register_Online.Filters;

namespace Register_Online.Controllers
{
    public class StudentController : Controller
    {
        private StudentRegContext db = new StudentRegContext();

        // GET: Student
        [Admin]
        public async Task<ActionResult> Index(int id = 1, int page = 1)
        {
            ViewBag.XZ = db.Period_Categorys.ToList();
            ViewBag.NZMC = DateTime.Now.Year.ToString() + db.Period_Categorys.Find(id).CategoryName + "报名学生名单";

            const int pageSize = 20;
            var students = db.Students.Where(s => s.Period_CategoryId == id && s.Time.Year == DateTime.Now.Year).Include(s => s.StudentAcc).Include(s => s.Nation).Include(s => s.Specialty).OrderBy(s => s.StudentId).ToPagedListAsync(page, pageSize);
            return View(await students);
        }
        // GET: Student/Details/5
        [Student]
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
            if (Convert.ToBoolean(Session["Student"]))
            {
                string myacc = Session["Acc"].ToString();
                Student MyInfo = await db.Students.Where(s => s.StudentAcc.StuAcc == myacc).FirstOrDefaultAsync();
                if (id != MyInfo.StudentId) return RedirectToAction("Index", "Home");
                int nationId = MyInfo.NationId;
                int period_CategoryId = MyInfo.Period_CategoryId;
                int specialtyId = MyInfo.SpecialtyId;
                ViewBag.NationName = db.Nations.Find(nationId).NationName;
                ViewBag.CategoryName = db.Period_Categorys.Find(period_CategoryId).CategoryName;
                ViewBag.specialtyName = db.Specialtys.Find(specialtyId).SpecialtyName;
            }
            else
            {
                if (!Convert.ToBoolean(Session["Admin"])) return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        // GET: Student/Create //五年制大专报名
        [Student]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["Acc"] != null)
            {
                string myacc = Session["Acc"].ToString();
                ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName");
                ViewBag.SpecialtyId = new SelectList(db.Specialtys.Where(s => s.Period_CategoryId == id), "SpecialtyId", "SpecialtyName");
                ViewBag.Id = id;
                ViewBag.CategoryName = db.Period_Categorys.Find(id).CategoryName;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Student/Create //五年制大专报名
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [Student]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,CardNumber,StudentName,Sex,NationId,Birthday,CNumber,NativePlace,TelNumber,SchoolName,Adress,ZipCode,Patriarch,Pat_Telnum,Mandator,UnifiedScore,TotalPoints,SpecialtyId,Period_CategoryId,StudentAccId")] Student student)
        {
            if (Session["Acc"] != null)
            {
                string myacc = Session["Acc"].ToString();
                if (ModelState.IsValid)
                {
                    student.Period_CategoryId = 1;
                    StudentAcc sacc = await db.StudentAccs.Where(s => s.StuAcc == myacc).FirstOrDefaultAsync();

                    student.StudentAccId = sacc.StudentAccId;
                    student.Time = DateTime.Now;
                    db.Students.Add(student);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName", student.NationId);
                ViewBag.SpecialtyId = new SelectList(db.Specialtys.Where(s => s.Period_CategoryId == 1), "SpecialtyId", "SpecialtyName", student.SpecialtyId);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(student);
        }

        // GET: Student/Edit/5 //五年制大专
        [Student]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Student student = await db.Students.FindAsync(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            if (Session["Acc"] != null)
            {
                string myacc = Session["Acc"].ToString();
                Student MyInfo = await db.Students.Where(s => s.StudentAcc.StuAcc == myacc).FirstOrDefaultAsync();
                if (id != MyInfo.StudentId) return RedirectToAction("Index", "Home");
                //专业学制类型编号=学制名称编号
                int categoryid = MyInfo.Period_CategoryId;

                //学制名称
                ViewBag.CategoryName = db.Period_Categorys.Find(categoryid).CategoryName;
                //ViewBag.StudentAccId = new SelectList(db.StudentAccs, "StudentAccId", "StuAcc", student.StudentAccId);
                //56个名族
                ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName", student.NationId);
                //所在学制的专业列表
                ViewBag.SpecialtyId = new SelectList(db.Specialtys.Where(s => s.Period_CategoryId == categoryid), "SpecialtyId", "SpecialtyName");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(student);
        }

        // POST: Student/Edit/5 //五年制大专
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [Student]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,CardNumber,StudentName,Sex,NationId,Birthday,CNumber,NativePlace,TelNumber,SchoolName,Adress,ZipCode,Patriarch,Pat_Telnum,Mandator,UnifiedScore,TotalPoints,SpecialtyId,Period_CategoryId,StudentAccId")] Student student)
        {
            if (ModelState.IsValid)
            {
                int id = student.StudentId;
                student.Time = DateTime.Now;
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Redirect("~/Student/Details/" + id + "");
            }
            else
            {
                string myacc = Session["Acc"].ToString();
                Student MyInfo = await db.Students.Where(s => s.StudentAcc.StuAcc == myacc).FirstOrDefaultAsync();

                //专业学制类型编号=学制名称编号
                int categoryid = MyInfo.Period_CategoryId;

                //学制名称
                ViewBag.CategoryName = db.Period_Categorys.Find(categoryid).CategoryName;
                //ViewBag.StudentAccId = new SelectList(db.StudentAccs, "StudentAccId", "StuAcc", student.StudentAccId);
                //56个名族
                ViewBag.NationId = new SelectList(db.Nations, "NationId", "NationName", student.NationId);
                //所在学制的专业列表
                ViewBag.SpecialtyId = new SelectList(db.Specialtys.Where(s => s.Period_CategoryId == categoryid), "SpecialtyId", "SpecialtyName");
            }

            return View(student);
        }

        // GET: Student/Delete/5
        [Admin]
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

            int nationId = student.NationId;
            int period_CategoryId = student.Period_CategoryId;
            int specialtyId = student.SpecialtyId;
            int accid = student.StudentAccId;
            ViewBag.NationName = db.Nations.Find(nationId).NationName;
            ViewBag.CategoryName = db.Period_Categorys.Find(period_CategoryId).CategoryName;
            ViewBag.specialtyName = db.Specialtys.Find(specialtyId).SpecialtyName;
            ViewBag.Acc = db.StudentAccs.Find(accid).StuAcc;

            return View(student);
        }

        // POST: Student/Delete/5
        [Admin]
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
