// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace Core.Exceptions.Validation
{
    public class ValueIsRequiredException : ValidationException
    {
        public ValueIsRequiredException(string valueName)
            : base($"Value {valueName} is required")
        {

        }
    }
}
