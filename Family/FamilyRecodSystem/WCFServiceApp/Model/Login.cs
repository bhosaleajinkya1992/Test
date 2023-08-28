using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceApp.Model
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }
    }
}