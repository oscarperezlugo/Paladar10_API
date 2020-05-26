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
    public class MA_VENTASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_VENTAS
        public IQueryable<MA_VENTAS> GetMA_VENTAS()
        {
            return db.MA_VENTAS;
        }

        // GET: api/MA_VENTAS/5
        [ResponseType(typeof(MA_VENTAS))]
        public IHttpActionResult GetMA_VENTAS(string id)
        {
            MA_VENTAS mA_VENTAS = db.MA_VENTAS.Find(id);
            if (mA_VENTAS == null)
            {
                return NotFound();
            }

            return Ok(mA_VENTAS);
        }

        // PUT: api/MA_VENTAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_VENTAS(string id, MA_VENTAS mA_VENTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_VENTAS.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(mA_VENTAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_VENTASExists(id))
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

        // POST: api/MA_VENTAS
        [ResponseType(typeof(MA_VENTAS))]
        public IHttpActionResult PostMA_VENTAS(MA_VENTAS mA_VENTAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_VENTAS.Add(mA_VENTAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_VENTASExists(mA_VENTAS.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_VENTAS.c_DOCUMENTO }, mA_VENTAS);
        }

        // DELETE: api/MA_VENTAS/5
        [ResponseType(typeof(MA_VENTAS))]
        public IHttpActionResult DeleteMA_VENTAS(string id)
        {
            MA_VENTAS mA_VENTAS = db.MA_VENTAS.Find(id);
            if (mA_VENTAS == null)
            {
                return NotFound();
            }

            db.MA_VENTAS.Remove(mA_VENTAS);
            db.SaveChanges();

            return Ok(mA_VENTAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_VENTASExists(string id)
        {
            return db.MA_VENTAS.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}