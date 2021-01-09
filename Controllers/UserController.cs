using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RCCClinic.Models;

namespace RCCClinic.Controllers
{
    public class UserController : Controller
    {
        ClinicDB db = new ClinicDB();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        #region Register


        [HttpGet] // Request form at first time
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost] // send data over http to server 
        public ActionResult Register(User user) // user input from
        {

            try
            {
                if (ModelState.IsValid)
                {

                    if (!UserExist(user.Email))
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "user already registered!");
                    }

                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("", e.Message);
            }

            return View();
        }

        #endregion


        #region Login

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["info"] != null)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)// comes from input textbox
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                var userrow = db.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (userrow != null)
                {
                    Session["info"] = userrow;
                    return RedirectToAction("index", "Patients"); // redirect to another view
                }
                else
                {
                    ModelState.AddModelError("", "Please verify Email or password");
                }
            }

            return View();
        }




        #endregion


        public ActionResult Signout()
        {
            Session["info"] = null;
            return RedirectToAction("Login", "user");
        }











        public bool UserExist(string Email)// comes from textbox input
        {
            return db.Users.Count(x => x.Email == Email) > 0;
        }
    }
}