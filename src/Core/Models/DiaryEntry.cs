// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Basis;

namespace Core.Models
{
    public class Diary : AggregateRoot
    {
        #region Properties

        public string Title { get; set; }
        public string Description { get; set; }

        #endregion

        #region Constructors

        public Diary(string title, string description)
        {
            Title = title;
            Description = description;
        }

        #endregion
    }
}
