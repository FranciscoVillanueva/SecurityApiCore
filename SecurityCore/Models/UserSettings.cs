using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class UserSettings
    {
        public int UserId { get; set; }
        public int SettingId { get; set; }
        public string Value { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public CatUserSettings Setting { get; set; }
        public EndUser User { get; set; }
    }
}
