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
    public class MA_CXP_IMPUESTOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CXP_IMPUESTOS
        public IQueryable<MA_CXP_IMPUESTOS> GetMA_CXP_IMPUESTOS()
        {
            return db.MA_CXP_IMPUESTOS;
        }

        // GET: api/MA_CXP_IMPUESTOS/5
        [ResponseType(typeof(MA_CXP_IMPUESTOS))]
        public IHttpActionResult GetMA_CXP_IMPUESTOS(string id)
        {
            MA_CXP_IMPUESTOS mA_CXP_IMPUESTOS = db.MA_CXP_IMPUESTOS.Find(id);
            if (mA_CXP_IMPUESTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_CXP_IMPUESTOS);
        }

        // PUT: api/MA_CXP_IMPUESTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CXP_IMPUESTOS(string id, MA_CXP_IMPUESTOS mA_CXP_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CXP_IMPUESTOS.cs_documento)
            {
                return BadRequest();
            }

            db.Entry(mA_CXP_IMPUESTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CXP_IMPUESTOSExists(id))
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

        // POST: api/MA_CXP_IMPUESTOS
        [ResponseType(typeof(MA_CXP_IMPUESTOS))]
        public IHttpActionResult PostMA_CXP_IMPUESTOS(MA_CXP_IMPUESTOS mA_CXP_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CXP_IMPUESTOS.Add(mA_CXP_IMPUESTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CXP_IMPUESTOSExists(mA_CXP_IMPUESTOS.cs_documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CXP_IMPUESTOS.cs_documento }, mA_CXP_IMPUESTOS);
        }

        // DELETE: api/MA_CXP_IMPUESTOS/5
        [ResponseType(typeof(MA_CXP_IMPUESTOS))]
        public IHttpActionResult DeleteMA_CXP_IMPUESTOS(string id)
        {
            MA_CXP_IMPUESTOS mA_CXP_IMPUESTOS = db.MA_CXP_IMPUESTOS.Find(id);
            if (mA_CXP_IMPUESTOS == null)
            {
                return NotFound();
            }

            db.MA_CXP_IMPUESTOS.Remove(mA_CXP_IMPUESTOS);
            db.SaveChanges();

            return Ok(mA_CXP_IMPUESTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CXP_IMPUESTOSExists(string id)
        {
            return db.MA_CXP_IMPUESTOS.Count(e => e.cs_documento == id) > 0;
        }
    }
}