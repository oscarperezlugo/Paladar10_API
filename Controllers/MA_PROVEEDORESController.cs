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
    public class MA_PROVEEDORESController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_PROVEEDORES
        public IQueryable<MA_PROVEEDORES> GetMA_PROVEEDORES()
        {
            return db.MA_PROVEEDORES;
        }

        // GET: api/MA_PROVEEDORES/5
        [ResponseType(typeof(MA_PROVEEDORES))]
        public IHttpActionResult GetMA_PROVEEDORES(string id)
        {
            MA_PROVEEDORES mA_PROVEEDORES = db.MA_PROVEEDORES.Find(id);
            if (mA_PROVEEDORES == null)
            {
                return NotFound();
            }

            return Ok(mA_PROVEEDORES);
        }

        // PUT: api/MA_PROVEEDORES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PROVEEDORES(string id, MA_PROVEEDORES mA_PROVEEDORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PROVEEDORES.c_codproveed)
            {
                return BadRequest();
            }

            db.Entry(mA_PROVEEDORES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PROVEEDORESExists(id))
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

        // POST: api/MA_PROVEEDORES
        [ResponseType(typeof(MA_PROVEEDORES))]
        public IHttpActionResult PostMA_PROVEEDORES(MA_PROVEEDORES mA_PROVEEDORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PROVEEDORES.Add(mA_PROVEEDORES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PROVEEDORESExists(mA_PROVEEDORES.c_codproveed))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PROVEEDORES.c_codproveed }, mA_PROVEEDORES);
        }

        // DELETE: api/MA_PROVEEDORES/5
        [ResponseType(typeof(MA_PROVEEDORES))]
        public IHttpActionResult DeleteMA_PROVEEDORES(string id)
        {
            MA_PROVEEDORES mA_PROVEEDORES = db.MA_PROVEEDORES.Find(id);
            if (mA_PROVEEDORES == null)
            {
                return NotFound();
            }

            db.MA_PROVEEDORES.Remove(mA_PROVEEDORES);
            db.SaveChanges();

            return Ok(mA_PROVEEDORES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PROVEEDORESExists(string id)
        {
            return db.MA_PROVEEDORES.Count(e => e.c_codproveed == id) > 0;
        }
    }
}