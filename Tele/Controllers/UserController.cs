using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tele.BAL;
using Tele.Models;

namespace Tele.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserDAL objdal = new UserDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User objuser)
        {
            objdal.Registration(objuser);
            ViewBag.Message = "You have successfully created new account";
            return RedirectToAction("Login","Login");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(User changepass)
        {
            objdal.ResetPassword(changepass);
            return RedirectToAction("Login", "Login");
        }
        public ActionResult IsUserNameAvailable(string UserName)
        {
            try
            {
                bool userexist = false;
                User obj = new User();
                obj.UserName = UserName;
                Int32 count = objdal.CheckUserNameExistence(obj);
                if (count < 1)
                {
                    userexist = false;
                }
                else
                {
                    userexist = true;
                }
                return Json(!userexist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult IsPasswordAvailable(string Password)
        {
            try
            {
                bool passwordexist = false;
                User obj = new User();
                obj.Password = Password;
                Int32 count = objdal.CheckPasswordExistence(obj);
                if (count < 1)
                {
                    passwordexist = false;
                }
                else
                {
                    passwordexist = true;
                }
                return Json(!passwordexist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Agent(User obj,string username)
        {
            User obj2 = new User();
            string action = "Agent";
            obj2.userList = objdal.GetUserList(obj, action,username);
            return View(obj2);
        }
        public ActionResult Admin(User obj)
        {
            User obj2 = new User();
            string action = "Admin";
            obj2.userList = objdal.GetUserList(obj, action,"");
            return View(obj2);
        }
        public ActionResult Supervisor(User obj)
        {
            User obj2 = new User();
            string action = "Supervisor";
            obj2.userList = objdal.GetUserList(obj, action, "");
            return View(obj2);
        }
        public ActionResult EditUser(string UserName) // 
        {
            try
            {
                User Objuser = new User();
                string action = "Agent";
                Objuser = objdal.GetUserDetails(Objuser, action, UserName);
                //return RedirectToAction("Registration", "User",Objuser);
                return View("EditUser", Objuser);
            }
            catch (Exception exp)
            {
                return View("Error");
            }

        }
        [HttpPost]
        public ActionResult EditUser(User userupdate) // 
        {
            try
            {
                User Objuser = new User();
                Objuser = objdal.UpdateUserDetails(userupdate);
                //return RedirectToAction("Registration", "User",Objuser);
                return RedirectToAction("Login", "Login");
            }
            catch (Exception exp)
            {
                return View("Error");
            }

        }
        public ActionResult EditUserForSupervisor(string UserName) // 
        {
            try
            {
                User Objuser = new User();
                string action = "Agent";
                Objuser = objdal.GetUserDetails(Objuser, action, UserName);
                //return RedirectToAction("Registration", "User",Objuser);
                return View("EditUser", Objuser);
            }
            catch (Exception exp)
            {
                return View("Error");
            }

        }
        [HttpPost]
        public ActionResult EditUserForSupervisor(User userupdate) // 
        {
            try
            {
                User Objuser = new User();
                Objuser = objdal.UpdateUserDetails(userupdate);
                //return RedirectToAction("Registration", "User",Objuser);
                return RedirectToAction("Login", "Login");
            }
            catch (Exception exp)
            {
                return View("Error");
            }

        }
    }
}