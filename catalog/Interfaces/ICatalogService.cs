using catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<CatalogItem> GetItemsInStock();
    }
}
