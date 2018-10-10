using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HellowWorldAPI.Enumerations
{
    [Flags]
    internal enum LogLevel
    {
        TRACE,
        INFO,
        DEBUG,
        WARNING,
        ERROR,
        FATAL
    }
}