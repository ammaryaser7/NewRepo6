using mvc_najehacademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_najehacademy.Controllers
{
    public class UserController : Controller
    {
        NajehDB db = new NajehDB();
        // GET: User

        #region Register
        [HttpGet]
        public ActionResult Register()
        {
            if (Session["info"] != null)
            {
                return RedirectToAction("Welcome");
            }
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid) // check all fields validations
                {
                    if (!UserExist(user.Email)== true) // if does not exist
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Login");

                    }
                    else
                    {
                        ModelState.AddModelError("", "By Function- Email is already taken , try another one!");


                    }

                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "By Try -Email is already taken , try another one!");

            }

            return View();
        }

        public bool UserExist(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        #endregion
        //============================

        #region lOGIN
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["info"] != null)
            {
                return RedirectToAction("Welcome");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                var model = db.Users.SingleOrDefault(x => x.Email == user.Email
                  && x.Password == user.Password );
                if (model == null)
                {
                    ViewBag.msgerr = "Please verify Email or Password"; 
                }
                else
                {
                    Session["info"] = model; //pretty sure logged 
                    if (model.Role != null)
                    {
                        return RedirectToAction("index", model.Role.RoleName);
                    }
                    else
                    {
                       return RedirectToAction("Details","Account",new { id= model.ID });
                    }


                }
            }
            return View();
        }



        #endregion

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["info"] = null;

            return RedirectToAction("login");
        }



    }
}