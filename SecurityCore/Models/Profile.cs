using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class Profile
    {
        public Profile()
        {
            UserProfiles = new HashSet<UserProfiles>();
        }

        public int ProfileId { get; set; }
        public int DomainId { get; set; }
        public int UserEntityId { get; set; }
        public string ProfileCd { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public Domain Domain { get; set; }
        public UserEntity UserEntity { get; set; }
        public ICollection<UserProfiles> UserProfiles { get; set; }
    }
}
