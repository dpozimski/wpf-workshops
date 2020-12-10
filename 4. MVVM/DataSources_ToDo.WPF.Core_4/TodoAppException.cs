using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.WPF.Core
{
    public class TodoAppException : Exception
    {
        public TodoAppException(string message) : base(message)
        {
        }

        public TodoAppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
