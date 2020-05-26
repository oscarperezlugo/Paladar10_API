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
    public class MA_PRODUCCIONController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_PRODUCCION
        public IQueryable<MA_PRODUCCION> GetMA_PRODUCCION()
        {
            return db.MA_PRODUCCION;
        }

        // GET: api/MA_PRODUCCION/5
        [ResponseType(typeof(MA_PRODUCCION))]
        public IHttpActionResult GetMA_PRODUCCION(string id)
        {
            MA_PRODUCCION mA_PRODUCCION = db.MA_PRODUCCION.Find(id);
            if (mA_PRODUCCION == null)
            {
                return NotFound();
            }

            return Ok(mA_PRODUCCION);
        }

        // PUT: api/MA_PRODUCCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PRODUCCION(string id, MA_PRODUCCION mA_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PRODUCCION.C_FORMULA)
            {
                return BadRequest();
            }

            db.Entry(mA_PRODUCCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PRODUCCIONExists(id))
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

        // POST: api/MA_PRODUCCION
        [ResponseType(typeof(MA_PRODUCCION))]
        public IHttpActionResult PostMA_PRODUCCION(MA_PRODUCCION mA_PRODUCCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PRODUCCION.Add(mA_PRODUCCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PRODUCCIONExists(mA_PRODUCCION.C_FORMULA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PRODUCCION.C_FORMULA }, mA_PRODUCCION);
        }

        // DELETE: api/MA_PRODUCCION/5
        [ResponseType(typeof(MA_PRODUCCION))]
        public IHttpActionResult DeleteMA_PRODUCCION(string id)
        {
            MA_PRODUCCION mA_PRODUCCION = db.MA_PRODUCCION.Find(id);
            if (mA_PRODUCCION == null)
            {
                return NotFound();
            }

            db.MA_PRODUCCION.Remove(mA_PRODUCCION);
            db.SaveChanges();

            return Ok(mA_PRODUCCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PRODUCCIONExists(string id)
        {
            return db.MA_PRODUCCION.Count(e => e.C_FORMULA == id) > 0;
        }
    }
}