using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class Authority
    {
        private static User user;

        public static void Init(User u){
            user = u;
        }

        public static User CurrentUser
        {
            get
            {
                return user;
            }
        }

        public static bool AllowDelete { get { return user.RoleType == 1; } }
    }
}
