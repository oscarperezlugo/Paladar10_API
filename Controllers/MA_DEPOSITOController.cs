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
    public class MA_DEPOSITOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_DEPOSITO
        public IQueryable<MA_DEPOSITO> GetMA_DEPOSITO()
        {
            return db.MA_DEPOSITO;
        }

        // GET: api/MA_DEPOSITO/5
        [ResponseType(typeof(MA_DEPOSITO))]
        public IHttpActionResult GetMA_DEPOSITO(string id)
        {
            MA_DEPOSITO mA_DEPOSITO = db.MA_DEPOSITO.Find(id);
            if (mA_DEPOSITO == null)
            {
                return NotFound();
            }

            return Ok(mA_DEPOSITO);
        }

        // PUT: api/MA_DEPOSITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DEPOSITO(string id, MA_DEPOSITO mA_DEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DEPOSITO.c_coddeposito)
            {
                return BadRequest();
            }

            db.Entry(mA_DEPOSITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DEPOSITOExists(id))
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

        // POST: api/MA_DEPOSITO
        [ResponseType(typeof(MA_DEPOSITO))]
        public IHttpActionResult PostMA_DEPOSITO(MA_DEPOSITO mA_DEPOSITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DEPOSITO.Add(mA_DEPOSITO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DEPOSITOExists(mA_DEPOSITO.c_coddeposito))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DEPOSITO.c_coddeposito }, mA_DEPOSITO);
        }

        // DELETE: api/MA_DEPOSITO/5
        [ResponseType(typeof(MA_DEPOSITO))]
        public IHttpActionResult DeleteMA_DEPOSITO(string id)
        {
            MA_DEPOSITO mA_DEPOSITO = db.MA_DEPOSITO.Find(id);
            if (mA_DEPOSITO == null)
            {
                return NotFound();
            }

            db.MA_DEPOSITO.Remove(mA_DEPOSITO);
            db.SaveChanges();

            return Ok(mA_DEPOSITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DEPOSITOExists(string id)
        {
            return db.MA_DEPOSITO.Count(e => e.c_coddeposito == id) > 0;
        }
    }
}