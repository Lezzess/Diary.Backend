// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using Core.Entities;

namespace Persistence.ApplicationContext
{
    internal static class ApplicationContextMock
    {
        #region Properties

        public static List<DiaryEntry> Diaries { get; set; }

        #endregion

        #region Constructors

        static ApplicationContextMock()
        {
            Diaries = new List<DiaryEntry>();
            FillDiaries();
        }

        #endregion

        #region Private Methods

        private static void FillDiaries()
        {
            Diaries.Add(new DiaryEntry("First title", "First description"));
            Diaries.Add(new DiaryEntry("Second title", "Second description"));
            Diaries.Add(new DiaryEntry("Third title", "Third description"));

            foreach (var diary in Diaries)
                diary.Id = Guid.NewGuid();
        }

        #endregion
    }
}
