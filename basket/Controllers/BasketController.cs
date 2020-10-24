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

namespace basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetBasket() => Ok(_basketService.GetBasket());

        [HttpPost]
        [Authorize]
        public IActionResult AddItemToBasket(AddItemRequest model)
        {
            return Ok(_basketService.AddItemToBasket(new BasketItem { Id = model.Id, Price = model.Price, Quantity = model.Quantity }));
        }

        [HttpDelete]
        [Authorize]
        public IActionResult ClearBasket()
        {
            _basketService.ClearBasket();
            return Ok();
        }

    }
}
