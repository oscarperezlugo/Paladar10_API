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
    public class MA_REGLASDENEGOCIO_PROCESOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_REGLASDENEGOCIO_PROCESOS
        public IQueryable<MA_REGLASDENEGOCIO_PROCESOS> GetMA_REGLASDENEGOCIO_PROCESOS()
        {
            return db.MA_REGLASDENEGOCIO_PROCESOS;
        }

        // GET: api/MA_REGLASDENEGOCIO_PROCESOS/5
        [ResponseType(typeof(MA_REGLASDENEGOCIO_PROCESOS))]
        public IHttpActionResult GetMA_REGLASDENEGOCIO_PROCESOS(string id)
        {
            MA_REGLASDENEGOCIO_PROCESOS mA_REGLASDENEGOCIO_PROCESOS = db.MA_REGLASDENEGOCIO_PROCESOS.Find(id);
            if (mA_REGLASDENEGOCIO_PROCESOS == null)
            {
                return NotFound();
            }

            return Ok(mA_REGLASDENEGOCIO_PROCESOS);
        }

        // PUT: api/MA_REGLASDENEGOCIO_PROCESOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_REGLASDENEGOCIO_PROCESOS(string id, MA_REGLASDENEGOCIO_PROCESOS mA_REGLASDENEGOCIO_PROCESOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_REGLASDENEGOCIO_PROCESOS.IDProceso)
            {
                return BadRequest();
            }

            db.Entry(mA_REGLASDENEGOCIO_PROCESOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_REGLASDENEGOCIO_PROCESOSExists(id))
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

        // POST: api/MA_REGLASDENEGOCIO_PROCESOS
        [ResponseType(typeof(MA_REGLASDENEGOCIO_PROCESOS))]
        public IHttpActionResult PostMA_REGLASDENEGOCIO_PROCESOS(MA_REGLASDENEGOCIO_PROCESOS mA_REGLASDENEGOCIO_PROCESOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_REGLASDENEGOCIO_PROCESOS.Add(mA_REGLASDENEGOCIO_PROCESOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_REGLASDENEGOCIO_PROCESOSExists(mA_REGLASDENEGOCIO_PROCESOS.IDProceso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_REGLASDENEGOCIO_PROCESOS.IDProceso }, mA_REGLASDENEGOCIO_PROCESOS);
        }

        // DELETE: api/MA_REGLASDENEGOCIO_PROCESOS/5
        [ResponseType(typeof(MA_REGLASDENEGOCIO_PROCESOS))]
        public IHttpActionResult DeleteMA_REGLASDENEGOCIO_PROCESOS(string id)
        {
            MA_REGLASDENEGOCIO_PROCESOS mA_REGLASDENEGOCIO_PROCESOS = db.MA_REGLASDENEGOCIO_PROCESOS.Find(id);
            if (mA_REGLASDENEGOCIO_PROCESOS == null)
            {
                return NotFound();
            }

            db.MA_REGLASDENEGOCIO_PROCESOS.Remove(mA_REGLASDENEGOCIO_PROCESOS);
            db.SaveChanges();

            return Ok(mA_REGLASDENEGOCIO_PROCESOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_REGLASDENEGOCIO_PROCESOSExists(string id)
        {
            return db.MA_REGLASDENEGOCIO_PROCESOS.Count(e => e.IDProceso == id) > 0;
        }
    }
}