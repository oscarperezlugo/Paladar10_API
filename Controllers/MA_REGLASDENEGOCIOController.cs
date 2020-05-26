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
    public class MA_REGLASDENEGOCIOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_REGLASDENEGOCIO
        public IQueryable<MA_REGLASDENEGOCIO> GetMA_REGLASDENEGOCIO()
        {
            return db.MA_REGLASDENEGOCIO;
        }

        // GET: api/MA_REGLASDENEGOCIO/5
        [ResponseType(typeof(MA_REGLASDENEGOCIO))]
        public IHttpActionResult GetMA_REGLASDENEGOCIO(string id)
        {
            MA_REGLASDENEGOCIO mA_REGLASDENEGOCIO = db.MA_REGLASDENEGOCIO.Find(id);
            if (mA_REGLASDENEGOCIO == null)
            {
                return NotFound();
            }

            return Ok(mA_REGLASDENEGOCIO);
        }

        // PUT: api/MA_REGLASDENEGOCIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_REGLASDENEGOCIO(string id, MA_REGLASDENEGOCIO mA_REGLASDENEGOCIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_REGLASDENEGOCIO.Campo)
            {
                return BadRequest();
            }

            db.Entry(mA_REGLASDENEGOCIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_REGLASDENEGOCIOExists(id))
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

        // POST: api/MA_REGLASDENEGOCIO
        [ResponseType(typeof(MA_REGLASDENEGOCIO))]
        public IHttpActionResult PostMA_REGLASDENEGOCIO(MA_REGLASDENEGOCIO mA_REGLASDENEGOCIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_REGLASDENEGOCIO.Add(mA_REGLASDENEGOCIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_REGLASDENEGOCIOExists(mA_REGLASDENEGOCIO.Campo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_REGLASDENEGOCIO.Campo }, mA_REGLASDENEGOCIO);
        }

        // DELETE: api/MA_REGLASDENEGOCIO/5
        [ResponseType(typeof(MA_REGLASDENEGOCIO))]
        public IHttpActionResult DeleteMA_REGLASDENEGOCIO(string id)
        {
            MA_REGLASDENEGOCIO mA_REGLASDENEGOCIO = db.MA_REGLASDENEGOCIO.Find(id);
            if (mA_REGLASDENEGOCIO == null)
            {
                return NotFound();
            }

            db.MA_REGLASDENEGOCIO.Remove(mA_REGLASDENEGOCIO);
            db.SaveChanges();

            return Ok(mA_REGLASDENEGOCIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_REGLASDENEGOCIOExists(string id)
        {
            return db.MA_REGLASDENEGOCIO.Count(e => e.Campo == id) > 0;
        }
    }
}