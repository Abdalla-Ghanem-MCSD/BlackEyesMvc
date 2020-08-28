using BlackEyesMvc.Models;
using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
namespace BlackEyesMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private DbContainer db = new DbContainer();
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            Register register = new Register();
            return View(register);
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Register registerInDb = db.register.Where(r => r.UserName == register.UserName).FirstOrDefault();
                    if (registerInDb != null)
                    {
                        ViewBag.SuccsessMessage = "UserName Is Ready Exist";
                        //ModelState.AddModelError("Error", "UserName Is Ready Exist");
                        return View();
                    }
                    db.register.Add(register);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccsessMessage = "Registration Succsess";

                    return RedirectToAction("login", new { message = "Registration Succsess, please login" });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex);
                    throw;
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please Insert UserName - Password");
                return View();
            }
        }

        public ActionResult Login(string? message)
        {
            ViewBag.successMessage = message;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                Register validatUser = db.register.Where(r => r.UserName == login.UserName && r.Password == login.Password).FirstOrDefault();
                if (validatUser == null)
                //if (db.register.Where(r => r.UserName == login.UserName && r.Password == login.Password).FirstOrDefault() == null) 
                {
                    ModelState.AddModelError("Error", "User Name Or Password Not Match");
                }
                else
                {
                    Session["UserName"] = login.UserName;
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            return View();


        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
        }
    }

}

