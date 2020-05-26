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
    public class MA_CLIENTESController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_CLIENTES
        public IQueryable<MA_CLIENTES> GetMA_CLIENTES()
        {
            return db.MA_CLIENTES;
        }

        // GET: api/MA_CLIENTES/5
        [ResponseType(typeof(MA_CLIENTES))]
        public IHttpActionResult GetMA_CLIENTES(string id)
        {
            MA_CLIENTES mA_CLIENTES = db.MA_CLIENTES.Find(id);
            if (mA_CLIENTES == null)
            {
                return NotFound();
            }

            return Ok(mA_CLIENTES);
        }

        // PUT: api/MA_CLIENTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CLIENTES(string id, MA_CLIENTES mA_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CLIENTES.c_CODCLIENTE)
            {
                return BadRequest();
            }

            db.Entry(mA_CLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CLIENTESExists(id))
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

        // POST: api/MA_CLIENTES
        [ResponseType(typeof(MA_CLIENTES))]
        public IHttpActionResult PostMA_CLIENTES(MA_CLIENTES mA_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CLIENTES.Add(mA_CLIENTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CLIENTESExists(mA_CLIENTES.c_CODCLIENTE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CLIENTES.c_CODCLIENTE }, mA_CLIENTES);
        }

        // DELETE: api/MA_CLIENTES/5
        [ResponseType(typeof(MA_CLIENTES))]
        public IHttpActionResult DeleteMA_CLIENTES(string id)
        {
            MA_CLIENTES mA_CLIENTES = db.MA_CLIENTES.Find(id);
            if (mA_CLIENTES == null)
            {
                return NotFound();
            }

            db.MA_CLIENTES.Remove(mA_CLIENTES);
            db.SaveChanges();

            return Ok(mA_CLIENTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CLIENTESExists(string id)
        {
            return db.MA_CLIENTES.Count(e => e.c_CODCLIENTE == id) > 0;
        }
    }
}