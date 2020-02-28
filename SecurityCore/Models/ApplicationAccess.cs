using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class ApplicationAccess
    {
        public ApplicationAccess()
        {
            ApplicationAccessActions = new HashSet<ApplicationAccessActions>();
        }

        public int AccessId { get; set; }
        public int AccessEntityId { get; set; }
        public int ApplicationId { get; set; }
        public string AccessTag { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }
        public int? ParentId { get; set; }

        public AccessEntity AccessEntity { get; set; }
        public Application Application { get; set; }
        public ICollection<ApplicationAccessActions> ApplicationAccessActions { get; set; }
    }
}
