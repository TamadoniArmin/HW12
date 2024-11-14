using HW12.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.DB
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }
        public List<Duty>? UserDuties { get; set; }
    }
}
