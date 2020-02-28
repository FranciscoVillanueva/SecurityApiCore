using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class UserEntityPermissionsAccess
    {
        public int UserEntityId { get; set; }
        public int AccessEntityId { get; set; }
        public DateTime? ExpirationDt { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public AccessEntity AccessEntity { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
