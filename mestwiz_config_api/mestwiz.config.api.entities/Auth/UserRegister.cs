using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.api.entities.Auth
{
    public class UserRegister : UserLogin
    {
        public string fullname { get; set; }
    }
}
