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
    public class MA_TABLAS_CONSOLIDARController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_TABLAS_CONSOLIDAR
        public IQueryable<MA_TABLAS_CONSOLIDAR> GetMA_TABLAS_CONSOLIDAR()
        {
            return db.MA_TABLAS_CONSOLIDAR;
        }

        // GET: api/MA_TABLAS_CONSOLIDAR/5
        [ResponseType(typeof(MA_TABLAS_CONSOLIDAR))]
        public IHttpActionResult GetMA_TABLAS_CONSOLIDAR(decimal id)
        {
            MA_TABLAS_CONSOLIDAR mA_TABLAS_CONSOLIDAR = db.MA_TABLAS_CONSOLIDAR.Find(id);
            if (mA_TABLAS_CONSOLIDAR == null)
            {
                return NotFound();
            }

            return Ok(mA_TABLAS_CONSOLIDAR);
        }

        // PUT: api/MA_TABLAS_CONSOLIDAR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_TABLAS_CONSOLIDAR(decimal id, MA_TABLAS_CONSOLIDAR mA_TABLAS_CONSOLIDAR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_TABLAS_CONSOLIDAR.cu_codtablassyncronizar)
            {
                return BadRequest();
            }

            db.Entry(mA_TABLAS_CONSOLIDAR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_TABLAS_CONSOLIDARExists(id))
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

        // POST: api/MA_TABLAS_CONSOLIDAR
        [ResponseType(typeof(MA_TABLAS_CONSOLIDAR))]
        public IHttpActionResult PostMA_TABLAS_CONSOLIDAR(MA_TABLAS_CONSOLIDAR mA_TABLAS_CONSOLIDAR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_TABLAS_CONSOLIDAR.Add(mA_TABLAS_CONSOLIDAR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_TABLAS_CONSOLIDARExists(mA_TABLAS_CONSOLIDAR.cu_codtablassyncronizar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_TABLAS_CONSOLIDAR.cu_codtablassyncronizar }, mA_TABLAS_CONSOLIDAR);
        }

        // DELETE: api/MA_TABLAS_CONSOLIDAR/5
        [ResponseType(typeof(MA_TABLAS_CONSOLIDAR))]
        public IHttpActionResult DeleteMA_TABLAS_CONSOLIDAR(decimal id)
        {
            MA_TABLAS_CONSOLIDAR mA_TABLAS_CONSOLIDAR = db.MA_TABLAS_CONSOLIDAR.Find(id);
            if (mA_TABLAS_CONSOLIDAR == null)
            {
                return NotFound();
            }

            db.MA_TABLAS_CONSOLIDAR.Remove(mA_TABLAS_CONSOLIDAR);
            db.SaveChanges();

            return Ok(mA_TABLAS_CONSOLIDAR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_TABLAS_CONSOLIDARExists(decimal id)
        {
            return db.MA_TABLAS_CONSOLIDAR.Count(e => e.cu_codtablassyncronizar == id) > 0;
        }
    }
}