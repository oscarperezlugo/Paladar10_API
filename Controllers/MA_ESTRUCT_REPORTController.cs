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
    public class MA_ESTRUCT_REPORTController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_ESTRUCT_REPORT
        public IQueryable<MA_ESTRUCT_REPORT> GetMA_ESTRUCT_REPORT()
        {
            return db.MA_ESTRUCT_REPORT;
        }

        // GET: api/MA_ESTRUCT_REPORT/5
        [ResponseType(typeof(MA_ESTRUCT_REPORT))]
        public IHttpActionResult GetMA_ESTRUCT_REPORT(string id)
        {
            MA_ESTRUCT_REPORT mA_ESTRUCT_REPORT = db.MA_ESTRUCT_REPORT.Find(id);
            if (mA_ESTRUCT_REPORT == null)
            {
                return NotFound();
            }

            return Ok(mA_ESTRUCT_REPORT);
        }

        // PUT: api/MA_ESTRUCT_REPORT/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ESTRUCT_REPORT(string id, MA_ESTRUCT_REPORT mA_ESTRUCT_REPORT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ESTRUCT_REPORT.Clave)
            {
                return BadRequest();
            }

            db.Entry(mA_ESTRUCT_REPORT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ESTRUCT_REPORTExists(id))
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

        // POST: api/MA_ESTRUCT_REPORT
        [ResponseType(typeof(MA_ESTRUCT_REPORT))]
        public IHttpActionResult PostMA_ESTRUCT_REPORT(MA_ESTRUCT_REPORT mA_ESTRUCT_REPORT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ESTRUCT_REPORT.Add(mA_ESTRUCT_REPORT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ESTRUCT_REPORTExists(mA_ESTRUCT_REPORT.Clave))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ESTRUCT_REPORT.Clave }, mA_ESTRUCT_REPORT);
        }

        // DELETE: api/MA_ESTRUCT_REPORT/5
        [ResponseType(typeof(MA_ESTRUCT_REPORT))]
        public IHttpActionResult DeleteMA_ESTRUCT_REPORT(string id)
        {
            MA_ESTRUCT_REPORT mA_ESTRUCT_REPORT = db.MA_ESTRUCT_REPORT.Find(id);
            if (mA_ESTRUCT_REPORT == null)
            {
                return NotFound();
            }

            db.MA_ESTRUCT_REPORT.Remove(mA_ESTRUCT_REPORT);
            db.SaveChanges();

            return Ok(mA_ESTRUCT_REPORT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ESTRUCT_REPORTExists(string id)
        {
            return db.MA_ESTRUCT_REPORT.Count(e => e.Clave == id) > 0;
        }
    }
}