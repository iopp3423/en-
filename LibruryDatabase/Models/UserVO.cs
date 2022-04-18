using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    class UserVO
    {
        private static UserVO UserData = null;

        public static UserVO Get()
        {
            if (UserData == null)
                UserData = new UserVO();

            return UserData;
        }
    }
}
