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
    public class MA_IMPRESORA_ETIQUETAController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_IMPRESORA_ETIQUETA
        public IQueryable<MA_IMPRESORA_ETIQUETA> GetMA_IMPRESORA_ETIQUETA()
        {
            return db.MA_IMPRESORA_ETIQUETA;
        }

        // GET: api/MA_IMPRESORA_ETIQUETA/5
        [ResponseType(typeof(MA_IMPRESORA_ETIQUETA))]
        public IHttpActionResult GetMA_IMPRESORA_ETIQUETA(string id)
        {
            MA_IMPRESORA_ETIQUETA mA_IMPRESORA_ETIQUETA = db.MA_IMPRESORA_ETIQUETA.Find(id);
            if (mA_IMPRESORA_ETIQUETA == null)
            {
                return NotFound();
            }

            return Ok(mA_IMPRESORA_ETIQUETA);
        }

        // PUT: api/MA_IMPRESORA_ETIQUETA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_IMPRESORA_ETIQUETA(string id, MA_IMPRESORA_ETIQUETA mA_IMPRESORA_ETIQUETA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_IMPRESORA_ETIQUETA.cu_descripcion)
            {
                return BadRequest();
            }

            db.Entry(mA_IMPRESORA_ETIQUETA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_IMPRESORA_ETIQUETAExists(id))
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

        // POST: api/MA_IMPRESORA_ETIQUETA
        [ResponseType(typeof(MA_IMPRESORA_ETIQUETA))]
        public IHttpActionResult PostMA_IMPRESORA_ETIQUETA(MA_IMPRESORA_ETIQUETA mA_IMPRESORA_ETIQUETA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_IMPRESORA_ETIQUETA.Add(mA_IMPRESORA_ETIQUETA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_IMPRESORA_ETIQUETAExists(mA_IMPRESORA_ETIQUETA.cu_descripcion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_IMPRESORA_ETIQUETA.cu_descripcion }, mA_IMPRESORA_ETIQUETA);
        }

        // DELETE: api/MA_IMPRESORA_ETIQUETA/5
        [ResponseType(typeof(MA_IMPRESORA_ETIQUETA))]
        public IHttpActionResult DeleteMA_IMPRESORA_ETIQUETA(string id)
        {
            MA_IMPRESORA_ETIQUETA mA_IMPRESORA_ETIQUETA = db.MA_IMPRESORA_ETIQUETA.Find(id);
            if (mA_IMPRESORA_ETIQUETA == null)
            {
                return NotFound();
            }

            db.MA_IMPRESORA_ETIQUETA.Remove(mA_IMPRESORA_ETIQUETA);
            db.SaveChanges();

            return Ok(mA_IMPRESORA_ETIQUETA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_IMPRESORA_ETIQUETAExists(string id)
        {
            return db.MA_IMPRESORA_ETIQUETA.Count(e => e.cu_descripcion == id) > 0;
        }
    }
}