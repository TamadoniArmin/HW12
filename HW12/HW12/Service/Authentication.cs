using HW12.DB;
using HW12.Interface;
using HW12.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public class Authentication : IAuthentication
    {
        private readonly AppDbContext _context;
        public Authentication()
        {
            _context = new AppDbContext();
        }
        public bool Login(string username, string password)
        {
            return _context.Users.Any(N => N.Username == username && N.Password == password);
        }
        public void Register(string username, string password)
        {
            var user = new User()
            {
                Username = username,
                Password = password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User Get(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            if (user is not null)
            {
                return user;
            }
            else
            {
                throw new Exception($"Cannot find user with username {username}");
            }
        }
        public bool UserExist(string username)
        {
            return _context.Users.All(x => x.Username == username);
        }

    }
}
