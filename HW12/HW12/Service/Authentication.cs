using HW12.DB;
using HW12.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public class Authentication
    {
        private readonly AppDbContext _context;
        public Authentication()
        {
            _context = new AppDbContext();
        }
        public bool Login(string username,string password)
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

    }
}
