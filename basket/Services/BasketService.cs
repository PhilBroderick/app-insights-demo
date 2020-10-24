using basket.Entities;
using basket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Services
{
    public class BasketService : IBasketService
    {
        private static List<BasketItem> _basket;

        public BasketService()
        {
            _basket ??= new List<BasketItem>();
        }

        public IEnumerable<BasketItem> GetBasket() => _basket;

        public IEnumerable<BasketItem> AddItemToBasket(BasketItem basketItem)
        {
            if (_basket.Any(b => b.Id == basketItem.Id))
            {
                _basket.Single(b => b.Id == basketItem.Id).Quantity += basketItem.Quantity;
            }
            else
            {
                _basket.Add(basketItem);
            }
            return _basket;
        }

        public void ClearBasket() => _basket.Clear();
    }
}
