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
    public class MA_COMPRASController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_COMPRAS
        public IQueryable<MA_COMPRAS> GetMA_COMPRAS()
        {
            return db.MA_COMPRAS;
        }

        // GET: api/MA_COMPRAS/5
        [ResponseType(typeof(MA_COMPRAS))]
        public IHttpActionResult GetMA_COMPRAS(string id)
        {
            MA_COMPRAS mA_COMPRAS = db.MA_COMPRAS.Find(id);
            if (mA_COMPRAS == null)
            {
                return NotFound();
            }

            return Ok(mA_COMPRAS);
        }

        // PUT: api/MA_COMPRAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_COMPRAS(string id, MA_COMPRAS mA_COMPRAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_COMPRAS.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(mA_COMPRAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_COMPRASExists(id))
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

        // POST: api/MA_COMPRAS
        [ResponseType(typeof(MA_COMPRAS))]
        public IHttpActionResult PostMA_COMPRAS(MA_COMPRAS mA_COMPRAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_COMPRAS.Add(mA_COMPRAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_COMPRASExists(mA_COMPRAS.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_COMPRAS.c_DOCUMENTO }, mA_COMPRAS);
        }

        // DELETE: api/MA_COMPRAS/5
        [ResponseType(typeof(MA_COMPRAS))]
        public IHttpActionResult DeleteMA_COMPRAS(string id)
        {
            MA_COMPRAS mA_COMPRAS = db.MA_COMPRAS.Find(id);
            if (mA_COMPRAS == null)
            {
                return NotFound();
            }

            db.MA_COMPRAS.Remove(mA_COMPRAS);
            db.SaveChanges();

            return Ok(mA_COMPRAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_COMPRASExists(string id)
        {
            return db.MA_COMPRAS.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}