using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mestwiz.config.api.entities
{
    public class Enumerators
    {
    }

    public enum ResponseStatus
    {
        Success = HttpStatusCode.OK,
        ValidationError = HttpStatusCode.Conflict,
        InternalError = HttpStatusCode.InternalServerError
    }

    public enum TypeMessageError
    {
        Exception = 1,
        Warning = 2,
        Other = 3
    }
}
