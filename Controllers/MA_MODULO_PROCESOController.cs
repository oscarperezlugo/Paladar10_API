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
    public class MA_MODULO_PROCESOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_MODULO_PROCESO
        public IQueryable<MA_MODULO_PROCESO> GetMA_MODULO_PROCESO()
        {
            return db.MA_MODULO_PROCESO;
        }

        // GET: api/MA_MODULO_PROCESO/5
        [ResponseType(typeof(MA_MODULO_PROCESO))]
        public IHttpActionResult GetMA_MODULO_PROCESO(decimal id)
        {
            MA_MODULO_PROCESO mA_MODULO_PROCESO = db.MA_MODULO_PROCESO.Find(id);
            if (mA_MODULO_PROCESO == null)
            {
                return NotFound();
            }

            return Ok(mA_MODULO_PROCESO);
        }

        // PUT: api/MA_MODULO_PROCESO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_MODULO_PROCESO(decimal id, MA_MODULO_PROCESO mA_MODULO_PROCESO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_MODULO_PROCESO.ID)
            {
                return BadRequest();
            }

            db.Entry(mA_MODULO_PROCESO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_MODULO_PROCESOExists(id))
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

        // POST: api/MA_MODULO_PROCESO
        [ResponseType(typeof(MA_MODULO_PROCESO))]
        public IHttpActionResult PostMA_MODULO_PROCESO(MA_MODULO_PROCESO mA_MODULO_PROCESO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_MODULO_PROCESO.Add(mA_MODULO_PROCESO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_MODULO_PROCESO.ID }, mA_MODULO_PROCESO);
        }

        // DELETE: api/MA_MODULO_PROCESO/5
        [ResponseType(typeof(MA_MODULO_PROCESO))]
        public IHttpActionResult DeleteMA_MODULO_PROCESO(decimal id)
        {
            MA_MODULO_PROCESO mA_MODULO_PROCESO = db.MA_MODULO_PROCESO.Find(id);
            if (mA_MODULO_PROCESO == null)
            {
                return NotFound();
            }

            db.MA_MODULO_PROCESO.Remove(mA_MODULO_PROCESO);
            db.SaveChanges();

            return Ok(mA_MODULO_PROCESO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_MODULO_PROCESOExists(decimal id)
        {
            return db.MA_MODULO_PROCESO.Count(e => e.ID == id) > 0;
        }
    }
}