using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class CatSystemCatalogDetail
    {
        public int CatalogId { get; set; }
        public string CatalogKey { get; set; }
        public string Description { get; set; }
        public int? OrderBy { get; set; }

        public CatSystemCatalog Catalog { get; set; }
    }
}
