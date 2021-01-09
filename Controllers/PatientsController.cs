using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RCCClinic.Models;
using PagedList;

namespace RCCClinic.Controllers
{
    public class PatientsController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext) // we put this to let user go tho home page if user access wrong url
        {
            if (Session["info"] == null) // that means that no user id come from login page 
            {
                Response.Redirect("~/User/Login");
            }
        }


        private ClinicDB db = new ClinicDB();

        // GET: Patients
        public ActionResult Index(string sortOrder,string txtSearch, string txtMobile,string txtBookedOn, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var model = db.Patients.ToList();

            switch (sortOrder)
            {
                case "Name_desc":
                    model = model.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Date":
                    model = model.OrderByDescending(s => s.BookedOn).ToList();
                    break;
               
                default:
                    model = model.OrderByDescending(s => s.ID).ToList();
                    break;
            }

            if (!string.IsNullOrEmpty(txtMobile))
            {
                model = model.Where(x => x.Mobile.ToLower().Contains(txtMobile)).ToList();
            }
            if (!string.IsNullOrEmpty(txtBookedOn))
            {
                model = model.Where(x => x.BookedOn == DateTime.Parse( txtBookedOn)).ToList();
            }
            if (!string.IsNullOrEmpty(txtSearch))
            {
                model = model.Where(x => x.Name.ToLower().Contains(txtSearch.ToLower())).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageFile,[Bind(Include = "ID,Name,Address,Mobile,CC,Gender,age,BookedOn,Smoking,Allergies,DM,Medication,HTN,Pain,Alcohol,DoctorsNote")] Patient patient)
        {
           
            if (ModelState.IsValid)
            {
               
               
                var ex = Path.GetExtension(ImageFile.FileName);
                Guid gg = Guid.NewGuid();
                ImageFile.SaveAs(Server.MapPath("/Images/" + gg + ex)); // To Images Folder
                patient.Imagefile = gg + ex; // To DB 
                db.Patients.Add(patient);
                db.SaveChanges();

                return RedirectToAction("index");



            }


            return View();
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase ImageFile,[Bind(Include = "ID,Name,Address,Mobile,CC,Gender,age,BookedOn,Smoking,Allergies,DM,Medication,HTN,Pain,Alcohol,DoctorsNote,ImageFile")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null) //eXist!!
                {
                    Guid gg = Guid.NewGuid();
                    var ex = Path.GetExtension(ImageFile.FileName);
                    ImageFile.SaveAs(Server.MapPath("/Images/" + gg + ex)); // To Images Folder
                    patient.Imagefile = gg + ex; // To DB

                   
                }
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("details",new { id = patient.ID});
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetImage(int id)
        {
            ViewData["imagefile"] = db.Patients.SingleOrDefault(x => x. ID== id).Imagefile;

            return View();
        }
        public ActionResult GetNote(int id)
        {
            ViewData["Note"] = db.Patients.SingleOrDefault(x => x.ID == id).DoctorsNote;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
