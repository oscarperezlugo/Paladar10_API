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
    public class MA_FORMATO_BANCOS_ASOCIA_CAMPOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_FORMATO_BANCOS_ASOCIA_CAMPOS
        public IQueryable<MA_FORMATO_BANCOS_ASOCIA_CAMPOS> GetMA_FORMATO_BANCOS_ASOCIA_CAMPOS()
        {
            return db.MA_FORMATO_BANCOS_ASOCIA_CAMPOS;
        }

        // GET: api/MA_FORMATO_BANCOS_ASOCIA_CAMPOS/5
        [ResponseType(typeof(MA_FORMATO_BANCOS_ASOCIA_CAMPOS))]
        public IHttpActionResult GetMA_FORMATO_BANCOS_ASOCIA_CAMPOS(string id)
        {
            MA_FORMATO_BANCOS_ASOCIA_CAMPOS mA_FORMATO_BANCOS_ASOCIA_CAMPOS = db.MA_FORMATO_BANCOS_ASOCIA_CAMPOS.Find(id);
            if (mA_FORMATO_BANCOS_ASOCIA_CAMPOS == null)
            {
                return NotFound();
            }

            return Ok(mA_FORMATO_BANCOS_ASOCIA_CAMPOS);
        }

        // PUT: api/MA_FORMATO_BANCOS_ASOCIA_CAMPOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_FORMATO_BANCOS_ASOCIA_CAMPOS(string id, MA_FORMATO_BANCOS_ASOCIA_CAMPOS mA_FORMATO_BANCOS_ASOCIA_CAMPOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_FORMATO_BANCOS_ASOCIA_CAMPOS.cu_campoConsulta)
            {
                return BadRequest();
            }

            db.Entry(mA_FORMATO_BANCOS_ASOCIA_CAMPOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_FORMATO_BANCOS_ASOCIA_CAMPOSExists(id))
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

        // POST: api/MA_FORMATO_BANCOS_ASOCIA_CAMPOS
        [ResponseType(typeof(MA_FORMATO_BANCOS_ASOCIA_CAMPOS))]
        public IHttpActionResult PostMA_FORMATO_BANCOS_ASOCIA_CAMPOS(MA_FORMATO_BANCOS_ASOCIA_CAMPOS mA_FORMATO_BANCOS_ASOCIA_CAMPOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_FORMATO_BANCOS_ASOCIA_CAMPOS.Add(mA_FORMATO_BANCOS_ASOCIA_CAMPOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_FORMATO_BANCOS_ASOCIA_CAMPOSExists(mA_FORMATO_BANCOS_ASOCIA_CAMPOS.cu_campoConsulta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_FORMATO_BANCOS_ASOCIA_CAMPOS.cu_campoConsulta }, mA_FORMATO_BANCOS_ASOCIA_CAMPOS);
        }

        // DELETE: api/MA_FORMATO_BANCOS_ASOCIA_CAMPOS/5
        [ResponseType(typeof(MA_FORMATO_BANCOS_ASOCIA_CAMPOS))]
        public IHttpActionResult DeleteMA_FORMATO_BANCOS_ASOCIA_CAMPOS(string id)
        {
            MA_FORMATO_BANCOS_ASOCIA_CAMPOS mA_FORMATO_BANCOS_ASOCIA_CAMPOS = db.MA_FORMATO_BANCOS_ASOCIA_CAMPOS.Find(id);
            if (mA_FORMATO_BANCOS_ASOCIA_CAMPOS == null)
            {
                return NotFound();
            }

            db.MA_FORMATO_BANCOS_ASOCIA_CAMPOS.Remove(mA_FORMATO_BANCOS_ASOCIA_CAMPOS);
            db.SaveChanges();

            return Ok(mA_FORMATO_BANCOS_ASOCIA_CAMPOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_FORMATO_BANCOS_ASOCIA_CAMPOSExists(string id)
        {
            return db.MA_FORMATO_BANCOS_ASOCIA_CAMPOS.Count(e => e.cu_campoConsulta == id) > 0;
        }
    }
}