using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class Application
    {
        public Application()
        {
            ApplicationAccess = new HashSet<ApplicationAccess>();
        }

        public int ApplicationId { get; set; }
        public int AccessEntityId { get; set; }
        public string ApplicationTag { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }
        public int? ParentId { get; set; }

        public AccessEntity AccessEntity { get; set; }
        public ICollection<ApplicationAccess> ApplicationAccess { get; set; }
    }
}
