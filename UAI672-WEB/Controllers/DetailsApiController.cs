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
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using UAI672_WEB.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Details>("DetailsApi");
    builder.EntitySet<Addresses>("Addresses"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DetailsApiController : ODataController
    {
        private Model1 db = new Model1();

        // GET: odata/DetailsApi
        [EnableQuery]
        public IQueryable<Details> GetDetailsApi()
        {
            return db.Details;
        }

        // GET: odata/DetailsApi(5)
        [EnableQuery]
        public SingleResult<Details> GetDetails([FromODataUri] int key)
        {
            return SingleResult.Create(db.Details.Where(details => details.ID == key));
        }

        // PUT: odata/DetailsApi(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Details> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Details details = await db.Details.FindAsync(key);
            if (details == null)
            {
                return NotFound();
            }

            patch.Put(details);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(details);
        }

        // POST: odata/DetailsApi
        public async Task<IHttpActionResult> Post(Details details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Details.Add(details);
            await db.SaveChangesAsync();

            return Created(details);
        }

        // PATCH: odata/DetailsApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Details> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Details details = await db.Details.FindAsync(key);
            if (details == null)
            {
                return NotFound();
            }

            patch.Patch(details);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(details);
        }

        // DELETE: odata/DetailsApi(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Details details = await db.Details.FindAsync(key);
            if (details == null)
            {
                return NotFound();
            }

            db.Details.Remove(details);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/DetailsApi(5)/Addresses
        [EnableQuery]
        public SingleResult<Addresses> GetAddresses([FromODataUri] int key)
        {
            return SingleResult.Create(db.Details.Where(m => m.ID == key).Select(m => m.Addresses));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailsExists(int key)
        {
            return db.Details.Count(e => e.ID == key) > 0;
        }
    }
}
