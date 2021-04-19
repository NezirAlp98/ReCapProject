using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Logging
{
    public class LogDetailWithException:LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
