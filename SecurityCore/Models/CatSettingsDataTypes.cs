using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class CatSettingsDataTypes
    {
        public CatSettingsDataTypes()
        {
            CatDomainSettings = new HashSet<CatDomainSettings>();
            CatUserSettings = new HashSet<CatUserSettings>();
        }

        public int SettingTypeId { get; set; }
        public string SettingTypeCd { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public ICollection<CatDomainSettings> CatDomainSettings { get; set; }
        public ICollection<CatUserSettings> CatUserSettings { get; set; }
    }
}
