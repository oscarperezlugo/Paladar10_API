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
    public class MA_VENTAS_IMPUESTOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_VENTAS_IMPUESTOS
        public IQueryable<MA_VENTAS_IMPUESTOS> GetMA_VENTAS_IMPUESTOS()
        {
            return db.MA_VENTAS_IMPUESTOS;
        }

        // GET: api/MA_VENTAS_IMPUESTOS/5
        [ResponseType(typeof(MA_VENTAS_IMPUESTOS))]
        public IHttpActionResult GetMA_VENTAS_IMPUESTOS(string id)
        {
            MA_VENTAS_IMPUESTOS mA_VENTAS_IMPUESTOS = db.MA_VENTAS_IMPUESTOS.Find(id);
            if (mA_VENTAS_IMPUESTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_VENTAS_IMPUESTOS);
        }

        // PUT: api/MA_VENTAS_IMPUESTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_VENTAS_IMPUESTOS(string id, MA_VENTAS_IMPUESTOS mA_VENTAS_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_VENTAS_IMPUESTOS.cs_documento)
            {
                return BadRequest();
            }

            db.Entry(mA_VENTAS_IMPUESTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_VENTAS_IMPUESTOSExists(id))
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

        // POST: api/MA_VENTAS_IMPUESTOS
        [ResponseType(typeof(MA_VENTAS_IMPUESTOS))]
        public IHttpActionResult PostMA_VENTAS_IMPUESTOS(MA_VENTAS_IMPUESTOS mA_VENTAS_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_VENTAS_IMPUESTOS.Add(mA_VENTAS_IMPUESTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_VENTAS_IMPUESTOSExists(mA_VENTAS_IMPUESTOS.cs_documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_VENTAS_IMPUESTOS.cs_documento }, mA_VENTAS_IMPUESTOS);
        }

        // DELETE: api/MA_VENTAS_IMPUESTOS/5
        [ResponseType(typeof(MA_VENTAS_IMPUESTOS))]
        public IHttpActionResult DeleteMA_VENTAS_IMPUESTOS(string id)
        {
            MA_VENTAS_IMPUESTOS mA_VENTAS_IMPUESTOS = db.MA_VENTAS_IMPUESTOS.Find(id);
            if (mA_VENTAS_IMPUESTOS == null)
            {
                return NotFound();
            }

            db.MA_VENTAS_IMPUESTOS.Remove(mA_VENTAS_IMPUESTOS);
            db.SaveChanges();

            return Ok(mA_VENTAS_IMPUESTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_VENTAS_IMPUESTOSExists(string id)
        {
            return db.MA_VENTAS_IMPUESTOS.Count(e => e.cs_documento == id) > 0;
        }
    }
}