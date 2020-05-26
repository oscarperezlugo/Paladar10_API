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
    public class MA_REGLASDENEGOCIO_MODULOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_REGLASDENEGOCIO_MODULOS
        public IQueryable<MA_REGLASDENEGOCIO_MODULOS> GetMA_REGLASDENEGOCIO_MODULOS()
        {
            return db.MA_REGLASDENEGOCIO_MODULOS;
        }

        // GET: api/MA_REGLASDENEGOCIO_MODULOS/5
        [ResponseType(typeof(MA_REGLASDENEGOCIO_MODULOS))]
        public IHttpActionResult GetMA_REGLASDENEGOCIO_MODULOS(string id)
        {
            MA_REGLASDENEGOCIO_MODULOS mA_REGLASDENEGOCIO_MODULOS = db.MA_REGLASDENEGOCIO_MODULOS.Find(id);
            if (mA_REGLASDENEGOCIO_MODULOS == null)
            {
                return NotFound();
            }

            return Ok(mA_REGLASDENEGOCIO_MODULOS);
        }

        // PUT: api/MA_REGLASDENEGOCIO_MODULOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_REGLASDENEGOCIO_MODULOS(string id, MA_REGLASDENEGOCIO_MODULOS mA_REGLASDENEGOCIO_MODULOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_REGLASDENEGOCIO_MODULOS.ID)
            {
                return BadRequest();
            }

            db.Entry(mA_REGLASDENEGOCIO_MODULOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_REGLASDENEGOCIO_MODULOSExists(id))
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

        // POST: api/MA_REGLASDENEGOCIO_MODULOS
        [ResponseType(typeof(MA_REGLASDENEGOCIO_MODULOS))]
        public IHttpActionResult PostMA_REGLASDENEGOCIO_MODULOS(MA_REGLASDENEGOCIO_MODULOS mA_REGLASDENEGOCIO_MODULOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_REGLASDENEGOCIO_MODULOS.Add(mA_REGLASDENEGOCIO_MODULOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_REGLASDENEGOCIO_MODULOSExists(mA_REGLASDENEGOCIO_MODULOS.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_REGLASDENEGOCIO_MODULOS.ID }, mA_REGLASDENEGOCIO_MODULOS);
        }

        // DELETE: api/MA_REGLASDENEGOCIO_MODULOS/5
        [ResponseType(typeof(MA_REGLASDENEGOCIO_MODULOS))]
        public IHttpActionResult DeleteMA_REGLASDENEGOCIO_MODULOS(string id)
        {
            MA_REGLASDENEGOCIO_MODULOS mA_REGLASDENEGOCIO_MODULOS = db.MA_REGLASDENEGOCIO_MODULOS.Find(id);
            if (mA_REGLASDENEGOCIO_MODULOS == null)
            {
                return NotFound();
            }

            db.MA_REGLASDENEGOCIO_MODULOS.Remove(mA_REGLASDENEGOCIO_MODULOS);
            db.SaveChanges();

            return Ok(mA_REGLASDENEGOCIO_MODULOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_REGLASDENEGOCIO_MODULOSExists(string id)
        {
            return db.MA_REGLASDENEGOCIO_MODULOS.Count(e => e.ID == id) > 0;
        }
    }
}