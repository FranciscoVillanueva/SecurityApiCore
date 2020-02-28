using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class UserProfiles
    {
        public int UserId { get; set; }
        public int ProfileId { get; set; }
        public DateTime? ExpirationDt { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public Profile Profile { get; set; }
        public EndUser User { get; set; }
    }
}
