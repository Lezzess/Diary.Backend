// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    internal class DiaryRepository : IDiaryRepository
    {
        #region Dependencies

        private readonly ApplicationContext _applicationContext;

        #endregion

        #region Constructors

        public DiaryRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        #endregion

        #region Public Methods

        public async Task<List<Diary>> GetAllAsync()
        {
            return await _applicationContext.Diaries.AsNoTracking().ToListAsync();
        }

        public async Task<Diary> GetAsync(Guid id)
        {
            return await _applicationContext.Diaries.FindAsync(id);
        }

        public async Task AddAsync(Diary diary)
        {
            await _applicationContext.Diaries.AddAsync(diary);
        }

        public void Remove(Diary diary)
        {
            _applicationContext.Diaries.Remove(diary);
        }

        #endregion
    }
}
