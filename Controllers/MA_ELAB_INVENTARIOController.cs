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
    public class MA_ELAB_INVENTARIOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_ELAB_INVENTARIO
        public IQueryable<MA_ELAB_INVENTARIO> GetMA_ELAB_INVENTARIO()
        {
            return db.MA_ELAB_INVENTARIO;
        }

        // GET: api/MA_ELAB_INVENTARIO/5
        [ResponseType(typeof(MA_ELAB_INVENTARIO))]
        public IHttpActionResult GetMA_ELAB_INVENTARIO(string id)
        {
            MA_ELAB_INVENTARIO mA_ELAB_INVENTARIO = db.MA_ELAB_INVENTARIO.Find(id);
            if (mA_ELAB_INVENTARIO == null)
            {
                return NotFound();
            }

            return Ok(mA_ELAB_INVENTARIO);
        }

        // PUT: api/MA_ELAB_INVENTARIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ELAB_INVENTARIO(string id, MA_ELAB_INVENTARIO mA_ELAB_INVENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ELAB_INVENTARIO.c_coddeposito)
            {
                return BadRequest();
            }

            db.Entry(mA_ELAB_INVENTARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ELAB_INVENTARIOExists(id))
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

        // POST: api/MA_ELAB_INVENTARIO
        [ResponseType(typeof(MA_ELAB_INVENTARIO))]
        public IHttpActionResult PostMA_ELAB_INVENTARIO(MA_ELAB_INVENTARIO mA_ELAB_INVENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ELAB_INVENTARIO.Add(mA_ELAB_INVENTARIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ELAB_INVENTARIOExists(mA_ELAB_INVENTARIO.c_coddeposito))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ELAB_INVENTARIO.c_coddeposito }, mA_ELAB_INVENTARIO);
        }

        // DELETE: api/MA_ELAB_INVENTARIO/5
        [ResponseType(typeof(MA_ELAB_INVENTARIO))]
        public IHttpActionResult DeleteMA_ELAB_INVENTARIO(string id)
        {
            MA_ELAB_INVENTARIO mA_ELAB_INVENTARIO = db.MA_ELAB_INVENTARIO.Find(id);
            if (mA_ELAB_INVENTARIO == null)
            {
                return NotFound();
            }

            db.MA_ELAB_INVENTARIO.Remove(mA_ELAB_INVENTARIO);
            db.SaveChanges();

            return Ok(mA_ELAB_INVENTARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ELAB_INVENTARIOExists(string id)
        {
            return db.MA_ELAB_INVENTARIO.Count(e => e.c_coddeposito == id) > 0;
        }
    }
}