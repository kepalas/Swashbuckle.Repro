using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.DatabaseContext;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers.v1
{
    /// <summary>
    /// Represents a RESTful service of orders.
    /// </summary>
    [ApiVersion("1.0")]
    [ODataRoutePrefix("ChangeDocumentsSet")]
    public class ChangeDocumentsSetController : ODataController
    {
        private WAEntities _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDocumentsSetController"/> class.
        /// </summary>
        /// <param name="context">The <see cref="WAEntities">context</see> used to retrieve entries from the database.</param>
        public ChangeDocumentsSetController(WAEntities context)
        {
            _db = context;
        }

        /// <summary>
        /// Gets all ChangeDocumentsSet entries.
        /// </summary>
        /// <param name="options">The current OData query options.</param>
        /// <returns>All ChangeDocumentsSet entries.</returns>
        /// <response code="200">The successfully retrieved ChangeDocumentsSet entries.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<ChangeDocumentsSet>>), StatusCodes.Status200OK)]
        [EnableQuery]
        public IActionResult Get(ODataQueryOptions<ChangeDocumentsSet> options)
        {
            return Ok(options.ApplyTo(_db.ChangeDocumentsSet.AsQueryable()));
        }

        /// <summary>
        /// Gets a single ChangeDocumentsSet entry.
        /// </summary>
        /// <param name="changedocobjectclass">Part of the requested ChangeDocumentsSet entry identifier.</param>
        /// <param name="changedocobject">Part of the requested ChangeDocumentsSet entry identifier.</param>
        /// <param name="changedocument">Part of the requested ChangeDocumentsSet entry identifier.</param>
        /// <param name="options">The current OData query options.</param>
        /// <returns>The requested ChangeDocumentsSet entry.</returns>
        /// <response code="200">The ChangeDocumentsSet entry was successfully retrieved.</response>
        /// <response code="404">The ChangeDocumentsSet entry does not exist.</response>
        [HttpGet]
        [Produces("application/json")]
        [ODataRoute("(Changedocobjectclass='{changedocobjectclass}',Changedocobject='{changedocobject}',Changedocument='{changedocument}')")]
        [ProducesResponseType(typeof(ChangeDocumentsSet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableQuery]
        public IActionResult Get([FromODataUri] string changedocobjectclass,
            [FromODataUri] string changedocobject,
            [FromODataUri] string changedocument,
            ODataQueryOptions<ChangeDocumentsSet> options)
        {
            var entries = _db.ChangeDocumentsSet;
            var entry = options.ApplyTo(
                entries.Where(e =>
                    e.Changedocobjectclass == changedocobjectclass &&
                    e.Changedocobject == changedocobject &&
                    e.Changedocument == changedocument
                )
                .AsQueryable())
                .SingleOrDefault();

            if (entry == null)
            {
                return NotFound();
            }

            return Ok((ChangeDocumentsSet)entry);
        }
    }
}
