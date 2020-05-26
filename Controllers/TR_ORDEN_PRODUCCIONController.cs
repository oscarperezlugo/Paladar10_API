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
    public class TR_ORDEN_PRODUCCIONController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_ORDEN_PRODUCCION
        public IQueryable<TR_ORDEN_PRODUCCION> GetTR_ORDEN_PRODUCCION()
        {
            return db.TR_ORDEN_PRODUCCION;
        }

        // GET: api/TR_ORDEN_PRODUCCION/5
        [ResponseType(typeof(TR_ORDEN_PRODUCCION))]
        public IHttpActionResult GetTR_ORDEN_PRODUCCION(string id)
        {
            TR_ORDEN_PRODUCCION tR_ORDEN_PRODUCCION = db.TR_ORDEN_PRODUCCION.Find(id);
            if (tR_ORDEN_PRODUCCION == null)
            {
                return NotFound();
            }

            return Ok(tR_ORDEN_PRODUCCION);
        }

        // PUT: api/TR_ORDEN_PRODUCCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_ORDEN_PRODUCCION(string id, TR_ORDEN_PRODUCCION tR_ORDEN_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_ORDEN_PRODUCCION.c_Documento)
            {
                return BadRequest();
            }

            db.Entry(tR_ORDEN_PRODUCCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_ORDEN_PRODUCCIONExists(id))
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

        // POST: api/TR_ORDEN_PRODUCCION
        [ResponseType(typeof(TR_ORDEN_PRODUCCION))]
        public IHttpActionResult PostTR_ORDEN_PRODUCCION(TR_ORDEN_PRODUCCION tR_ORDEN_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_ORDEN_PRODUCCION.Add(tR_ORDEN_PRODUCCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_ORDEN_PRODUCCIONExists(tR_ORDEN_PRODUCCION.c_Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_ORDEN_PRODUCCION.c_Documento }, tR_ORDEN_PRODUCCION);
        }

        // DELETE: api/TR_ORDEN_PRODUCCION/5
        [ResponseType(typeof(TR_ORDEN_PRODUCCION))]
        public IHttpActionResult DeleteTR_ORDEN_PRODUCCION(string id)
        {
            TR_ORDEN_PRODUCCION tR_ORDEN_PRODUCCION = db.TR_ORDEN_PRODUCCION.Find(id);
            if (tR_ORDEN_PRODUCCION == null)
            {
                return NotFound();
            }

            db.TR_ORDEN_PRODUCCION.Remove(tR_ORDEN_PRODUCCION);
            db.SaveChanges();

            return Ok(tR_ORDEN_PRODUCCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_ORDEN_PRODUCCIONExists(string id)
        {
            return db.TR_ORDEN_PRODUCCION.Count(e => e.c_Documento == id) > 0;
        }
    }
}