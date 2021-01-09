using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using mvc_najehacademy.Models;

namespace mvc_najehacademy.Controllers
{
    public class Majors1Controller : ApiController
    {
         //private NajehDB db = new NajehDB();
        private NajehDB db = new NajehDB("apiammar");

        // GET: api/Majors1
        // ------------------------use second construct apiammar---------------------------
        public IQueryable<Major> GetMajors()
        {
            //eager loading
            return db.Majors.Include(x => x.Users);
            // return db.Users.Include(x => x.Account).Include(y => y.Junctions).Include(z => z.Major);
            
        }


        // ------------------------use FIRST construct with null params ---------------------------
       // public List<User> GetUsers()
        //{
         //   return db.Users.Where(x => x.MajorID == 4).ToList();
       // }



        // GET: api/Majors1/5
        [ResponseType(typeof(Major))]
        public IHttpActionResult GetMajor(int id)
        {
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return NotFound();
            }

            return Ok(major);
        }

        // PUT: api/Majors1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMajor(int id, Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != major.ID)
            {
                return BadRequest();
            }

            db.Entry(major).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Majors1
        [ResponseType(typeof(Major))]
        public IHttpActionResult PostMajor(Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Majors.Add(major);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = major.ID }, major);
        }

        // DELETE: api/Majors1/5
        [ResponseType(typeof(Major))]
        public IHttpActionResult DeleteMajor(int id)
        {
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return NotFound();
            }

            db.Majors.Remove(major);
            db.SaveChanges();

            return Ok(major);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MajorExists(int id)
        {
            return db.Majors.Count(e => e.ID == id) > 0;
        }
    }
}