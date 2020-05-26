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
    public class TR_PEND_HISTORICO_MONEDASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_PEND_HISTORICO_MONEDAS
        public IQueryable<TR_PEND_HISTORICO_MONEDAS> GetTR_PEND_HISTORICO_MONEDAS()
        {
            return db.TR_PEND_HISTORICO_MONEDAS;
        }

        // GET: api/TR_PEND_HISTORICO_MONEDAS/5
        [ResponseType(typeof(TR_PEND_HISTORICO_MONEDAS))]
        public IHttpActionResult GetTR_PEND_HISTORICO_MONEDAS(decimal id)
        {
            TR_PEND_HISTORICO_MONEDAS tR_PEND_HISTORICO_MONEDAS = db.TR_PEND_HISTORICO_MONEDAS.Find(id);
            if (tR_PEND_HISTORICO_MONEDAS == null)
            {
                return NotFound();
            }

            return Ok(tR_PEND_HISTORICO_MONEDAS);
        }

        // PUT: api/TR_PEND_HISTORICO_MONEDAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_PEND_HISTORICO_MONEDAS(decimal id, TR_PEND_HISTORICO_MONEDAS tR_PEND_HISTORICO_MONEDAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_PEND_HISTORICO_MONEDAS.ID)
            {
                return BadRequest();
            }

            db.Entry(tR_PEND_HISTORICO_MONEDAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_PEND_HISTORICO_MONEDASExists(id))
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

        // POST: api/TR_PEND_HISTORICO_MONEDAS
        [ResponseType(typeof(TR_PEND_HISTORICO_MONEDAS))]
        public IHttpActionResult PostTR_PEND_HISTORICO_MONEDAS(TR_PEND_HISTORICO_MONEDAS tR_PEND_HISTORICO_MONEDAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_PEND_HISTORICO_MONEDAS.Add(tR_PEND_HISTORICO_MONEDAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tR_PEND_HISTORICO_MONEDAS.ID }, tR_PEND_HISTORICO_MONEDAS);
        }

        // DELETE: api/TR_PEND_HISTORICO_MONEDAS/5
        [ResponseType(typeof(TR_PEND_HISTORICO_MONEDAS))]
        public IHttpActionResult DeleteTR_PEND_HISTORICO_MONEDAS(decimal id)
        {
            TR_PEND_HISTORICO_MONEDAS tR_PEND_HISTORICO_MONEDAS = db.TR_PEND_HISTORICO_MONEDAS.Find(id);
            if (tR_PEND_HISTORICO_MONEDAS == null)
            {
                return NotFound();
            }

            db.TR_PEND_HISTORICO_MONEDAS.Remove(tR_PEND_HISTORICO_MONEDAS);
            db.SaveChanges();

            return Ok(tR_PEND_HISTORICO_MONEDAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_PEND_HISTORICO_MONEDASExists(decimal id)
        {
            return db.TR_PEND_HISTORICO_MONEDAS.Count(e => e.ID == id) > 0;
        }
    }
}