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
    public class TR_PRODUCCIONController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_PRODUCCION
        public IQueryable<TR_PRODUCCION> GetTR_PRODUCCION()
        {
            return db.TR_PRODUCCION;
        }

        // GET: api/TR_PRODUCCION/5
        [ResponseType(typeof(TR_PRODUCCION))]
        public IHttpActionResult GetTR_PRODUCCION(string id)
        {
            TR_PRODUCCION tR_PRODUCCION = db.TR_PRODUCCION.Find(id);
            if (tR_PRODUCCION == null)
            {
                return NotFound();
            }

            return Ok(tR_PRODUCCION);
        }

        // PUT: api/TR_PRODUCCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_PRODUCCION(string id, TR_PRODUCCION tR_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_PRODUCCION.C_FORMULA)
            {
                return BadRequest();
            }

            db.Entry(tR_PRODUCCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_PRODUCCIONExists(id))
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

        // POST: api/TR_PRODUCCION
        [ResponseType(typeof(TR_PRODUCCION))]
        public IHttpActionResult PostTR_PRODUCCION(TR_PRODUCCION tR_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_PRODUCCION.Add(tR_PRODUCCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_PRODUCCIONExists(tR_PRODUCCION.C_FORMULA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_PRODUCCION.C_FORMULA }, tR_PRODUCCION);
        }

        // DELETE: api/TR_PRODUCCION/5
        [ResponseType(typeof(TR_PRODUCCION))]
        public IHttpActionResult DeleteTR_PRODUCCION(string id)
        {
            TR_PRODUCCION tR_PRODUCCION = db.TR_PRODUCCION.Find(id);
            if (tR_PRODUCCION == null)
            {
                return NotFound();
            }

            db.TR_PRODUCCION.Remove(tR_PRODUCCION);
            db.SaveChanges();

            return Ok(tR_PRODUCCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_PRODUCCIONExists(string id)
        {
            return db.TR_PRODUCCION.Count(e => e.C_FORMULA == id) > 0;
        }
    }
}