using catalog.Entities;
using catalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.Services
{
    public class CatalogService : ICatalogService
    {
        private static readonly string _imageUrlPrefix = "https://pbtestingaccount.blob.core.windows.net/images/";
        private readonly IEnumerable<CatalogItem> _catalogItems = new List<CatalogItem>
        {
            new CatalogItem { Id = 1, Name = "Mechanical Keyboard", Description = "RGB Mechanical Keyboard with Cherry MX Blue switches", Price = 99.99m, QuantityInStock = 5, ImageName = $"{_imageUrlPrefix}MechanicalKeyboard.jpg"},
            new CatalogItem { Id = 2, Name = "Mouse", Description = "RGB Gaming mouse with 11 programmable buttons", Price = 59.99m, QuantityInStock = 9, ImageName = $"{_imageUrlPrefix}GamingMouse.jpg"}
        };

        public IEnumerable<CatalogItem> GetItemsInStock() => _catalogItems.Where(c => c.QuantityInStock > 0);
    }
}
