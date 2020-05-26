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
    public class TR_INVENTARIOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_INVENTARIO
        public IQueryable<TR_INVENTARIO> GetTR_INVENTARIO()
        {
            return db.TR_INVENTARIO;
        }

        // GET: api/TR_INVENTARIO/5
        [ResponseType(typeof(TR_INVENTARIO))]
        public IHttpActionResult GetTR_INVENTARIO(int id)
        {
            TR_INVENTARIO tR_INVENTARIO = db.TR_INVENTARIO.Find(id);
            if (tR_INVENTARIO == null)
            {
                return NotFound();
            }

            return Ok(tR_INVENTARIO);
        }

        // PUT: api/TR_INVENTARIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_INVENTARIO(int id, TR_INVENTARIO tR_INVENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_INVENTARIO.c_LINEA)
            {
                return BadRequest();
            }

            db.Entry(tR_INVENTARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_INVENTARIOExists(id))
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

        // POST: api/TR_INVENTARIO
        [ResponseType(typeof(TR_INVENTARIO))]
        public IHttpActionResult PostTR_INVENTARIO(TR_INVENTARIO tR_INVENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_INVENTARIO.Add(tR_INVENTARIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_INVENTARIOExists(tR_INVENTARIO.c_LINEA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_INVENTARIO.c_LINEA }, tR_INVENTARIO);
        }

        // DELETE: api/TR_INVENTARIO/5
        [ResponseType(typeof(TR_INVENTARIO))]
        public IHttpActionResult DeleteTR_INVENTARIO(int id)
        {
            TR_INVENTARIO tR_INVENTARIO = db.TR_INVENTARIO.Find(id);
            if (tR_INVENTARIO == null)
            {
                return NotFound();
            }

            db.TR_INVENTARIO.Remove(tR_INVENTARIO);
            db.SaveChanges();

            return Ok(tR_INVENTARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_INVENTARIOExists(int id)
        {
            return db.TR_INVENTARIO.Count(e => e.c_LINEA == id) > 0;
        }
    }
}