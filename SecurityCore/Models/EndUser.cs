using System;
using System.Collections.Generic;

namespace SecurityCore.Models
{
    public partial class EndUser
    {
        public EndUser()
        {
            AccessEntityUsersSettings = new HashSet<AccessEntityUsersSettings>();
            ActiveToken = new HashSet<ActiveToken>();
            Ipaddress = new HashSet<Ipaddress>();
            UserProfiles = new HashSet<UserProfiles>();
            UserPwdHistoryLog = new HashSet<UserPwdHistoryLog>();
            UserSettings = new HashSet<UserSettings>();
        }

        public int UserId { get; set; }
        public int DomainId { get; set; }
        public int UserEntityId { get; set; }
        public string CompanyCd { get; set; }
        public string ChannelId { get; set; }
        public string UserTypeCd { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherMname { get; set; }
        public string LockedCd { get; set; }
        public DateTime? LockedDt { get; set; }
        public int? Badpwdcount { get; set; }
        public DateTime? LastLogOnDt { get; set; }
        public DateTime? CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }
        public DateTime ExpirateDate { get; set; }

        public Domain Domain { get; set; }
        public UserEntity UserEntity { get; set; }
        public ICollection<AccessEntityUsersSettings> AccessEntityUsersSettings { get; set; }
        public ICollection<ActiveToken> ActiveToken { get; set; }
        public ICollection<Ipaddress> Ipaddress { get; set; }
        public ICollection<UserProfiles> UserProfiles { get; set; }
        public ICollection<UserPwdHistoryLog> UserPwdHistoryLog { get; set; }
        public ICollection<UserSettings> UserSettings { get; set; }
    }
}
