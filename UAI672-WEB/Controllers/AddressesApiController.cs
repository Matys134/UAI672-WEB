using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using UAI672_WEB.Models;

namespace UAI672_WEB.Controllers
{
    public class AddressesApiController : ODataController
    {
        private Model1 db = new Model1();

        // GET: odata/AddressesApi
        [EnableQuery]
        public IQueryable<Addresses> GetAddressesApi()
        {
            return db.Addresses;
        }

        // GET: odata/AddressesApi(5)
        [EnableQuery]
        public SingleResult<Addresses> GetAddresses([FromODataUri] int key)
        {
            return SingleResult.Create(db.Addresses.Where(addresses => addresses.Id == key));
        }

        // PUT: odata/AddressesApi(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Addresses> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Addresses addresses = await db.Addresses.FindAsync(key);
            if (addresses == null)
            {
                return NotFound();
            }

            patch.Put(addresses);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(addresses);
        }

        // POST: odata/AddressesApi
        public async Task<IHttpActionResult> Post(Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(addresses);
            await db.SaveChangesAsync();

            return Created(addresses);
        }

        // PATCH: odata/AddressesApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Addresses> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Addresses addresses = await db.Addresses.FindAsync(key);
            if (addresses == null)
            {
                return NotFound();
            }

            patch.Patch(addresses);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(addresses);
        }

        // DELETE: odata/AddressesApi(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Addresses addresses = await db.Addresses.FindAsync(key);
            if (addresses == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(addresses);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/AddressesApi(5)/Details
        [EnableQuery]
        public IQueryable<Details> GetDetails([FromODataUri] int key)
        {
            return db.Addresses.Where(m => m.Id == key).SelectMany(m => m.Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressesExists(int key)
        {
            return db.Addresses.Count(e => e.Id == key) > 0;
        }
    }
}
