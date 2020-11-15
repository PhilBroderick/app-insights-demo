using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basket.Entities;
using basket.Interfaces;
using basket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILogger _log;

        public BasketController(IBasketService basketService, ILogger<BasketController> logger)
        {
            _basketService = basketService;
            _log = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetBasket() => Ok(_basketService.GetBasket());

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddItemToBasket(AddItemRequest model)
        {
            _log.LogInformation($"Adding: {model.Name} to basket, quantity: {model.Quantity}.");
            return Ok(_basketService.AddItemToBasket(new BasketItem { Id = model.Id, Name = model.Name, Price = model.Price, Quantity = model.Quantity }));
        }

        [HttpDelete]
        [Authorize]
        public IActionResult ClearBasket()
        {
            _log.LogInformation("Clearing basket.");
            _basketService.ClearBasket();
            return Ok();
        }

        [HttpPost("checkout")]
        [Authorize]
        public IActionResult Checkout(CheckoutRequest model)
        {
            if (model.Basket.Count > 1)
            {
                _log.LogError("Unexpected error - too many items in basket.");
                return BadRequest("Unexpected error occured.");
            }
            _log.LogInformation("Checking out basket.");
            return Ok(_basketService.Checkout());
        }

    }
}
