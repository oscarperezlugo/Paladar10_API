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
    public class TR_REQUISICION_DEPOSITOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_REQUISICION_DEPOSITO
        public IQueryable<TR_REQUISICION_DEPOSITO> GetTR_REQUISICION_DEPOSITO()
        {
            return db.TR_REQUISICION_DEPOSITO;
        }

        // GET: api/TR_REQUISICION_DEPOSITO/5
        [ResponseType(typeof(TR_REQUISICION_DEPOSITO))]
        public IHttpActionResult GetTR_REQUISICION_DEPOSITO(string id)
        {
            TR_REQUISICION_DEPOSITO tR_REQUISICION_DEPOSITO = db.TR_REQUISICION_DEPOSITO.Find(id);
            if (tR_REQUISICION_DEPOSITO == null)
            {
                return NotFound();
            }

            return Ok(tR_REQUISICION_DEPOSITO);
        }

        // PUT: api/TR_REQUISICION_DEPOSITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_REQUISICION_DEPOSITO(string id, TR_REQUISICION_DEPOSITO tR_REQUISICION_DEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_REQUISICION_DEPOSITO.CS_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(tR_REQUISICION_DEPOSITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_REQUISICION_DEPOSITOExists(id))
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

        // POST: api/TR_REQUISICION_DEPOSITO
        [ResponseType(typeof(TR_REQUISICION_DEPOSITO))]
        public IHttpActionResult PostTR_REQUISICION_DEPOSITO(TR_REQUISICION_DEPOSITO tR_REQUISICION_DEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_REQUISICION_DEPOSITO.Add(tR_REQUISICION_DEPOSITO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_REQUISICION_DEPOSITOExists(tR_REQUISICION_DEPOSITO.CS_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_REQUISICION_DEPOSITO.CS_DOCUMENTO }, tR_REQUISICION_DEPOSITO);
        }

        // DELETE: api/TR_REQUISICION_DEPOSITO/5
        [ResponseType(typeof(TR_REQUISICION_DEPOSITO))]
        public IHttpActionResult DeleteTR_REQUISICION_DEPOSITO(string id)
        {
            TR_REQUISICION_DEPOSITO tR_REQUISICION_DEPOSITO = db.TR_REQUISICION_DEPOSITO.Find(id);
            if (tR_REQUISICION_DEPOSITO == null)
            {
                return NotFound();
            }

            db.TR_REQUISICION_DEPOSITO.Remove(tR_REQUISICION_DEPOSITO);
            db.SaveChanges();

            return Ok(tR_REQUISICION_DEPOSITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_REQUISICION_DEPOSITOExists(string id)
        {
            return db.TR_REQUISICION_DEPOSITO.Count(e => e.CS_DOCUMENTO == id) > 0;
        }
    }
}