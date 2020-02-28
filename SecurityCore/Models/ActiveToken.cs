using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class ActiveToken
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string CompanyCd { get; set; }
        public string ChannelId { get; set; }
        public string Ipaddress { get; set; }
        public Guid TokenValue { get; set; }
        public int? TokenTimeOut { get; set; }
        public DateTime CreationDt { get; set; }
        public DateTime LastConnAttempt { get; set; }

        public EndUser User { get; set; }
    }
}
