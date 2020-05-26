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
    public class MA_TABLAS_SYNCRONIZARController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_TABLAS_SYNCRONIZAR
        public IQueryable<MA_TABLAS_SYNCRONIZAR> GetMA_TABLAS_SYNCRONIZAR()
        {
            return db.MA_TABLAS_SYNCRONIZAR;
        }

        // GET: api/MA_TABLAS_SYNCRONIZAR/5
        [ResponseType(typeof(MA_TABLAS_SYNCRONIZAR))]
        public IHttpActionResult GetMA_TABLAS_SYNCRONIZAR(decimal id)
        {
            MA_TABLAS_SYNCRONIZAR mA_TABLAS_SYNCRONIZAR = db.MA_TABLAS_SYNCRONIZAR.Find(id);
            if (mA_TABLAS_SYNCRONIZAR == null)
            {
                return NotFound();
            }

            return Ok(mA_TABLAS_SYNCRONIZAR);
        }

        // PUT: api/MA_TABLAS_SYNCRONIZAR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_TABLAS_SYNCRONIZAR(decimal id, MA_TABLAS_SYNCRONIZAR mA_TABLAS_SYNCRONIZAR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_TABLAS_SYNCRONIZAR.cu_codtablassyncronizar)
            {
                return BadRequest();
            }

            db.Entry(mA_TABLAS_SYNCRONIZAR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_TABLAS_SYNCRONIZARExists(id))
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

        // POST: api/MA_TABLAS_SYNCRONIZAR
        [ResponseType(typeof(MA_TABLAS_SYNCRONIZAR))]
        public IHttpActionResult PostMA_TABLAS_SYNCRONIZAR(MA_TABLAS_SYNCRONIZAR mA_TABLAS_SYNCRONIZAR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_TABLAS_SYNCRONIZAR.Add(mA_TABLAS_SYNCRONIZAR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_TABLAS_SYNCRONIZAR.cu_codtablassyncronizar }, mA_TABLAS_SYNCRONIZAR);
        }

        // DELETE: api/MA_TABLAS_SYNCRONIZAR/5
        [ResponseType(typeof(MA_TABLAS_SYNCRONIZAR))]
        public IHttpActionResult DeleteMA_TABLAS_SYNCRONIZAR(decimal id)
        {
            MA_TABLAS_SYNCRONIZAR mA_TABLAS_SYNCRONIZAR = db.MA_TABLAS_SYNCRONIZAR.Find(id);
            if (mA_TABLAS_SYNCRONIZAR == null)
            {
                return NotFound();
            }

            db.MA_TABLAS_SYNCRONIZAR.Remove(mA_TABLAS_SYNCRONIZAR);
            db.SaveChanges();

            return Ok(mA_TABLAS_SYNCRONIZAR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_TABLAS_SYNCRONIZARExists(decimal id)
        {
            return db.MA_TABLAS_SYNCRONIZAR.Count(e => e.cu_codtablassyncronizar == id) > 0;
        }
    }
}