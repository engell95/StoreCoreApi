using System;
using System.Collections.Generic;

namespace StoreCoreApi.Db.Models.Store.Models
{
    public partial class StoreProductMapping
    {
        public int MappingId { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int? Stock { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
    }
}
