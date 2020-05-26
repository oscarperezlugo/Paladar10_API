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
    public class TR_LIBROS_CONFIGURADOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/TR_LIBROS_CONFIGURADOS
        public IQueryable<TR_LIBROS_CONFIGURADOS> GetTR_LIBROS_CONFIGURADOS()
        {
            return db.TR_LIBROS_CONFIGURADOS;
        }

        // GET: api/TR_LIBROS_CONFIGURADOS/5
        [ResponseType(typeof(TR_LIBROS_CONFIGURADOS))]
        public IHttpActionResult GetTR_LIBROS_CONFIGURADOS(string id)
        {
            TR_LIBROS_CONFIGURADOS tR_LIBROS_CONFIGURADOS = db.TR_LIBROS_CONFIGURADOS.Find(id);
            if (tR_LIBROS_CONFIGURADOS == null)
            {
                return NotFound();
            }

            return Ok(tR_LIBROS_CONFIGURADOS);
        }

        // PUT: api/TR_LIBROS_CONFIGURADOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_LIBROS_CONFIGURADOS(string id, TR_LIBROS_CONFIGURADOS tR_LIBROS_CONFIGURADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_LIBROS_CONFIGURADOS.CS_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(tR_LIBROS_CONFIGURADOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_LIBROS_CONFIGURADOSExists(id))
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

        // POST: api/TR_LIBROS_CONFIGURADOS
        [ResponseType(typeof(TR_LIBROS_CONFIGURADOS))]
        public IHttpActionResult PostTR_LIBROS_CONFIGURADOS(TR_LIBROS_CONFIGURADOS tR_LIBROS_CONFIGURADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_LIBROS_CONFIGURADOS.Add(tR_LIBROS_CONFIGURADOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_LIBROS_CONFIGURADOSExists(tR_LIBROS_CONFIGURADOS.CS_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_LIBROS_CONFIGURADOS.CS_DOCUMENTO }, tR_LIBROS_CONFIGURADOS);
        }

        // DELETE: api/TR_LIBROS_CONFIGURADOS/5
        [ResponseType(typeof(TR_LIBROS_CONFIGURADOS))]
        public IHttpActionResult DeleteTR_LIBROS_CONFIGURADOS(string id)
        {
            TR_LIBROS_CONFIGURADOS tR_LIBROS_CONFIGURADOS = db.TR_LIBROS_CONFIGURADOS.Find(id);
            if (tR_LIBROS_CONFIGURADOS == null)
            {
                return NotFound();
            }

            db.TR_LIBROS_CONFIGURADOS.Remove(tR_LIBROS_CONFIGURADOS);
            db.SaveChanges();

            return Ok(tR_LIBROS_CONFIGURADOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_LIBROS_CONFIGURADOSExists(string id)
        {
            return db.TR_LIBROS_CONFIGURADOS.Count(e => e.CS_DOCUMENTO == id) > 0;
        }
    }
}