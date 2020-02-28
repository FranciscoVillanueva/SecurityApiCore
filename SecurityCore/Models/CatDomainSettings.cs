using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class CatDomainSettings
    {
        public CatDomainSettings()
        {
            DomainSettings = new HashSet<DomainSettings>();
        }

        public int SettingId { get; set; }
        public int SettingTypeId { get; set; }
        public string SettingCd { get; set; }
        public string Name { get; set; }
        public string ValueDefault { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public CatSettingsDataTypes SettingType { get; set; }
        public ICollection<DomainSettings> DomainSettings { get; set; }
    }
}
