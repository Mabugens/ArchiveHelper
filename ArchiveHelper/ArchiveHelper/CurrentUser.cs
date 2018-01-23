using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class CurrentUser
    {
        private static User currentUser;
        public static User Instance
        {
            get
            {
                return currentUser;
            }
        }
    }
}
