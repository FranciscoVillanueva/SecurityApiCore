using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityCore
{
    public class UserLogged
    {
        public bool IsLogged { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj is UserLogged)
            {
                var that = obj as UserLogged;
                return IsLogged == that.IsLogged && UserName == that.UserName && Role == that.Role;
            }
            return false;
        }
    }
}
