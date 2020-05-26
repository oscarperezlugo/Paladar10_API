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
    public class MA_DEPARTAMENTOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_DEPARTAMENTOS
        public IQueryable<MA_DEPARTAMENTOS> GetMA_DEPARTAMENTOS()
        {
            return db.MA_DEPARTAMENTOS;
        }

        // GET: api/MA_DEPARTAMENTOS/5
        [ResponseType(typeof(MA_DEPARTAMENTOS))]
        public IHttpActionResult GetMA_DEPARTAMENTOS(string id)
        {
            MA_DEPARTAMENTOS mA_DEPARTAMENTOS = db.MA_DEPARTAMENTOS.Find(id);
            if (mA_DEPARTAMENTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_DEPARTAMENTOS);
        }

        // PUT: api/MA_DEPARTAMENTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DEPARTAMENTOS(string id, MA_DEPARTAMENTOS mA_DEPARTAMENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DEPARTAMENTOS.C_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(mA_DEPARTAMENTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DEPARTAMENTOSExists(id))
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

        // POST: api/MA_DEPARTAMENTOS
        [ResponseType(typeof(MA_DEPARTAMENTOS))]
        public IHttpActionResult PostMA_DEPARTAMENTOS(MA_DEPARTAMENTOS mA_DEPARTAMENTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DEPARTAMENTOS.Add(mA_DEPARTAMENTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DEPARTAMENTOSExists(mA_DEPARTAMENTOS.C_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DEPARTAMENTOS.C_CODIGO }, mA_DEPARTAMENTOS);
        }

        // DELETE: api/MA_DEPARTAMENTOS/5
        [ResponseType(typeof(MA_DEPARTAMENTOS))]
        public IHttpActionResult DeleteMA_DEPARTAMENTOS(string id)
        {
            MA_DEPARTAMENTOS mA_DEPARTAMENTOS = db.MA_DEPARTAMENTOS.Find(id);
            if (mA_DEPARTAMENTOS == null)
            {
                return NotFound();
            }

            db.MA_DEPARTAMENTOS.Remove(mA_DEPARTAMENTOS);
            db.SaveChanges();

            return Ok(mA_DEPARTAMENTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DEPARTAMENTOSExists(string id)
        {
            return db.MA_DEPARTAMENTOS.Count(e => e.C_CODIGO == id) > 0;
        }
    }
}