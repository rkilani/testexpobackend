using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestExpoWebAPI.Model
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException()
        {
        }
        public AlreadyExistsException(string message)
        : base(message)
    {
        }

        public AlreadyExistsException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
