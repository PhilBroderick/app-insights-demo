using System.Collections.Generic;
using basket.Models;

namespace basket.Models
{
    public class CheckoutRequest
    {
        public List<AddItemRequest> Basket { get; set; }
    }
}
