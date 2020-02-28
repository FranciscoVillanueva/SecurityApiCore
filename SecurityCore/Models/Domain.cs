using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class Domain
    {
        public Domain()
        {
            DomainSettings = new HashSet<DomainSettings>();
            EndUser = new HashSet<EndUser>();
            Profile = new HashSet<Profile>();
        }

        public int DomainId { get; set; }
        public string DomainTypeCd { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public ICollection<DomainSettings> DomainSettings { get; set; }
        public ICollection<EndUser> EndUser { get; set; }
        public ICollection<Profile> Profile { get; set; }
    }
}
