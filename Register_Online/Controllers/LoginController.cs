using DataModels;
using InitDatabase;
using MyTools;
using Register_Online.Filters;
using Register_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register_Online.Controllers
{
    public class LoginController : Controller
    {
        private StudentRegContext db = new StudentRegContext();

        public ActionResult Loginout()
        {
            Session["Acc"] = null;
            Session["Admin"] = false;
            Session["Student"] = false;
            return RedirectToAction("Index", "Home");
        }
        //学生
        public ActionResult Student_Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Student_Login([Bind(Include = "Account,Password,Codeimg")]  LoginView studentLogin)
        {
            if (studentLogin.Codeimg != Session["ValidateCode"].ToString())
            {
                ModelState.AddModelError("", "验证码不正确");
                return View(studentLogin);
            }
            if (ModelState.IsValid)
            {
                string pwd = Tools.MD5Encrypt32(studentLogin.Password);
                var studentacc = db.StudentAccs.Where(s => s.StuAcc == studentLogin.Account && s.Password == pwd).FirstOrDefault();
                if (studentacc != null)
                {
                    Session["Acc"] = studentacc.StuAcc;
                    Session["Student"] = true;
                    int id = studentacc.StudentAccId;
                    return Redirect("~/Student/Details/" + id);
                }
            }
            else
            {
                ModelState.AddModelError("", "用户名或密码不正确");
            }
            return View();
        }
        //学生注册用户
        public ActionResult Student_Reg()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Student_Reg([Bind(Include = "Acc,Password,Checkpwd,Codeimg")] Register regmodel)
        {
            if (regmodel.Codeimg != Session["ValidateCode"].ToString())
            {
                ModelState.AddModelError("", "验证码不正确");
                return View(regmodel);
            }
            if (ModelState.IsValid)
            {
                string pwd = Tools.MD5Encrypt32(regmodel.Password);
                string acc = regmodel.Acc;

                try
                {
                    var sacc = db.StudentAccs.Where(s => s.StuAcc == acc).FirstOrDefault();

                    if (sacc == null)
                    {
                        StudentAcc stuacc = new StudentAcc { StuAcc = acc, Password = pwd, Time=DateTime.Now };
                        try
                        {
                            db.Configuration.ValidateOnSaveEnabled = false;
                            db.Configuration.AutoDetectChangesEnabled = false;
                            db.StudentAccs.Add(stuacc);
                            db.SaveChanges();
                            Session["Acc"] = stuacc.StuAcc;
                            Session["Student"] = true;
                            return RedirectToAction("Index", "Home");
                        }
                        catch (Exception e)
                        {
                            Response.Write(e.Message);
                        }
                        finally
                        {
                            db.Configuration.ValidateOnSaveEnabled = true;
                            db.Configuration.AutoDetectChangesEnabled = true;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名已经存在！');</script>");
                    }
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }
            }
            return View();
        }
        //管理员
        public ActionResult Admin_Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Admin_Login([Bind(Include = "Account,Password,Codeimg")]  AdminLoginView AdminLogin)
        {
            if (AdminLogin.Codeimg != Session["ValidateCode"].ToString())
            {
                ModelState.AddModelError("", "验证码不正确");
                return View(AdminLogin);
            }

            if (ModelState.IsValid)
            {
                string pwd = Tools.MD5Encrypt32(AdminLogin.Password);
                var adminacc = db.SysAdmins.Where(s => s.AdminName == AdminLogin.Account && s.Password == pwd).FirstOrDefault();
                if (adminacc != null)
                {
                    Session["Acc"] = adminacc.AdminName;
                    Session["Admin"] = true;
                    //int id = adminacc.Id;
                    return Redirect("~/Student/Index/");
                }
            }
            else
            {
                ModelState.AddModelError("", "用户名或密码不正确");
            }
            return View();
        }
       
        
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns>验证码图片</returns>
        [AllowAnonymous]
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}