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
    public class MA_CAMBIOCODIGOController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CAMBIOCODIGO
        public IQueryable<MA_CAMBIOCODIGO> GetMA_CAMBIOCODIGO()
        {
            return db.MA_CAMBIOCODIGO;
        }

        // GET: api/MA_CAMBIOCODIGO/5
        [ResponseType(typeof(MA_CAMBIOCODIGO))]
        public IHttpActionResult GetMA_CAMBIOCODIGO(string id)
        {
            MA_CAMBIOCODIGO mA_CAMBIOCODIGO = db.MA_CAMBIOCODIGO.Find(id);
            if (mA_CAMBIOCODIGO == null)
            {
                return NotFound();
            }

            return Ok(mA_CAMBIOCODIGO);
        }

        // PUT: api/MA_CAMBIOCODIGO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CAMBIOCODIGO(string id, MA_CAMBIOCODIGO mA_CAMBIOCODIGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CAMBIOCODIGO.c_Historico)
            {
                return BadRequest();
            }

            db.Entry(mA_CAMBIOCODIGO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CAMBIOCODIGOExists(id))
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

        // POST: api/MA_CAMBIOCODIGO
        [ResponseType(typeof(MA_CAMBIOCODIGO))]
        public IHttpActionResult PostMA_CAMBIOCODIGO(MA_CAMBIOCODIGO mA_CAMBIOCODIGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CAMBIOCODIGO.Add(mA_CAMBIOCODIGO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CAMBIOCODIGOExists(mA_CAMBIOCODIGO.c_Historico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CAMBIOCODIGO.c_Historico }, mA_CAMBIOCODIGO);
        }

        // DELETE: api/MA_CAMBIOCODIGO/5
        [ResponseType(typeof(MA_CAMBIOCODIGO))]
        public IHttpActionResult DeleteMA_CAMBIOCODIGO(string id)
        {
            MA_CAMBIOCODIGO mA_CAMBIOCODIGO = db.MA_CAMBIOCODIGO.Find(id);
            if (mA_CAMBIOCODIGO == null)
            {
                return NotFound();
            }

            db.MA_CAMBIOCODIGO.Remove(mA_CAMBIOCODIGO);
            db.SaveChanges();

            return Ok(mA_CAMBIOCODIGO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CAMBIOCODIGOExists(string id)
        {
            return db.MA_CAMBIOCODIGO.Count(e => e.c_Historico == id) > 0;
        }
    }
}