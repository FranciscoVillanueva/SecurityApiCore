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
    }
}
