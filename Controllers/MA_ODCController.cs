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
    public class MA_ODCController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_ODC
        public IQueryable<MA_ODC> GetMA_ODC()
        {
            return db.MA_ODC;
        }

        // GET: api/MA_ODC/5
        [ResponseType(typeof(MA_ODC))]
        public IHttpActionResult GetMA_ODC(string id)
        {
            MA_ODC mA_ODC = db.MA_ODC.Find(id);
            if (mA_ODC == null)
            {
                return NotFound();
            }

            return Ok(mA_ODC);
        }

        // PUT: api/MA_ODC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ODC(string id, MA_ODC mA_ODC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ODC.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(mA_ODC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ODCExists(id))
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

        // POST: api/MA_ODC
        [ResponseType(typeof(MA_ODC))]
        public IHttpActionResult PostMA_ODC(MA_ODC mA_ODC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ODC.Add(mA_ODC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ODCExists(mA_ODC.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ODC.c_DOCUMENTO }, mA_ODC);
        }

        // DELETE: api/MA_ODC/5
        [ResponseType(typeof(MA_ODC))]
        public IHttpActionResult DeleteMA_ODC(string id)
        {
            MA_ODC mA_ODC = db.MA_ODC.Find(id);
            if (mA_ODC == null)
            {
                return NotFound();
            }

            db.MA_ODC.Remove(mA_ODC);
            db.SaveChanges();

            return Ok(mA_ODC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ODCExists(string id)
        {
            return db.MA_ODC.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}