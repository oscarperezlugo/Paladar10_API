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
    public class TR_ODCController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_ODC
        public IQueryable<TR_ODC> GetTR_ODC()
        {
            return db.TR_ODC;
        }

        // GET: api/TR_ODC/5
        [ResponseType(typeof(TR_ODC))]
        public IHttpActionResult GetTR_ODC(string id)
        {
            TR_ODC tR_ODC = db.TR_ODC.Find(id);
            if (tR_ODC == null)
            {
                return NotFound();
            }

            return Ok(tR_ODC);
        }

        // PUT: api/TR_ODC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_ODC(string id, TR_ODC tR_ODC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_ODC.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(tR_ODC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_ODCExists(id))
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

        // POST: api/TR_ODC
        [ResponseType(typeof(TR_ODC))]
        public IHttpActionResult PostTR_ODC(TR_ODC tR_ODC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_ODC.Add(tR_ODC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_ODCExists(tR_ODC.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_ODC.c_DOCUMENTO }, tR_ODC);
        }

        // DELETE: api/TR_ODC/5
        [ResponseType(typeof(TR_ODC))]
        public IHttpActionResult DeleteTR_ODC(string id)
        {
            TR_ODC tR_ODC = db.TR_ODC.Find(id);
            if (tR_ODC == null)
            {
                return NotFound();
            }

            db.TR_ODC.Remove(tR_ODC);
            db.SaveChanges();

            return Ok(tR_ODC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_ODCExists(string id)
        {
            return db.TR_ODC.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}