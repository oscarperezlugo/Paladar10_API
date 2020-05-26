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
    public class TR_MODULO_PROCESOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_MODULO_PROCESO
        public IQueryable<TR_MODULO_PROCESO> GetTR_MODULO_PROCESO()
        {
            return db.TR_MODULO_PROCESO;
        }

        // GET: api/TR_MODULO_PROCESO/5
        [ResponseType(typeof(TR_MODULO_PROCESO))]
        public IHttpActionResult GetTR_MODULO_PROCESO(string id)
        {
            TR_MODULO_PROCESO tR_MODULO_PROCESO = db.TR_MODULO_PROCESO.Find(id);
            if (tR_MODULO_PROCESO == null)
            {
                return NotFound();
            }

            return Ok(tR_MODULO_PROCESO);
        }

        // PUT: api/TR_MODULO_PROCESO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_MODULO_PROCESO(string id, TR_MODULO_PROCESO tR_MODULO_PROCESO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_MODULO_PROCESO.Tabla)
            {
                return BadRequest();
            }

            db.Entry(tR_MODULO_PROCESO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_MODULO_PROCESOExists(id))
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

        // POST: api/TR_MODULO_PROCESO
        [ResponseType(typeof(TR_MODULO_PROCESO))]
        public IHttpActionResult PostTR_MODULO_PROCESO(TR_MODULO_PROCESO tR_MODULO_PROCESO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_MODULO_PROCESO.Add(tR_MODULO_PROCESO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_MODULO_PROCESOExists(tR_MODULO_PROCESO.Tabla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_MODULO_PROCESO.Tabla }, tR_MODULO_PROCESO);
        }

        // DELETE: api/TR_MODULO_PROCESO/5
        [ResponseType(typeof(TR_MODULO_PROCESO))]
        public IHttpActionResult DeleteTR_MODULO_PROCESO(string id)
        {
            TR_MODULO_PROCESO tR_MODULO_PROCESO = db.TR_MODULO_PROCESO.Find(id);
            if (tR_MODULO_PROCESO == null)
            {
                return NotFound();
            }

            db.TR_MODULO_PROCESO.Remove(tR_MODULO_PROCESO);
            db.SaveChanges();

            return Ok(tR_MODULO_PROCESO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_MODULO_PROCESOExists(string id)
        {
            return db.TR_MODULO_PROCESO.Count(e => e.Tabla == id) > 0;
        }
    }
}