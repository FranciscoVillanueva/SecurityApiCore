using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class CatSystemCatalog
    {
        public CatSystemCatalog()
        {
            CatSystemCatalogDetail = new HashSet<CatSystemCatalogDetail>();
        }

        public int CatalogId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<CatSystemCatalogDetail> CatSystemCatalogDetail { get; set; }
    }
}
