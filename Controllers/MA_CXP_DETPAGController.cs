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
    public class MA_CXP_DETPAGController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CXP_DETPAG
        public IQueryable<MA_CXP_DETPAG> GetMA_CXP_DETPAG()
        {
            return db.MA_CXP_DETPAG;
        }

        // GET: api/MA_CXP_DETPAG/5
        [ResponseType(typeof(MA_CXP_DETPAG))]
        public IHttpActionResult GetMA_CXP_DETPAG(string id)
        {
            MA_CXP_DETPAG mA_CXP_DETPAG = db.MA_CXP_DETPAG.Find(id);
            if (mA_CXP_DETPAG == null)
            {
                return NotFound();
            }

            return Ok(mA_CXP_DETPAG);
        }

        // PUT: api/MA_CXP_DETPAG/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CXP_DETPAG(string id, MA_CXP_DETPAG mA_CXP_DETPAG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CXP_DETPAG.C_CONCEPTO)
            {
                return BadRequest();
            }

            db.Entry(mA_CXP_DETPAG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CXP_DETPAGExists(id))
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

        // POST: api/MA_CXP_DETPAG
        [ResponseType(typeof(MA_CXP_DETPAG))]
        public IHttpActionResult PostMA_CXP_DETPAG(MA_CXP_DETPAG mA_CXP_DETPAG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CXP_DETPAG.Add(mA_CXP_DETPAG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CXP_DETPAGExists(mA_CXP_DETPAG.C_CONCEPTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CXP_DETPAG.C_CONCEPTO }, mA_CXP_DETPAG);
        }

        // DELETE: api/MA_CXP_DETPAG/5
        [ResponseType(typeof(MA_CXP_DETPAG))]
        public IHttpActionResult DeleteMA_CXP_DETPAG(string id)
        {
            MA_CXP_DETPAG mA_CXP_DETPAG = db.MA_CXP_DETPAG.Find(id);
            if (mA_CXP_DETPAG == null)
            {
                return NotFound();
            }

            db.MA_CXP_DETPAG.Remove(mA_CXP_DETPAG);
            db.SaveChanges();

            return Ok(mA_CXP_DETPAG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CXP_DETPAGExists(string id)
        {
            return db.MA_CXP_DETPAG.Count(e => e.C_CONCEPTO == id) > 0;
        }
    }
}