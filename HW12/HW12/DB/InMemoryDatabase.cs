using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.DB
{
    public static class InMemoryDatabase
    {
        public static User OnlineUser { get; set; }
        static InMemoryDatabase()
        {
            OnlineUser = new User();
        }
        public static void CheckUserLogin()
        {
            if (OnlineUser is null)
            {
                throw new Exception("You don't have access for this task");
            }
        }
    }
}
