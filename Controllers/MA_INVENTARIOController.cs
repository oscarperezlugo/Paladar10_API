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
    public class MA_INVENTARIOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_INVENTARIO
        public IQueryable<MA_INVENTARIO> GetMA_INVENTARIO()
        {
            return db.MA_INVENTARIO;
        }

        // GET: api/MA_INVENTARIO/5
        [ResponseType(typeof(MA_INVENTARIO))]
        public IHttpActionResult GetMA_INVENTARIO(string id)
        {
            MA_INVENTARIO mA_INVENTARIO = db.MA_INVENTARIO.Find(id);
            if (mA_INVENTARIO == null)
            {
                return NotFound();
            }

            return Ok(mA_INVENTARIO);
        }

        // PUT: api/MA_INVENTARIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_INVENTARIO(string id, MA_INVENTARIO mA_INVENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_INVENTARIO.c_CONCEPTO)
            {
                return BadRequest();
            }

            db.Entry(mA_INVENTARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_INVENTARIOExists(id))
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

        // POST: api/MA_INVENTARIO
        [ResponseType(typeof(MA_INVENTARIO))]
        public IHttpActionResult PostMA_INVENTARIO(MA_INVENTARIO mA_INVENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_INVENTARIO.Add(mA_INVENTARIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_INVENTARIOExists(mA_INVENTARIO.c_CONCEPTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_INVENTARIO.c_CONCEPTO }, mA_INVENTARIO);
        }

        // DELETE: api/MA_INVENTARIO/5
        [ResponseType(typeof(MA_INVENTARIO))]
        public IHttpActionResult DeleteMA_INVENTARIO(string id)
        {
            MA_INVENTARIO mA_INVENTARIO = db.MA_INVENTARIO.Find(id);
            if (mA_INVENTARIO == null)
            {
                return NotFound();
            }

            db.MA_INVENTARIO.Remove(mA_INVENTARIO);
            db.SaveChanges();

            return Ok(mA_INVENTARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_INVENTARIOExists(string id)
        {
            return db.MA_INVENTARIO.Count(e => e.c_CONCEPTO == id) > 0;
        }
    }
}