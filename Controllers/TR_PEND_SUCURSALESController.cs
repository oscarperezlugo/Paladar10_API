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
    public class TR_PEND_SUCURSALESController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_PEND_SUCURSALES
        public IQueryable<TR_PEND_SUCURSALES> GetTR_PEND_SUCURSALES()
        {
            return db.TR_PEND_SUCURSALES;
        }

        // GET: api/TR_PEND_SUCURSALES/5
        [ResponseType(typeof(TR_PEND_SUCURSALES))]
        public IHttpActionResult GetTR_PEND_SUCURSALES(string id)
        {
            TR_PEND_SUCURSALES tR_PEND_SUCURSALES = db.TR_PEND_SUCURSALES.Find(id);
            if (tR_PEND_SUCURSALES == null)
            {
                return NotFound();
            }

            return Ok(tR_PEND_SUCURSALES);
        }

        // PUT: api/TR_PEND_SUCURSALES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_PEND_SUCURSALES(string id, TR_PEND_SUCURSALES tR_PEND_SUCURSALES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_PEND_SUCURSALES.C_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(tR_PEND_SUCURSALES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_PEND_SUCURSALESExists(id))
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

        // POST: api/TR_PEND_SUCURSALES
        [ResponseType(typeof(TR_PEND_SUCURSALES))]
        public IHttpActionResult PostTR_PEND_SUCURSALES(TR_PEND_SUCURSALES tR_PEND_SUCURSALES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_PEND_SUCURSALES.Add(tR_PEND_SUCURSALES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_PEND_SUCURSALESExists(tR_PEND_SUCURSALES.C_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_PEND_SUCURSALES.C_CODIGO }, tR_PEND_SUCURSALES);
        }

        // DELETE: api/TR_PEND_SUCURSALES/5
        [ResponseType(typeof(TR_PEND_SUCURSALES))]
        public IHttpActionResult DeleteTR_PEND_SUCURSALES(string id)
        {
            TR_PEND_SUCURSALES tR_PEND_SUCURSALES = db.TR_PEND_SUCURSALES.Find(id);
            if (tR_PEND_SUCURSALES == null)
            {
                return NotFound();
            }

            db.TR_PEND_SUCURSALES.Remove(tR_PEND_SUCURSALES);
            db.SaveChanges();

            return Ok(tR_PEND_SUCURSALES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_PEND_SUCURSALESExists(string id)
        {
            return db.TR_PEND_SUCURSALES.Count(e => e.C_CODIGO == id) > 0;
        }
    }
}