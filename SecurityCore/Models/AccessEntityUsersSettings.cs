using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class AccessEntityUsersSettings
    {
        public int AccessEntityId { get; set; }
        public int UserId { get; set; }
        public string ScreenItemTag { get; set; }
        public string SettingXml { get; set; }

        public AccessEntity AccessEntity { get; set; }
        public EndUser User { get; set; }
    }
}
