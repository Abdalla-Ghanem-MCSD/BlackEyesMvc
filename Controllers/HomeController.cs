using BlackEyesMvc.Migrations;
using BlackEyesMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Login = BlackEyesMvc.Migrations.Login;

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
                if (!db.register.Any(r => r.UserName == register.UserName))
                {

                    db.register.Add(register);
                    db.SaveChanges();
                    ViewBag.SuccsessMessage = "Register Succsess";
                    ModelState.Clear();
                    return View();

                }
                else
                {
                    ModelState.AddModelError("Error", "Email Is Ready Exist");
                    return View();
                }
                
            }
     
            return View();
    }

    
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var validatUser = db.register.Where(r => r.UserName == login.UserName && r.Password == login.Password).FirstOrDefault();
                if (validatUser != null)
                //if (db.register.Where(r => r.UserName == login.UserName && r.Password == login.Password).FirstOrDefault() == null) 
                {
                  ModelState.AddModelError("Error", "User Name Or Password Not Match");

                    return View();
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
    
