using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            AccessEntityAuthorizations = new HashSet<AccessEntityAuthorizations>();
            EndUser = new HashSet<EndUser>();
            Profile = new HashSet<Profile>();
            UserEntityPermissionsAccess = new HashSet<UserEntityPermissionsAccess>();
        }

        public int UserEntityId { get; set; }
        public string UserEntityTypeCd { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public ICollection<AccessEntityAuthorizations> AccessEntityAuthorizations { get; set; }
        public ICollection<EndUser> EndUser { get; set; }
        public ICollection<Profile> Profile { get; set; }
        public ICollection<UserEntityPermissionsAccess> UserEntityPermissionsAccess { get; set; }
    }
}
