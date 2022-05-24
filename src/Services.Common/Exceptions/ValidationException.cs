using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {

    }
}
