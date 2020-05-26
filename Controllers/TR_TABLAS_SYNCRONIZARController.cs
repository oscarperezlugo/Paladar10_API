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
    public class TR_TABLAS_SYNCRONIZARController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_TABLAS_SYNCRONIZAR
        public IQueryable<TR_TABLAS_SYNCRONIZAR> GetTR_TABLAS_SYNCRONIZAR()
        {
            return db.TR_TABLAS_SYNCRONIZAR;
        }

        // GET: api/TR_TABLAS_SYNCRONIZAR/5
        [ResponseType(typeof(TR_TABLAS_SYNCRONIZAR))]
        public IHttpActionResult GetTR_TABLAS_SYNCRONIZAR(string id)
        {
            TR_TABLAS_SYNCRONIZAR tR_TABLAS_SYNCRONIZAR = db.TR_TABLAS_SYNCRONIZAR.Find(id);
            if (tR_TABLAS_SYNCRONIZAR == null)
            {
                return NotFound();
            }

            return Ok(tR_TABLAS_SYNCRONIZAR);
        }

        // PUT: api/TR_TABLAS_SYNCRONIZAR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_TABLAS_SYNCRONIZAR(string id, TR_TABLAS_SYNCRONIZAR tR_TABLAS_SYNCRONIZAR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_TABLAS_SYNCRONIZAR.CU_CODSUCURSAL)
            {
                return BadRequest();
            }

            db.Entry(tR_TABLAS_SYNCRONIZAR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_TABLAS_SYNCRONIZARExists(id))
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

        // POST: api/TR_TABLAS_SYNCRONIZAR
        [ResponseType(typeof(TR_TABLAS_SYNCRONIZAR))]
        public IHttpActionResult PostTR_TABLAS_SYNCRONIZAR(TR_TABLAS_SYNCRONIZAR tR_TABLAS_SYNCRONIZAR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_TABLAS_SYNCRONIZAR.Add(tR_TABLAS_SYNCRONIZAR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_TABLAS_SYNCRONIZARExists(tR_TABLAS_SYNCRONIZAR.CU_CODSUCURSAL))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_TABLAS_SYNCRONIZAR.CU_CODSUCURSAL }, tR_TABLAS_SYNCRONIZAR);
        }

        // DELETE: api/TR_TABLAS_SYNCRONIZAR/5
        [ResponseType(typeof(TR_TABLAS_SYNCRONIZAR))]
        public IHttpActionResult DeleteTR_TABLAS_SYNCRONIZAR(string id)
        {
            TR_TABLAS_SYNCRONIZAR tR_TABLAS_SYNCRONIZAR = db.TR_TABLAS_SYNCRONIZAR.Find(id);
            if (tR_TABLAS_SYNCRONIZAR == null)
            {
                return NotFound();
            }

            db.TR_TABLAS_SYNCRONIZAR.Remove(tR_TABLAS_SYNCRONIZAR);
            db.SaveChanges();

            return Ok(tR_TABLAS_SYNCRONIZAR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_TABLAS_SYNCRONIZARExists(string id)
        {
            return db.TR_TABLAS_SYNCRONIZAR.Count(e => e.CU_CODSUCURSAL == id) > 0;
        }
    }
}