using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class ApplicationAccessActions
    {
        public int ActionId { get; set; }
        public int AccessEntityId { get; set; }
        public int AccessId { get; set; }
        public string ActionTag { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }
        public int? ParentId { get; set; }

        public ApplicationAccess Access { get; set; }
        public AccessEntity AccessEntity { get; set; }
    }
}
