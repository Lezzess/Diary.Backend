// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace Core.Exceptions.Validation
{
    public class ValueIsRequiredException : ValidationException
    {
        #region Properties

        public string PropertyName { get; set; }

        #endregion

        #region Constructors

        public ValueIsRequiredException(string propertyName)
        {
            PropertyName = propertyName;
        }

        #endregion
    }
}
