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
    public class MA_TRAZA_FICHASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_TRAZA_FICHAS
        public IQueryable<MA_TRAZA_FICHAS> GetMA_TRAZA_FICHAS()
        {
            return db.MA_TRAZA_FICHAS;
        }

        // GET: api/MA_TRAZA_FICHAS/5
        [ResponseType(typeof(MA_TRAZA_FICHAS))]
        public IHttpActionResult GetMA_TRAZA_FICHAS(decimal id)
        {
            MA_TRAZA_FICHAS mA_TRAZA_FICHAS = db.MA_TRAZA_FICHAS.Find(id);
            if (mA_TRAZA_FICHAS == null)
            {
                return NotFound();
            }

            return Ok(mA_TRAZA_FICHAS);
        }

        // PUT: api/MA_TRAZA_FICHAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_TRAZA_FICHAS(decimal id, MA_TRAZA_FICHAS mA_TRAZA_FICHAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_TRAZA_FICHAS.CS_ID)
            {
                return BadRequest();
            }

            db.Entry(mA_TRAZA_FICHAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_TRAZA_FICHASExists(id))
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

        // POST: api/MA_TRAZA_FICHAS
        [ResponseType(typeof(MA_TRAZA_FICHAS))]
        public IHttpActionResult PostMA_TRAZA_FICHAS(MA_TRAZA_FICHAS mA_TRAZA_FICHAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_TRAZA_FICHAS.Add(mA_TRAZA_FICHAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_TRAZA_FICHAS.CS_ID }, mA_TRAZA_FICHAS);
        }

        // DELETE: api/MA_TRAZA_FICHAS/5
        [ResponseType(typeof(MA_TRAZA_FICHAS))]
        public IHttpActionResult DeleteMA_TRAZA_FICHAS(decimal id)
        {
            MA_TRAZA_FICHAS mA_TRAZA_FICHAS = db.MA_TRAZA_FICHAS.Find(id);
            if (mA_TRAZA_FICHAS == null)
            {
                return NotFound();
            }

            db.MA_TRAZA_FICHAS.Remove(mA_TRAZA_FICHAS);
            db.SaveChanges();

            return Ok(mA_TRAZA_FICHAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_TRAZA_FICHASExists(decimal id)
        {
            return db.MA_TRAZA_FICHAS.Count(e => e.CS_ID == id) > 0;
        }
    }
}