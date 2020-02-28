using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class AccessEntity
    {
        public AccessEntity()
        {
            AccessEntityAuthorizations = new HashSet<AccessEntityAuthorizations>();
            AccessEntityUsersSettings = new HashSet<AccessEntityUsersSettings>();
            Application = new HashSet<Application>();
            ApplicationAccess = new HashSet<ApplicationAccess>();
            ApplicationAccessActions = new HashSet<ApplicationAccessActions>();
            UserEntityPermissionsAccess = new HashSet<UserEntityPermissionsAccess>();
        }

        public int AccessEntityId { get; set; }
        public string AccessEntityTypeCd { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public ICollection<AccessEntityAuthorizations> AccessEntityAuthorizations { get; set; }
        public ICollection<AccessEntityUsersSettings> AccessEntityUsersSettings { get; set; }
        public ICollection<Application> Application { get; set; }
        public ICollection<ApplicationAccess> ApplicationAccess { get; set; }
        public ICollection<ApplicationAccessActions> ApplicationAccessActions { get; set; }
        public ICollection<UserEntityPermissionsAccess> UserEntityPermissionsAccess { get; set; }
    }
}
