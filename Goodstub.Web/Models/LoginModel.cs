using Goodstub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goodstub.Web.Models
{
    public class LoginModel
    {
        public IUser User
        {
            get; set;
        }
    }
}