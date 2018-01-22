using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Unit { get; set; }
        public int RoleType { get; set; }
    }

    enum RoleType
    {
        NormalUser,
        Admin
    }
}
