using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Entities;
using catalog.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger _log;

        public CatalogController(ICatalogService catalogService, ILogger<CatalogController> logger)
        {
            _catalogService = catalogService;
            _log = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCatalogItemsInStock()
        {
            _log.LogInformation("Retrieving catalog items.");
            return Ok(_catalogService.GetItemsInStock());
        }
    }
}
