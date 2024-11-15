using HW12.DB;
using HW12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public class Userservice : IUserService
    {
        Authentication Authentication = new Authentication();
        public void Login(string username, string password)
        {
            var res= Authentication.Login(username, password);
            if (res)
            {
                InMemoryDatabase.OnlineUser = Authentication.Get(username);
            }
            else
            {
                throw new Exception($"Cannot find user with username {username}");
            }
        }
        public void Register(string username, string password)
        {
            if (Authentication.UserExist(username))
            {
                throw new Exception($"This {username} is already taken");
            }
            else
            {
                Authentication.Register(username, password);
            }
            
        }
    }
}
