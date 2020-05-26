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
    public class MA_ORDEN_PRODUCCIONController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_ORDEN_PRODUCCION
        public IQueryable<MA_ORDEN_PRODUCCION> GetMA_ORDEN_PRODUCCION()
        {
            return db.MA_ORDEN_PRODUCCION;
        }

        // GET: api/MA_ORDEN_PRODUCCION/5
        [ResponseType(typeof(MA_ORDEN_PRODUCCION))]
        public IHttpActionResult GetMA_ORDEN_PRODUCCION(string id)
        {
            MA_ORDEN_PRODUCCION mA_ORDEN_PRODUCCION = db.MA_ORDEN_PRODUCCION.Find(id);
            if (mA_ORDEN_PRODUCCION == null)
            {
                return NotFound();
            }

            return Ok(mA_ORDEN_PRODUCCION);
        }

        // PUT: api/MA_ORDEN_PRODUCCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ORDEN_PRODUCCION(string id, MA_ORDEN_PRODUCCION mA_ORDEN_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ORDEN_PRODUCCION.c_Documento)
            {
                return BadRequest();
            }

            db.Entry(mA_ORDEN_PRODUCCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ORDEN_PRODUCCIONExists(id))
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

        // POST: api/MA_ORDEN_PRODUCCION
        [ResponseType(typeof(MA_ORDEN_PRODUCCION))]
        public IHttpActionResult PostMA_ORDEN_PRODUCCION(MA_ORDEN_PRODUCCION mA_ORDEN_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ORDEN_PRODUCCION.Add(mA_ORDEN_PRODUCCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ORDEN_PRODUCCIONExists(mA_ORDEN_PRODUCCION.c_Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ORDEN_PRODUCCION.c_Documento }, mA_ORDEN_PRODUCCION);
        }

        // DELETE: api/MA_ORDEN_PRODUCCION/5
        [ResponseType(typeof(MA_ORDEN_PRODUCCION))]
        public IHttpActionResult DeleteMA_ORDEN_PRODUCCION(string id)
        {
            MA_ORDEN_PRODUCCION mA_ORDEN_PRODUCCION = db.MA_ORDEN_PRODUCCION.Find(id);
            if (mA_ORDEN_PRODUCCION == null)
            {
                return NotFound();
            }

            db.MA_ORDEN_PRODUCCION.Remove(mA_ORDEN_PRODUCCION);
            db.SaveChanges();

            return Ok(mA_ORDEN_PRODUCCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ORDEN_PRODUCCIONExists(string id)
        {
            return db.MA_ORDEN_PRODUCCION.Count(e => e.c_Documento == id) > 0;
        }
    }
}