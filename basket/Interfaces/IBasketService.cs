using basket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Interfaces
{
    public interface IBasketService
    {
        IEnumerable<BasketItem> GetBasket();
        IEnumerable<BasketItem> AddItemToBasket(BasketItem basketItem);
        void ClearBasket();
    }
}
