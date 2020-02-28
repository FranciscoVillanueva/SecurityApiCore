using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class DomainSettings
    {
        public int DomainId { get; set; }
        public int SettingId { get; set; }
        public string Value { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public Domain Domain { get; set; }
        public CatDomainSettings Setting { get; set; }
    }
}
