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
    public class MA_RTF_ESCController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_RTF_ESC
        public IQueryable<MA_RTF_ESC> GetMA_RTF_ESC()
        {
            return db.MA_RTF_ESC;
        }

        // GET: api/MA_RTF_ESC/5
        [ResponseType(typeof(MA_RTF_ESC))]
        public IHttpActionResult GetMA_RTF_ESC(string id)
        {
            MA_RTF_ESC mA_RTF_ESC = db.MA_RTF_ESC.Find(id);
            if (mA_RTF_ESC == null)
            {
                return NotFound();
            }

            return Ok(mA_RTF_ESC);
        }

        // PUT: api/MA_RTF_ESC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_RTF_ESC(string id, MA_RTF_ESC mA_RTF_ESC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_RTF_ESC.cs_codigo_Rtf)
            {
                return BadRequest();
            }

            db.Entry(mA_RTF_ESC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_RTF_ESCExists(id))
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

        // POST: api/MA_RTF_ESC
        [ResponseType(typeof(MA_RTF_ESC))]
        public IHttpActionResult PostMA_RTF_ESC(MA_RTF_ESC mA_RTF_ESC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_RTF_ESC.Add(mA_RTF_ESC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_RTF_ESCExists(mA_RTF_ESC.cs_codigo_Rtf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_RTF_ESC.cs_codigo_Rtf }, mA_RTF_ESC);
        }

        // DELETE: api/MA_RTF_ESC/5
        [ResponseType(typeof(MA_RTF_ESC))]
        public IHttpActionResult DeleteMA_RTF_ESC(string id)
        {
            MA_RTF_ESC mA_RTF_ESC = db.MA_RTF_ESC.Find(id);
            if (mA_RTF_ESC == null)
            {
                return NotFound();
            }

            db.MA_RTF_ESC.Remove(mA_RTF_ESC);
            db.SaveChanges();

            return Ok(mA_RTF_ESC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_RTF_ESCExists(string id)
        {
            return db.MA_RTF_ESC.Count(e => e.cs_codigo_Rtf == id) > 0;
        }
    }
}