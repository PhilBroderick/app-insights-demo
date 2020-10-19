using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basket.Entities;
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
        private static List<BasketItem> _basket;

        [HttpGet]
        public IActionResult GetBasket() => Ok(_basket);

        [HttpPost]
        public IActionResult AddItemToBasket(AddItemRequest model)
        {
            if (_basket is null)
                _basket = new List<BasketItem>();
            if (_basket.Any(b => b.Id == model.Id))
            {
                _basket.Single(b => b.Id == model.Id).Quantity += model.Quantity;
            }
            else
            {
                _basket.Add(new BasketItem { Id = model.Id, Price = model.Price, Quantity = model.Quantity });
            }

            return Ok(_basket);
        }
    }
}
