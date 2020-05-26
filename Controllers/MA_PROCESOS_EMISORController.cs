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
    public class MA_PROCESOS_EMISORController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_PROCESOS_EMISOR
        public IQueryable<MA_PROCESOS_EMISOR> GetMA_PROCESOS_EMISOR()
        {
            return db.MA_PROCESOS_EMISOR;
        }

        // GET: api/MA_PROCESOS_EMISOR/5
        [ResponseType(typeof(MA_PROCESOS_EMISOR))]
        public IHttpActionResult GetMA_PROCESOS_EMISOR(decimal id)
        {
            MA_PROCESOS_EMISOR mA_PROCESOS_EMISOR = db.MA_PROCESOS_EMISOR.Find(id);
            if (mA_PROCESOS_EMISOR == null)
            {
                return NotFound();
            }

            return Ok(mA_PROCESOS_EMISOR);
        }

        // PUT: api/MA_PROCESOS_EMISOR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PROCESOS_EMISOR(decimal id, MA_PROCESOS_EMISOR mA_PROCESOS_EMISOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PROCESOS_EMISOR.IDProcesoEmisor)
            {
                return BadRequest();
            }

            db.Entry(mA_PROCESOS_EMISOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PROCESOS_EMISORExists(id))
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

        // POST: api/MA_PROCESOS_EMISOR
        [ResponseType(typeof(MA_PROCESOS_EMISOR))]
        public IHttpActionResult PostMA_PROCESOS_EMISOR(MA_PROCESOS_EMISOR mA_PROCESOS_EMISOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PROCESOS_EMISOR.Add(mA_PROCESOS_EMISOR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_PROCESOS_EMISOR.IDProcesoEmisor }, mA_PROCESOS_EMISOR);
        }

        // DELETE: api/MA_PROCESOS_EMISOR/5
        [ResponseType(typeof(MA_PROCESOS_EMISOR))]
        public IHttpActionResult DeleteMA_PROCESOS_EMISOR(decimal id)
        {
            MA_PROCESOS_EMISOR mA_PROCESOS_EMISOR = db.MA_PROCESOS_EMISOR.Find(id);
            if (mA_PROCESOS_EMISOR == null)
            {
                return NotFound();
            }

            db.MA_PROCESOS_EMISOR.Remove(mA_PROCESOS_EMISOR);
            db.SaveChanges();

            return Ok(mA_PROCESOS_EMISOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PROCESOS_EMISORExists(decimal id)
        {
            return db.MA_PROCESOS_EMISOR.Count(e => e.IDProcesoEmisor == id) > 0;
        }
    }
}