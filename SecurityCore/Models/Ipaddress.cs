using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class Ipaddress
    {
        public int UserId { get; set; }
        public string FromIpaddress { get; set; }
        public string ToIpaddress { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }

        public EndUser User { get; set; }
    }
}
