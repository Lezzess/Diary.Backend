// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Basis;

namespace Core.Entities
{
    public class DiaryEntry : AggregateRoot
    {
        #region Properties

        public string Title { get; }
        public string Description { get; }

        #endregion

        #region Constructors

        public DiaryEntry(string title, string description)
        {
            Title = title;
            Description = description;
        }

        #endregion
    }
}
