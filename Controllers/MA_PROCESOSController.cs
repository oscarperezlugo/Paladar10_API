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
    public class MA_PROCESOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_PROCESOS
        public IQueryable<MA_PROCESOS> GetMA_PROCESOS()
        {
            return db.MA_PROCESOS;
        }

        // GET: api/MA_PROCESOS/5
        [ResponseType(typeof(MA_PROCESOS))]
        public IHttpActionResult GetMA_PROCESOS(decimal id)
        {
            MA_PROCESOS mA_PROCESOS = db.MA_PROCESOS.Find(id);
            if (mA_PROCESOS == null)
            {
                return NotFound();
            }

            return Ok(mA_PROCESOS);
        }

        // PUT: api/MA_PROCESOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PROCESOS(decimal id, MA_PROCESOS mA_PROCESOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PROCESOS.IDProceso)
            {
                return BadRequest();
            }

            db.Entry(mA_PROCESOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PROCESOSExists(id))
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

        // POST: api/MA_PROCESOS
        [ResponseType(typeof(MA_PROCESOS))]
        public IHttpActionResult PostMA_PROCESOS(MA_PROCESOS mA_PROCESOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PROCESOS.Add(mA_PROCESOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PROCESOSExists(mA_PROCESOS.IDProceso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PROCESOS.IDProceso }, mA_PROCESOS);
        }

        // DELETE: api/MA_PROCESOS/5
        [ResponseType(typeof(MA_PROCESOS))]
        public IHttpActionResult DeleteMA_PROCESOS(decimal id)
        {
            MA_PROCESOS mA_PROCESOS = db.MA_PROCESOS.Find(id);
            if (mA_PROCESOS == null)
            {
                return NotFound();
            }

            db.MA_PROCESOS.Remove(mA_PROCESOS);
            db.SaveChanges();

            return Ok(mA_PROCESOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PROCESOSExists(decimal id)
        {
            return db.MA_PROCESOS.Count(e => e.IDProceso == id) > 0;
        }
    }
}