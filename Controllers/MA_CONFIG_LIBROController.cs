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
using Paladar10_API.Models;

namespace Paladar10_API.Controllers
{
    public class MA_CONFIG_LIBROController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CONFIG_LIBRO
        public IQueryable<MA_CONFIG_LIBRO> GetMA_CONFIG_LIBRO()
        {
            return db.MA_CONFIG_LIBRO;
        }

        // GET: api/MA_CONFIG_LIBRO/5
        [ResponseType(typeof(MA_CONFIG_LIBRO))]
        public IHttpActionResult GetMA_CONFIG_LIBRO(string id)
        {
            MA_CONFIG_LIBRO mA_CONFIG_LIBRO = db.MA_CONFIG_LIBRO.Find(id);
            if (mA_CONFIG_LIBRO == null)
            {
                return NotFound();
            }

            return Ok(mA_CONFIG_LIBRO);
        }

        // PUT: api/MA_CONFIG_LIBRO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CONFIG_LIBRO(string id, MA_CONFIG_LIBRO mA_CONFIG_LIBRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CONFIG_LIBRO.CS_CAMPO)
            {
                return BadRequest();
            }

            db.Entry(mA_CONFIG_LIBRO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CONFIG_LIBROExists(id))
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

        // POST: api/MA_CONFIG_LIBRO
        [ResponseType(typeof(MA_CONFIG_LIBRO))]
        public IHttpActionResult PostMA_CONFIG_LIBRO(MA_CONFIG_LIBRO mA_CONFIG_LIBRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CONFIG_LIBRO.Add(mA_CONFIG_LIBRO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CONFIG_LIBROExists(mA_CONFIG_LIBRO.CS_CAMPO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CONFIG_LIBRO.CS_CAMPO }, mA_CONFIG_LIBRO);
        }

        // DELETE: api/MA_CONFIG_LIBRO/5
        [ResponseType(typeof(MA_CONFIG_LIBRO))]
        public IHttpActionResult DeleteMA_CONFIG_LIBRO(string id)
        {
            MA_CONFIG_LIBRO mA_CONFIG_LIBRO = db.MA_CONFIG_LIBRO.Find(id);
            if (mA_CONFIG_LIBRO == null)
            {
                return NotFound();
            }

            db.MA_CONFIG_LIBRO.Remove(mA_CONFIG_LIBRO);
            db.SaveChanges();

            return Ok(mA_CONFIG_LIBRO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CONFIG_LIBROExists(string id)
        {
            return db.MA_CONFIG_LIBRO.Count(e => e.CS_CAMPO == id) > 0;
        }
    }
}