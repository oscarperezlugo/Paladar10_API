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
    public class MA_CXPController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CXP
        public IQueryable<MA_CXP> GetMA_CXP()
        {
            return db.MA_CXP;
        }

        // GET: api/MA_CXP/5
        [ResponseType(typeof(MA_CXP))]
        public IHttpActionResult GetMA_CXP(string id)
        {
            MA_CXP mA_CXP = db.MA_CXP.Find(id);
            if (mA_CXP == null)
            {
                return NotFound();
            }

            return Ok(mA_CXP);
        }

        // PUT: api/MA_CXP/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CXP(string id, MA_CXP mA_CXP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CXP.C_Documento)
            {
                return BadRequest();
            }

            db.Entry(mA_CXP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CXPExists(id))
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

        // POST: api/MA_CXP
        [ResponseType(typeof(MA_CXP))]
        public IHttpActionResult PostMA_CXP(MA_CXP mA_CXP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CXP.Add(mA_CXP);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CXPExists(mA_CXP.C_Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CXP.C_Documento }, mA_CXP);
        }

        // DELETE: api/MA_CXP/5
        [ResponseType(typeof(MA_CXP))]
        public IHttpActionResult DeleteMA_CXP(string id)
        {
            MA_CXP mA_CXP = db.MA_CXP.Find(id);
            if (mA_CXP == null)
            {
                return NotFound();
            }

            db.MA_CXP.Remove(mA_CXP);
            db.SaveChanges();

            return Ok(mA_CXP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CXPExists(string id)
        {
            return db.MA_CXP.Count(e => e.C_Documento == id) > 0;
        }
    }
}