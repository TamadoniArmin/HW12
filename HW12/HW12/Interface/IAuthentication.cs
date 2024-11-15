﻿using HW12.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface
{
    public interface IAuthentication
    {
        bool Login(string username, string password);
        void Register(string username, string password);
        User Get(string username);
        bool UserExist(string username);
    }
}
