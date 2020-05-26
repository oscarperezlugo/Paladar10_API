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
    public class TR_VENTASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_VENTAS
        public IQueryable<TR_VENTAS> GetTR_VENTAS()
        {
            return db.TR_VENTAS;
        }

        // GET: api/TR_VENTAS/5
        [ResponseType(typeof(TR_VENTAS))]
        public IHttpActionResult GetTR_VENTAS(string id)
        {
            TR_VENTAS tR_VENTAS = db.TR_VENTAS.Find(id);
            if (tR_VENTAS == null)
            {
                return NotFound();
            }

            return Ok(tR_VENTAS);
        }

        // PUT: api/TR_VENTAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_VENTAS(string id, TR_VENTAS tR_VENTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_VENTAS.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(tR_VENTAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_VENTASExists(id))
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

        // POST: api/TR_VENTAS
        [ResponseType(typeof(TR_VENTAS))]
        public IHttpActionResult PostTR_VENTAS(TR_VENTAS tR_VENTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_VENTAS.Add(tR_VENTAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_VENTASExists(tR_VENTAS.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_VENTAS.c_DOCUMENTO }, tR_VENTAS);
        }

        // DELETE: api/TR_VENTAS/5
        [ResponseType(typeof(TR_VENTAS))]
        public IHttpActionResult DeleteTR_VENTAS(string id)
        {
            TR_VENTAS tR_VENTAS = db.TR_VENTAS.Find(id);
            if (tR_VENTAS == null)
            {
                return NotFound();
            }

            db.TR_VENTAS.Remove(tR_VENTAS);
            db.SaveChanges();

            return Ok(tR_VENTAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_VENTASExists(string id)
        {
            return db.TR_VENTAS.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}