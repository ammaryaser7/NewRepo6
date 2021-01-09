using mvc_najehacademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_najehacademy.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        { // {'id':234 , 'name':'ammar' , role : [{ 'id':'er433' , name: 'admin'}]}

            if (Session["info"] == null)
            {

                Response.Redirect("~/user/login");
            }
            else
            {
                if (((User)Session["info"]).Role.RoleName != "Admin")
                {
                    Response.Redirect("~/user/login");
                }
            }
        }

        NajehDB db = new NajehDB();
        // GET: Admin                   //ddl          //chklist  
        public ActionResult Index(int? CourseID, int[] Userchecked,int? UserID)
        {
            #region Assign

           
            //1- Return DDL for Courses
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            //2- Return DDL for Users
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email");
            if (Request.Params["btnAssign"] != null && CourseID != null)
            {
                foreach (var item in Userchecked)
                {
                   
                        Junction junction = new Junction(); // each row in junction table has one object
                        junction.CourseID = CourseID;
                        junction.UserID = item;
                        db.Junctions.Add(junction);
                        db.SaveChanges();
                }


            }
            #endregion

            var model = new List<User>(); // Empty Object
            ViewData["listCourses"] = new List<Course>();
            if (Request.Params["BtnGetStudents"] != null) // To bring emails of students
            {
                 model = db.Users.Where(x => x.Junctions.
                         Any(y => y.CourseID == CourseID)).ToList();
            }
            if (Request.Params["BtnGetCourses"] != null)
            {
                ViewData["listCourses"] = db.Courses.Where(x => x.Junctions.
               Any(y => y.UserID == UserID)).ToList();
            }
            //ViewData["listCourses1"] = new SelectList(db.Courses, "ID", "Name");

            return View(model);
        }


        public ActionResult AddRole(Guid? RoleID , int? UserID)
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email");
            if (RoleID != null)
            {
                User user = db.Users.Find(UserID);
                user.RoleRoleID = RoleID;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            var modeluserRole = db.Users.ToList();


            return View(modeluserRole);
        }
    }
}