using System;

namespace Core.Exceptions
{
    public class ApplicationInitializationException : Exception
    {
        public ApplicationInitializationException(string message)
            : base(message)
        {
            
        }
    }
}
