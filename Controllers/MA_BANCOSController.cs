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
    public class MA_BANCOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_BANCOS
        public IQueryable<MA_BANCOS> GetMA_BANCOS()
        {
            return db.MA_BANCOS;
        }

        // GET: api/MA_BANCOS/5
        [ResponseType(typeof(MA_BANCOS))]
        public IHttpActionResult GetMA_BANCOS(string id)
        {
            MA_BANCOS mA_BANCOS = db.MA_BANCOS.Find(id);
            if (mA_BANCOS == null)
            {
                return NotFound();
            }

            return Ok(mA_BANCOS);
        }

        // PUT: api/MA_BANCOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_BANCOS(string id, MA_BANCOS mA_BANCOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_BANCOS.c_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(mA_BANCOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_BANCOSExists(id))
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

        // POST: api/MA_BANCOS
        [ResponseType(typeof(MA_BANCOS))]
        public IHttpActionResult PostMA_BANCOS(MA_BANCOS mA_BANCOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_BANCOS.Add(mA_BANCOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_BANCOSExists(mA_BANCOS.c_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_BANCOS.c_CODIGO }, mA_BANCOS);
        }

        // DELETE: api/MA_BANCOS/5
        [ResponseType(typeof(MA_BANCOS))]
        public IHttpActionResult DeleteMA_BANCOS(string id)
        {
            MA_BANCOS mA_BANCOS = db.MA_BANCOS.Find(id);
            if (mA_BANCOS == null)
            {
                return NotFound();
            }

            db.MA_BANCOS.Remove(mA_BANCOS);
            db.SaveChanges();

            return Ok(mA_BANCOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_BANCOSExists(string id)
        {
            return db.MA_BANCOS.Count(e => e.c_CODIGO == id) > 0;
        }
    }
}