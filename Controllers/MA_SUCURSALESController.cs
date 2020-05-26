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
    public class MA_SUCURSALESController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_SUCURSALES
        public IQueryable<MA_SUCURSALES> GetMA_SUCURSALES()
        {
            return db.MA_SUCURSALES;
        }

        // GET: api/MA_SUCURSALES/5
        [ResponseType(typeof(MA_SUCURSALES))]
        public IHttpActionResult GetMA_SUCURSALES(string id)
        {
            MA_SUCURSALES mA_SUCURSALES = db.MA_SUCURSALES.Find(id);
            if (mA_SUCURSALES == null)
            {
                return NotFound();
            }

            return Ok(mA_SUCURSALES);
        }

        // PUT: api/MA_SUCURSALES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_SUCURSALES(string id, MA_SUCURSALES mA_SUCURSALES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_SUCURSALES.C_codigo)
            {
                return BadRequest();
            }

            db.Entry(mA_SUCURSALES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_SUCURSALESExists(id))
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

        // POST: api/MA_SUCURSALES
        [ResponseType(typeof(MA_SUCURSALES))]
        public IHttpActionResult PostMA_SUCURSALES(MA_SUCURSALES mA_SUCURSALES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_SUCURSALES.Add(mA_SUCURSALES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_SUCURSALESExists(mA_SUCURSALES.C_codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_SUCURSALES.C_codigo }, mA_SUCURSALES);
        }

        // DELETE: api/MA_SUCURSALES/5
        [ResponseType(typeof(MA_SUCURSALES))]
        public IHttpActionResult DeleteMA_SUCURSALES(string id)
        {
            MA_SUCURSALES mA_SUCURSALES = db.MA_SUCURSALES.Find(id);
            if (mA_SUCURSALES == null)
            {
                return NotFound();
            }

            db.MA_SUCURSALES.Remove(mA_SUCURSALES);
            db.SaveChanges();

            return Ok(mA_SUCURSALES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_SUCURSALESExists(string id)
        {
            return db.MA_SUCURSALES.Count(e => e.C_codigo == id) > 0;
        }
    }
}