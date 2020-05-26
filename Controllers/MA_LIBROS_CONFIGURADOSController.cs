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
    public class MA_LIBROS_CONFIGURADOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_LIBROS_CONFIGURADOS
        public IQueryable<MA_LIBROS_CONFIGURADOS> GetMA_LIBROS_CONFIGURADOS()
        {
            return db.MA_LIBROS_CONFIGURADOS;
        }

        // GET: api/MA_LIBROS_CONFIGURADOS/5
        [ResponseType(typeof(MA_LIBROS_CONFIGURADOS))]
        public IHttpActionResult GetMA_LIBROS_CONFIGURADOS(string id)
        {
            MA_LIBROS_CONFIGURADOS mA_LIBROS_CONFIGURADOS = db.MA_LIBROS_CONFIGURADOS.Find(id);
            if (mA_LIBROS_CONFIGURADOS == null)
            {
                return NotFound();
            }

            return Ok(mA_LIBROS_CONFIGURADOS);
        }

        // PUT: api/MA_LIBROS_CONFIGURADOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_LIBROS_CONFIGURADOS(string id, MA_LIBROS_CONFIGURADOS mA_LIBROS_CONFIGURADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_LIBROS_CONFIGURADOS.cs_documento)
            {
                return BadRequest();
            }

            db.Entry(mA_LIBROS_CONFIGURADOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_LIBROS_CONFIGURADOSExists(id))
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

        // POST: api/MA_LIBROS_CONFIGURADOS
        [ResponseType(typeof(MA_LIBROS_CONFIGURADOS))]
        public IHttpActionResult PostMA_LIBROS_CONFIGURADOS(MA_LIBROS_CONFIGURADOS mA_LIBROS_CONFIGURADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_LIBROS_CONFIGURADOS.Add(mA_LIBROS_CONFIGURADOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_LIBROS_CONFIGURADOSExists(mA_LIBROS_CONFIGURADOS.cs_documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_LIBROS_CONFIGURADOS.cs_documento }, mA_LIBROS_CONFIGURADOS);
        }

        // DELETE: api/MA_LIBROS_CONFIGURADOS/5
        [ResponseType(typeof(MA_LIBROS_CONFIGURADOS))]
        public IHttpActionResult DeleteMA_LIBROS_CONFIGURADOS(string id)
        {
            MA_LIBROS_CONFIGURADOS mA_LIBROS_CONFIGURADOS = db.MA_LIBROS_CONFIGURADOS.Find(id);
            if (mA_LIBROS_CONFIGURADOS == null)
            {
                return NotFound();
            }

            db.MA_LIBROS_CONFIGURADOS.Remove(mA_LIBROS_CONFIGURADOS);
            db.SaveChanges();

            return Ok(mA_LIBROS_CONFIGURADOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_LIBROS_CONFIGURADOSExists(string id)
        {
            return db.MA_LIBROS_CONFIGURADOS.Count(e => e.cs_documento == id) > 0;
        }
    }
}