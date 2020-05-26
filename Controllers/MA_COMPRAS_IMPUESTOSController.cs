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
    public class MA_COMPRAS_IMPUESTOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_COMPRAS_IMPUESTOS
        public IQueryable<MA_COMPRAS_IMPUESTOS> GetMA_COMPRAS_IMPUESTOS()
        {
            return db.MA_COMPRAS_IMPUESTOS;
        }

        // GET: api/MA_COMPRAS_IMPUESTOS/5
        [ResponseType(typeof(MA_COMPRAS_IMPUESTOS))]
        public IHttpActionResult GetMA_COMPRAS_IMPUESTOS(string id)
        {
            MA_COMPRAS_IMPUESTOS mA_COMPRAS_IMPUESTOS = db.MA_COMPRAS_IMPUESTOS.Find(id);
            if (mA_COMPRAS_IMPUESTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_COMPRAS_IMPUESTOS);
        }

        // PUT: api/MA_COMPRAS_IMPUESTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_COMPRAS_IMPUESTOS(string id, MA_COMPRAS_IMPUESTOS mA_COMPRAS_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_COMPRAS_IMPUESTOS.cs_documento)
            {
                return BadRequest();
            }

            db.Entry(mA_COMPRAS_IMPUESTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_COMPRAS_IMPUESTOSExists(id))
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

        // POST: api/MA_COMPRAS_IMPUESTOS
        [ResponseType(typeof(MA_COMPRAS_IMPUESTOS))]
        public IHttpActionResult PostMA_COMPRAS_IMPUESTOS(MA_COMPRAS_IMPUESTOS mA_COMPRAS_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_COMPRAS_IMPUESTOS.Add(mA_COMPRAS_IMPUESTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_COMPRAS_IMPUESTOSExists(mA_COMPRAS_IMPUESTOS.cs_documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_COMPRAS_IMPUESTOS.cs_documento }, mA_COMPRAS_IMPUESTOS);
        }

        // DELETE: api/MA_COMPRAS_IMPUESTOS/5
        [ResponseType(typeof(MA_COMPRAS_IMPUESTOS))]
        public IHttpActionResult DeleteMA_COMPRAS_IMPUESTOS(string id)
        {
            MA_COMPRAS_IMPUESTOS mA_COMPRAS_IMPUESTOS = db.MA_COMPRAS_IMPUESTOS.Find(id);
            if (mA_COMPRAS_IMPUESTOS == null)
            {
                return NotFound();
            }

            db.MA_COMPRAS_IMPUESTOS.Remove(mA_COMPRAS_IMPUESTOS);
            db.SaveChanges();

            return Ok(mA_COMPRAS_IMPUESTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_COMPRAS_IMPUESTOSExists(string id)
        {
            return db.MA_COMPRAS_IMPUESTOS.Count(e => e.cs_documento == id) > 0;
        }
    }
}