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
    public class MA_HISTORICO_COSTO_PRECIOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_HISTORICO_COSTO_PRECIO
        public IQueryable<MA_HISTORICO_COSTO_PRECIO> GetMA_HISTORICO_COSTO_PRECIO()
        {
            return db.MA_HISTORICO_COSTO_PRECIO;
        }

        // GET: api/MA_HISTORICO_COSTO_PRECIO/5
        [ResponseType(typeof(MA_HISTORICO_COSTO_PRECIO))]
        public IHttpActionResult GetMA_HISTORICO_COSTO_PRECIO(string id)
        {
            MA_HISTORICO_COSTO_PRECIO mA_HISTORICO_COSTO_PRECIO = db.MA_HISTORICO_COSTO_PRECIO.Find(id);
            if (mA_HISTORICO_COSTO_PRECIO == null)
            {
                return NotFound();
            }

            return Ok(mA_HISTORICO_COSTO_PRECIO);
        }

        // PUT: api/MA_HISTORICO_COSTO_PRECIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_HISTORICO_COSTO_PRECIO(string id, MA_HISTORICO_COSTO_PRECIO mA_HISTORICO_COSTO_PRECIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_HISTORICO_COSTO_PRECIO.c_Historico)
            {
                return BadRequest();
            }

            db.Entry(mA_HISTORICO_COSTO_PRECIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_HISTORICO_COSTO_PRECIOExists(id))
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

        // POST: api/MA_HISTORICO_COSTO_PRECIO
        [ResponseType(typeof(MA_HISTORICO_COSTO_PRECIO))]
        public IHttpActionResult PostMA_HISTORICO_COSTO_PRECIO(MA_HISTORICO_COSTO_PRECIO mA_HISTORICO_COSTO_PRECIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_HISTORICO_COSTO_PRECIO.Add(mA_HISTORICO_COSTO_PRECIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_HISTORICO_COSTO_PRECIOExists(mA_HISTORICO_COSTO_PRECIO.c_Historico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_HISTORICO_COSTO_PRECIO.c_Historico }, mA_HISTORICO_COSTO_PRECIO);
        }

        // DELETE: api/MA_HISTORICO_COSTO_PRECIO/5
        [ResponseType(typeof(MA_HISTORICO_COSTO_PRECIO))]
        public IHttpActionResult DeleteMA_HISTORICO_COSTO_PRECIO(string id)
        {
            MA_HISTORICO_COSTO_PRECIO mA_HISTORICO_COSTO_PRECIO = db.MA_HISTORICO_COSTO_PRECIO.Find(id);
            if (mA_HISTORICO_COSTO_PRECIO == null)
            {
                return NotFound();
            }

            db.MA_HISTORICO_COSTO_PRECIO.Remove(mA_HISTORICO_COSTO_PRECIO);
            db.SaveChanges();

            return Ok(mA_HISTORICO_COSTO_PRECIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_HISTORICO_COSTO_PRECIOExists(string id)
        {
            return db.MA_HISTORICO_COSTO_PRECIO.Count(e => e.c_Historico == id) > 0;
        }
    }
}