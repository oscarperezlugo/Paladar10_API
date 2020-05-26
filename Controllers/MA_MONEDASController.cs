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
    public class MA_MONEDASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_MONEDAS
        public IQueryable<MA_MONEDAS> GetMA_MONEDAS()
        {
            return db.MA_MONEDAS;
        }

        // GET: api/MA_MONEDAS/5
        [ResponseType(typeof(MA_MONEDAS))]
        public IHttpActionResult GetMA_MONEDAS(string id)
        {
            MA_MONEDAS mA_MONEDAS = db.MA_MONEDAS.Find(id);
            if (mA_MONEDAS == null)
            {
                return NotFound();
            }

            return Ok(mA_MONEDAS);
        }

        // PUT: api/MA_MONEDAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_MONEDAS(string id, MA_MONEDAS mA_MONEDAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_MONEDAS.c_codmoneda)
            {
                return BadRequest();
            }

            db.Entry(mA_MONEDAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_MONEDASExists(id))
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

        // POST: api/MA_MONEDAS
        [ResponseType(typeof(MA_MONEDAS))]
        public IHttpActionResult PostMA_MONEDAS(MA_MONEDAS mA_MONEDAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_MONEDAS.Add(mA_MONEDAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_MONEDASExists(mA_MONEDAS.c_codmoneda))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_MONEDAS.c_codmoneda }, mA_MONEDAS);
        }

        // DELETE: api/MA_MONEDAS/5
        [ResponseType(typeof(MA_MONEDAS))]
        public IHttpActionResult DeleteMA_MONEDAS(string id)
        {
            MA_MONEDAS mA_MONEDAS = db.MA_MONEDAS.Find(id);
            if (mA_MONEDAS == null)
            {
                return NotFound();
            }

            db.MA_MONEDAS.Remove(mA_MONEDAS);
            db.SaveChanges();

            return Ok(mA_MONEDAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_MONEDASExists(string id)
        {
            return db.MA_MONEDAS.Count(e => e.c_codmoneda == id) > 0;
        }
    }
}