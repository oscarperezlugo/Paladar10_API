﻿using System;
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
    public class MA_PRODXPROVController : ApiController
    {
        private VAD10Entities db = new VAD10Entities();

        // GET: api/MA_PRODXPROV
        public IQueryable<MA_PRODXPROV> GetMA_PRODXPROV()
        {
            return db.MA_PRODXPROV;
        }

        // GET: api/MA_PRODXPROV/5
        [ResponseType(typeof(MA_PRODXPROV))]
        public IHttpActionResult GetMA_PRODXPROV(string id)
        {
            MA_PRODXPROV mA_PRODXPROV = db.MA_PRODXPROV.Find(id);
            if (mA_PRODXPROV == null)
            {
                return NotFound();
            }

            return Ok(mA_PRODXPROV);
        }

        // PUT: api/MA_PRODXPROV/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PRODXPROV(string id, MA_PRODXPROV mA_PRODXPROV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PRODXPROV.c_codigo)
            {
                return BadRequest();
            }

            db.Entry(mA_PRODXPROV).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PRODXPROVExists(id))
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

        // POST: api/MA_PRODXPROV
        [ResponseType(typeof(MA_PRODXPROV))]
        public IHttpActionResult PostMA_PRODXPROV(MA_PRODXPROV mA_PRODXPROV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PRODXPROV.Add(mA_PRODXPROV);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PRODXPROVExists(mA_PRODXPROV.c_codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PRODXPROV.c_codigo }, mA_PRODXPROV);
        }

        // DELETE: api/MA_PRODXPROV/5
        [ResponseType(typeof(MA_PRODXPROV))]
        public IHttpActionResult DeleteMA_PRODXPROV(string id)
        {
            MA_PRODXPROV mA_PRODXPROV = db.MA_PRODXPROV.Find(id);
            if (mA_PRODXPROV == null)
            {
                return NotFound();
            }

            db.MA_PRODXPROV.Remove(mA_PRODXPROV);
            db.SaveChanges();

            return Ok(mA_PRODXPROV);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PRODXPROVExists(string id)
        {
            return db.MA_PRODXPROV.Count(e => e.c_codigo == id) > 0;
        }
    }
}