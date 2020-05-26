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
    public class MA_REQUISICION_DEPOSITOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_REQUISICION_DEPOSITO
        public IQueryable<MA_REQUISICION_DEPOSITO> GetMA_REQUISICION_DEPOSITO()
        {
            return db.MA_REQUISICION_DEPOSITO;
        }

        // GET: api/MA_REQUISICION_DEPOSITO/5
        [ResponseType(typeof(MA_REQUISICION_DEPOSITO))]
        public IHttpActionResult GetMA_REQUISICION_DEPOSITO(string id)
        {
            MA_REQUISICION_DEPOSITO mA_REQUISICION_DEPOSITO = db.MA_REQUISICION_DEPOSITO.Find(id);
            if (mA_REQUISICION_DEPOSITO == null)
            {
                return NotFound();
            }

            return Ok(mA_REQUISICION_DEPOSITO);
        }

        // PUT: api/MA_REQUISICION_DEPOSITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_REQUISICION_DEPOSITO(string id, MA_REQUISICION_DEPOSITO mA_REQUISICION_DEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_REQUISICION_DEPOSITO.CS_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(mA_REQUISICION_DEPOSITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_REQUISICION_DEPOSITOExists(id))
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

        // POST: api/MA_REQUISICION_DEPOSITO
        [ResponseType(typeof(MA_REQUISICION_DEPOSITO))]
        public IHttpActionResult PostMA_REQUISICION_DEPOSITO(MA_REQUISICION_DEPOSITO mA_REQUISICION_DEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_REQUISICION_DEPOSITO.Add(mA_REQUISICION_DEPOSITO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_REQUISICION_DEPOSITOExists(mA_REQUISICION_DEPOSITO.CS_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_REQUISICION_DEPOSITO.CS_DOCUMENTO }, mA_REQUISICION_DEPOSITO);
        }

        // DELETE: api/MA_REQUISICION_DEPOSITO/5
        [ResponseType(typeof(MA_REQUISICION_DEPOSITO))]
        public IHttpActionResult DeleteMA_REQUISICION_DEPOSITO(string id)
        {
            MA_REQUISICION_DEPOSITO mA_REQUISICION_DEPOSITO = db.MA_REQUISICION_DEPOSITO.Find(id);
            if (mA_REQUISICION_DEPOSITO == null)
            {
                return NotFound();
            }

            db.MA_REQUISICION_DEPOSITO.Remove(mA_REQUISICION_DEPOSITO);
            db.SaveChanges();

            return Ok(mA_REQUISICION_DEPOSITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_REQUISICION_DEPOSITOExists(string id)
        {
            return db.MA_REQUISICION_DEPOSITO.Count(e => e.CS_DOCUMENTO == id) > 0;
        }
    }
}