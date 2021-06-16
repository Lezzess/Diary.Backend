// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

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
