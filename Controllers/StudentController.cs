using mvc_najehacademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_najehacademy.Controllers
{
    public class StudentController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["info"] == null)
            {

                Response.Redirect("~/user/login");
            }
            else
            {
                if (((User)Session["info"]).Role.RoleName != "Student")
                {
                    Response.Redirect("~/user/login");
                }
            }
        }


        NajehDB db = new NajehDB();

        public ActionResult Index()
        {
            return View();
        }

            // GET: Student
            public ActionResult Assign(int? DDLMajors)
        {
            //DropDownlist 
            ViewBag.DDLMajors = new SelectList(db.Majors, "ID", "Title");
            var model = db.Users.Find(((User)Session["info"]).ID);
            if (DDLMajors != null)
            {              
                model.MajorID = DDLMajors; // assign new value for major id
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return View(model);
        }

        //[HttpPost]
        //public ActionResult Assign(int? DDLMajors)
        //{
        //    ViewBag.DDLMajors = new SelectList(db.Majors, "ID", "Title");
        //    if (DDLMajors != null)
        //    {

        //    }


        //    return View();
        //}

        public ActionResult GetStudentMajors(int? MjrID)
        {

            ViewBag.MjrID = new SelectList(db.Majors, "ID", "Title");

            var model = new List<User>(); // Empty User List;
            if (MjrID != null)
            {
                model = db.Users.Where(x => x.MajorID == MjrID).ToList();
            }
            


            return View(model);

        } 


    }

   
         



}