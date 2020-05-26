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
    public class MA_CORRELATIVOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CORRELATIVOS
        public IQueryable<MA_CORRELATIVOS> GetMA_CORRELATIVOS()
        {
            return db.MA_CORRELATIVOS;
        }

        // GET: api/MA_CORRELATIVOS/5
        [ResponseType(typeof(MA_CORRELATIVOS))]
        public IHttpActionResult GetMA_CORRELATIVOS(string id)
        {
            MA_CORRELATIVOS mA_CORRELATIVOS = db.MA_CORRELATIVOS.Find(id);
            if (mA_CORRELATIVOS == null)
            {
                return NotFound();
            }

            return Ok(mA_CORRELATIVOS);
        }

        // PUT: api/MA_CORRELATIVOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CORRELATIVOS(string id, MA_CORRELATIVOS mA_CORRELATIVOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CORRELATIVOS.cu_Campo)
            {
                return BadRequest();
            }

            db.Entry(mA_CORRELATIVOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CORRELATIVOSExists(id))
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

        // POST: api/MA_CORRELATIVOS
        [ResponseType(typeof(MA_CORRELATIVOS))]
        public IHttpActionResult PostMA_CORRELATIVOS(MA_CORRELATIVOS mA_CORRELATIVOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CORRELATIVOS.Add(mA_CORRELATIVOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CORRELATIVOSExists(mA_CORRELATIVOS.cu_Campo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CORRELATIVOS.cu_Campo }, mA_CORRELATIVOS);
        }

        // DELETE: api/MA_CORRELATIVOS/5
        [ResponseType(typeof(MA_CORRELATIVOS))]
        public IHttpActionResult DeleteMA_CORRELATIVOS(string id)
        {
            MA_CORRELATIVOS mA_CORRELATIVOS = db.MA_CORRELATIVOS.Find(id);
            if (mA_CORRELATIVOS == null)
            {
                return NotFound();
            }

            db.MA_CORRELATIVOS.Remove(mA_CORRELATIVOS);
            db.SaveChanges();

            return Ok(mA_CORRELATIVOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CORRELATIVOSExists(string id)
        {
            return db.MA_CORRELATIVOS.Count(e => e.cu_Campo == id) > 0;
        }
    }
}