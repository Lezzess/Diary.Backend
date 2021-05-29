﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    internal class DiaryRepository : IDiaryRepository
    {
        #region Public Methods

        public Task<List<DiaryEntry>> GetAllAsync()
        {
            var diaries = ApplicationContextMock.Diaries;
            return Task.FromResult(diaries);
        }

        #endregion
    }
}
