using DataModels;
using InitDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register_Online.Controllers
{
    public class HomeController : Controller
    {
        private StudentRegContext db = new StudentRegContext();
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["Student"]))
            {
                string acc = Session["Acc"].ToString();
                Student student =  db.Students.Where(s=>s.StudentAcc.StuAcc==acc).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.list = db.Period_Categorys.ToList();
                }
                return View(student);
            }
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}