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
    public class MA_GRUPOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_GRUPOS
        public IQueryable<MA_GRUPOS> GetMA_GRUPOS()
        {
            return db.MA_GRUPOS;
        }

        // GET: api/MA_GRUPOS/5
        [ResponseType(typeof(MA_GRUPOS))]
        public IHttpActionResult GetMA_GRUPOS(string id)
        {
            MA_GRUPOS mA_GRUPOS = db.MA_GRUPOS.Find(id);
            if (mA_GRUPOS == null)
            {
                return NotFound();
            }

            return Ok(mA_GRUPOS);
        }

        // PUT: api/MA_GRUPOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_GRUPOS(string id, MA_GRUPOS mA_GRUPOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_GRUPOS.c_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(mA_GRUPOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_GRUPOSExists(id))
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

        // POST: api/MA_GRUPOS
        [ResponseType(typeof(MA_GRUPOS))]
        public IHttpActionResult PostMA_GRUPOS(MA_GRUPOS mA_GRUPOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_GRUPOS.Add(mA_GRUPOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_GRUPOSExists(mA_GRUPOS.c_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_GRUPOS.c_CODIGO }, mA_GRUPOS);
        }

        // DELETE: api/MA_GRUPOS/5
        [ResponseType(typeof(MA_GRUPOS))]
        public IHttpActionResult DeleteMA_GRUPOS(string id)
        {
            MA_GRUPOS mA_GRUPOS = db.MA_GRUPOS.Find(id);
            if (mA_GRUPOS == null)
            {
                return NotFound();
            }

            db.MA_GRUPOS.Remove(mA_GRUPOS);
            db.SaveChanges();

            return Ok(mA_GRUPOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_GRUPOSExists(string id)
        {
            return db.MA_GRUPOS.Count(e => e.c_CODIGO == id) > 0;
        }
    }
}