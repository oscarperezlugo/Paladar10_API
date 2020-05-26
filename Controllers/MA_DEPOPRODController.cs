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
    public class MA_DEPOPRODController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_DEPOPROD
        public IQueryable<MA_DEPOPROD> GetMA_DEPOPROD()
        {
            return db.MA_DEPOPROD;
        }

        // GET: api/MA_DEPOPROD/5
        [ResponseType(typeof(MA_DEPOPROD))]
        public IHttpActionResult GetMA_DEPOPROD(string id)
        {
            MA_DEPOPROD mA_DEPOPROD = db.MA_DEPOPROD.Find(id);
            if (mA_DEPOPROD == null)
            {
                return NotFound();
            }

            return Ok(mA_DEPOPROD);
        }

        // PUT: api/MA_DEPOPROD/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DEPOPROD(string id, MA_DEPOPROD mA_DEPOPROD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DEPOPROD.c_coddeposito)
            {
                return BadRequest();
            }

            db.Entry(mA_DEPOPROD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DEPOPRODExists(id))
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

        // POST: api/MA_DEPOPROD
        [ResponseType(typeof(MA_DEPOPROD))]
        public IHttpActionResult PostMA_DEPOPROD(MA_DEPOPROD mA_DEPOPROD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DEPOPROD.Add(mA_DEPOPROD);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DEPOPRODExists(mA_DEPOPROD.c_coddeposito))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DEPOPROD.c_coddeposito }, mA_DEPOPROD);
        }

        // DELETE: api/MA_DEPOPROD/5
        [ResponseType(typeof(MA_DEPOPROD))]
        public IHttpActionResult DeleteMA_DEPOPROD(string id)
        {
            MA_DEPOPROD mA_DEPOPROD = db.MA_DEPOPROD.Find(id);
            if (mA_DEPOPROD == null)
            {
                return NotFound();
            }

            db.MA_DEPOPROD.Remove(mA_DEPOPROD);
            db.SaveChanges();

            return Ok(mA_DEPOPROD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DEPOPRODExists(string id)
        {
            return db.MA_DEPOPROD.Count(e => e.c_coddeposito == id) > 0;
        }
    }
}