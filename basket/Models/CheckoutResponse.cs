using System.Collections.Generic;
using basket.Entities;

namespace basket.Models
{
    public class CheckoutResponse
    {
        public List<BasketItem> CheckedOutBasket { get; set; }
        public decimal Total { get; set; }
    }
}