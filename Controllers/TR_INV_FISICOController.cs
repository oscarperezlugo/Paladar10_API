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
    public class TR_INV_FISICOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_INV_FISICO
        public IQueryable<TR_INV_FISICO> GetTR_INV_FISICO()
        {
            return db.TR_INV_FISICO;
        }

        // GET: api/TR_INV_FISICO/5
        [ResponseType(typeof(TR_INV_FISICO))]
        public IHttpActionResult GetTR_INV_FISICO(int id)
        {
            TR_INV_FISICO tR_INV_FISICO = db.TR_INV_FISICO.Find(id);
            if (tR_INV_FISICO == null)
            {
                return NotFound();
            }

            return Ok(tR_INV_FISICO);
        }

        // PUT: api/TR_INV_FISICO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_INV_FISICO(int id, TR_INV_FISICO tR_INV_FISICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_INV_FISICO.c_LINEA)
            {
                return BadRequest();
            }

            db.Entry(tR_INV_FISICO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_INV_FISICOExists(id))
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

        // POST: api/TR_INV_FISICO
        [ResponseType(typeof(TR_INV_FISICO))]
        public IHttpActionResult PostTR_INV_FISICO(TR_INV_FISICO tR_INV_FISICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_INV_FISICO.Add(tR_INV_FISICO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_INV_FISICOExists(tR_INV_FISICO.c_LINEA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_INV_FISICO.c_LINEA }, tR_INV_FISICO);
        }

        // DELETE: api/TR_INV_FISICO/5
        [ResponseType(typeof(TR_INV_FISICO))]
        public IHttpActionResult DeleteTR_INV_FISICO(int id)
        {
            TR_INV_FISICO tR_INV_FISICO = db.TR_INV_FISICO.Find(id);
            if (tR_INV_FISICO == null)
            {
                return NotFound();
            }

            db.TR_INV_FISICO.Remove(tR_INV_FISICO);
            db.SaveChanges();

            return Ok(tR_INV_FISICO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_INV_FISICOExists(int id)
        {
            return db.TR_INV_FISICO.Count(e => e.c_LINEA == id) > 0;
        }
    }
}