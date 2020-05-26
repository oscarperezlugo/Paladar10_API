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
    public class TR_RTF_ESCController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_RTF_ESC
        public IQueryable<TR_RTF_ESC> GetTR_RTF_ESC()
        {
            return db.TR_RTF_ESC;
        }

        // GET: api/TR_RTF_ESC/5
        [ResponseType(typeof(TR_RTF_ESC))]
        public IHttpActionResult GetTR_RTF_ESC(string id)
        {
            TR_RTF_ESC tR_RTF_ESC = db.TR_RTF_ESC.Find(id);
            if (tR_RTF_ESC == null)
            {
                return NotFound();
            }

            return Ok(tR_RTF_ESC);
        }

        // PUT: api/TR_RTF_ESC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_RTF_ESC(string id, TR_RTF_ESC tR_RTF_ESC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_RTF_ESC.cs_codigo_rtf)
            {
                return BadRequest();
            }

            db.Entry(tR_RTF_ESC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_RTF_ESCExists(id))
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

        // POST: api/TR_RTF_ESC
        [ResponseType(typeof(TR_RTF_ESC))]
        public IHttpActionResult PostTR_RTF_ESC(TR_RTF_ESC tR_RTF_ESC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_RTF_ESC.Add(tR_RTF_ESC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_RTF_ESCExists(tR_RTF_ESC.cs_codigo_rtf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_RTF_ESC.cs_codigo_rtf }, tR_RTF_ESC);
        }

        // DELETE: api/TR_RTF_ESC/5
        [ResponseType(typeof(TR_RTF_ESC))]
        public IHttpActionResult DeleteTR_RTF_ESC(string id)
        {
            TR_RTF_ESC tR_RTF_ESC = db.TR_RTF_ESC.Find(id);
            if (tR_RTF_ESC == null)
            {
                return NotFound();
            }

            db.TR_RTF_ESC.Remove(tR_RTF_ESC);
            db.SaveChanges();

            return Ok(tR_RTF_ESC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_RTF_ESCExists(string id)
        {
            return db.TR_RTF_ESC.Count(e => e.cs_codigo_rtf == id) > 0;
        }
    }
}