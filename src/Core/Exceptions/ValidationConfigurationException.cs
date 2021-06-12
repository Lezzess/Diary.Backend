using System;

namespace Core.Exceptions
{
    public class ValidationConfigurationException : Exception
    {
        public ValidationConfigurationException(string message)
            : base(message)
        {

        }
    }
}
