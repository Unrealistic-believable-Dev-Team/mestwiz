using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mestwiz.config.api.entities.Auth
{
    public class UserLogin
    {

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
