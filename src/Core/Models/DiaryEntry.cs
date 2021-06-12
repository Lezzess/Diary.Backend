// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Basis;

namespace Core.Models
{
    public class Diary : AggregateRoot
    {
        #region Properties

        public string Title { get; private set; }
        public string Description { get; private set; }

        #endregion

        #region Constructors

        public Diary(string title, string description)
        {
            ChangeTitle(title);
            ChangeDescription(description);
        }

        #endregion

        #region Public Methods

        public void ChangeTitle(string title)
        {
            Title = title.Trim();
        }

        public void ChangeDescription(string description)
        {
            Description = description.Trim();
        }

        #endregion
    }
}
