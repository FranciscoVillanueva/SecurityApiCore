using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class UserPwdHistoryLog
    {
        public int UserId { get; set; }
        public DateTime RegistrationDt { get; set; }
        public byte[] UserPass { get; set; }

        public EndUser User { get; set; }
    }
}
