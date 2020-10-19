using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Entities;
using catalog.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCatalogItemsInStock()
        {
            return Ok(_catalogService.GetItemsInStock());
        }
    }
}
