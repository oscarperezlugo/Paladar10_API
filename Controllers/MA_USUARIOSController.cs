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
    public class MA_USUARIOSController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_USUARIOS
        public IQueryable<MA_USUARIOS> GetMA_USUARIOS()
        {
            return db.MA_USUARIOS;
        }

        // GET: api/MA_USUARIOS/5
        [ResponseType(typeof(MA_USUARIOS))]
        public IHttpActionResult GetMA_USUARIOS(string id)
        {
            MA_USUARIOS mA_USUARIOS = db.MA_USUARIOS.Find(id);
            if (mA_USUARIOS == null)
            {
                return NotFound();
            }

            return Ok(mA_USUARIOS);
        }

        // PUT: api/MA_USUARIOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_USUARIOS(string id, MA_USUARIOS mA_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_USUARIOS.codusuario)
            {
                return BadRequest();
            }

            db.Entry(mA_USUARIOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_USUARIOSExists(id))
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

        // POST: api/MA_USUARIOS
        [ResponseType(typeof(MA_USUARIOS))]
        public IHttpActionResult PostMA_USUARIOS(MA_USUARIOS mA_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_USUARIOS.Add(mA_USUARIOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_USUARIOSExists(mA_USUARIOS.codusuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_USUARIOS.codusuario }, mA_USUARIOS);
        }

        // DELETE: api/MA_USUARIOS/5
        [ResponseType(typeof(MA_USUARIOS))]
        public IHttpActionResult DeleteMA_USUARIOS(string id)
        {
            MA_USUARIOS mA_USUARIOS = db.MA_USUARIOS.Find(id);
            if (mA_USUARIOS == null)
            {
                return NotFound();
            }

            db.MA_USUARIOS.Remove(mA_USUARIOS);
            db.SaveChanges();

            return Ok(mA_USUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_USUARIOSExists(string id)
        {
            return db.MA_USUARIOS.Count(e => e.codusuario == id) > 0;
        }
    }
}