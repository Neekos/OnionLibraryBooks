using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.Domain.Enum
{
    public enum StatusCode
    {
        BookNotFound = 0,
        UserNotFound = 1,
        Ok = 200,
        NotFound = 404,
        Error = 500,

    }
}
