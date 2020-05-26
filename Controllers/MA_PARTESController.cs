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
    public class MA_PARTESController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_PARTES
        public IQueryable<MA_PARTES> GetMA_PARTES()
        {
            return db.MA_PARTES;
        }

        // GET: api/MA_PARTES/5
        [ResponseType(typeof(MA_PARTES))]
        public IHttpActionResult GetMA_PARTES(string id)
        {
            MA_PARTES mA_PARTES = db.MA_PARTES.Find(id);
            if (mA_PARTES == null)
            {
                return NotFound();
            }

            return Ok(mA_PARTES);
        }

        // PUT: api/MA_PARTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PARTES(string id, MA_PARTES mA_PARTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PARTES.C_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(mA_PARTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PARTESExists(id))
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

        // POST: api/MA_PARTES
        [ResponseType(typeof(MA_PARTES))]
        public IHttpActionResult PostMA_PARTES(MA_PARTES mA_PARTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PARTES.Add(mA_PARTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PARTESExists(mA_PARTES.C_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PARTES.C_CODIGO }, mA_PARTES);
        }

        // DELETE: api/MA_PARTES/5
        [ResponseType(typeof(MA_PARTES))]
        public IHttpActionResult DeleteMA_PARTES(string id)
        {
            MA_PARTES mA_PARTES = db.MA_PARTES.Find(id);
            if (mA_PARTES == null)
            {
                return NotFound();
            }

            db.MA_PARTES.Remove(mA_PARTES);
            db.SaveChanges();

            return Ok(mA_PARTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PARTESExists(string id)
        {
            return db.MA_PARTES.Count(e => e.C_CODIGO == id) > 0;
        }
    }
}