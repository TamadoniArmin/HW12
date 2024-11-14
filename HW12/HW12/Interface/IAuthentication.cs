using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface
{
    public interface IAuthentication
    {
        public bool Login(string username, string password);
        public void Register(string username, string password);
    }
}
