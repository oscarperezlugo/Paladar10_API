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
    public class MA_HISTORICO_MONEDASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_HISTORICO_MONEDAS
        public IQueryable<MA_HISTORICO_MONEDAS> GetMA_HISTORICO_MONEDAS()
        {
            return db.MA_HISTORICO_MONEDAS;
        }

        // GET: api/MA_HISTORICO_MONEDAS/5
        [ResponseType(typeof(MA_HISTORICO_MONEDAS))]
        public IHttpActionResult GetMA_HISTORICO_MONEDAS(decimal id)
        {
            MA_HISTORICO_MONEDAS mA_HISTORICO_MONEDAS = db.MA_HISTORICO_MONEDAS.Find(id);
            if (mA_HISTORICO_MONEDAS == null)
            {
                return NotFound();
            }

            return Ok(mA_HISTORICO_MONEDAS);
        }

        // PUT: api/MA_HISTORICO_MONEDAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_HISTORICO_MONEDAS(decimal id, MA_HISTORICO_MONEDAS mA_HISTORICO_MONEDAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_HISTORICO_MONEDAS.ID)
            {
                return BadRequest();
            }

            db.Entry(mA_HISTORICO_MONEDAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_HISTORICO_MONEDASExists(id))
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

        // POST: api/MA_HISTORICO_MONEDAS
        [ResponseType(typeof(MA_HISTORICO_MONEDAS))]
        public IHttpActionResult PostMA_HISTORICO_MONEDAS(MA_HISTORICO_MONEDAS mA_HISTORICO_MONEDAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_HISTORICO_MONEDAS.Add(mA_HISTORICO_MONEDAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_HISTORICO_MONEDAS.ID }, mA_HISTORICO_MONEDAS);
        }

        // DELETE: api/MA_HISTORICO_MONEDAS/5
        [ResponseType(typeof(MA_HISTORICO_MONEDAS))]
        public IHttpActionResult DeleteMA_HISTORICO_MONEDAS(decimal id)
        {
            MA_HISTORICO_MONEDAS mA_HISTORICO_MONEDAS = db.MA_HISTORICO_MONEDAS.Find(id);
            if (mA_HISTORICO_MONEDAS == null)
            {
                return NotFound();
            }

            db.MA_HISTORICO_MONEDAS.Remove(mA_HISTORICO_MONEDAS);
            db.SaveChanges();

            return Ok(mA_HISTORICO_MONEDAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_HISTORICO_MONEDASExists(decimal id)
        {
            return db.MA_HISTORICO_MONEDAS.Count(e => e.ID == id) > 0;
        }
    }
}