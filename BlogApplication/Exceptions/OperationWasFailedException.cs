using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Exceptions
{
    public class OperationWasFailedException:Exception
    {
        public string Message { get; set; }

        public OperationWasFailedException(string message)
            :base(message)
        {
            this.Message = message;
        }
    }
}