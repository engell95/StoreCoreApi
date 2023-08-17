using System;
using System.Collections.Generic;

namespace StoreCoreApi.Db.Models.Store.Models
{
    public partial class Product
    {
        public Product()
        {
            StoreProductMappings = new HashSet<StoreProductMapping>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        public virtual ICollection<StoreProductMapping> StoreProductMappings { get; set; }
    }
}
