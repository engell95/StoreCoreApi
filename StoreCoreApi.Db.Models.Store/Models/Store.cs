using System;
using System.Collections.Generic;

namespace StoreCoreApi.Db.Models.Store.Models
{
    public partial class Store
    {
        public Store()
        {
            StoreProductMappings = new HashSet<StoreProductMapping>();
        }

        public int StoreId { get; set; }
        public string? StoreName { get; set; }

        public virtual ICollection<StoreProductMapping> StoreProductMappings { get; set; }
    }
}
