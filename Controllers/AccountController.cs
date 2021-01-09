using mvc_najehacademy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_najehacademy.Controllers
{
    public class AccountController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["info"] == null)
            {
               // Response.Redirect("~/user/login");
            }

        }



        NajehDB db = new NajehDB();
      
        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return RedirectToAction("Welcome", "User");
            }
            var model = db.Accounts.Find(id);
            if (model == null)
            {
                return RedirectToAction("Create");
            }

            return View(model);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Image,Account account) // from URL >> Form body
        {
            try
            {
                if (ModelState.IsValid)
                {
                    account.ID = ((User)Session["info"]).ID;
                    if (Image != null )
                    {
                        // video video/3gp , video/avi , video/mp4
                        // audio  audio/mp3 , audio/wav
                        // word   "application/ms-word"       
                        // PDF Application/pdf 

                        if (Image.ContentType.ToLower() == "image/jpeg" || 
                            Image.ContentType.ToLower() == "image/png")
                        {
                            string extension = Path.GetExtension(Image.FileName);
                            var gg = Guid.NewGuid();
                            //save to images folder
                            Image.SaveAs(Server.MapPath("/Images/" + gg + extension));
                            //---------------------------------------
                            // save image name to DB
                            account.Image = gg + extension;
                            db.Accounts.Add(account);
                            db.SaveChanges();
                            return RedirectToAction("Details", new { id = account.ID });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Extension file with jpeg only");
                           
                        }
                    }

                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Accounts.Find(id);

            return View(model);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase Image,Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    if (Image != null)
                    {   
                        if (Image.ContentType.ToLower() == "image/jpeg"
                            || Image.ContentType.ToLower() == "image/png")
                        {
                            string extension = Path.GetExtension(Image.FileName);
                            var gg = Guid.NewGuid();
                            //save to images folder
                            Image.SaveAs(Server.MapPath("/Images/" + gg + extension));
                            //---------------------------------------
                            // save image name to DB
                            account.Image = gg + extension; 
                        }
                        else
                        {
                            ModelState.AddModelError("", "Extension file with jpeg only");

                        }
                    }
                    db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Session["info"] = db.Users.Find(account.ID);


                }

                return RedirectToAction("Details", new { id = account.ID });


            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete()
        {
            var model = db.Accounts.Find(((User)Session["info"]).ID);
            return View(model);
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ActionName("Delete")] // Confirm Delete
        public ActionResult Delete(Account account)
        {
            try
            {
                var model = db.Accounts.Find(((User)Session["info"]).ID);

                db.Accounts.Remove(model);
                db.SaveChanges();

                return RedirectToAction("Details" , new { id = ((User)Session["info"]).ID });
            }
            catch
            {
                return View();
            }
        }

        
    }
}
