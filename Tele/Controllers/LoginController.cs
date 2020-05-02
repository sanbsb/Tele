using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tele.BAL;
using Tele.Models;

namespace Tele.Controllers
{
    public class LoginController : Controller
    {
        UserDAL objdal = new UserDAL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            Int32 val_return = objdal.ValidateLogin(lm);
            string role = objdal.GetRole(lm);
            string message = string.Empty;
            if (val_return == 1)
            {
                if (role == "Admin")
                {
                    return RedirectToAction("Admin","User");
                }
                else if (role == "supervisor")
                {
                    return RedirectToAction("Supervisor", "User");
                }
                else if (role == "agent")
                {
                    return RedirectToAction("Agent", "User", new { @username = lm.UserName });
                }
                else
                {
                    return RedirectToAction("Agent", "User", new { @username = lm.UserName });
                }

            }
            else
            {
                message = "Invalid creditonals";
                ViewBag.Message = message;
                return View("Login");
            }
        }

    }
}