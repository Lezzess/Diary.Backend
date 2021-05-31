// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Exceptions;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories
{
    internal class DiaryRepository : IDiaryRepository
    {
        #region Dependencies

        private readonly ApplicationContext _applicationContext;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public DiaryRepository(
            ApplicationContext applicationContext,
            IMapper mapper)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<List<Diary>> GetAllAsync()
        {
            var diaryEntities = await _applicationContext.Diaries.AsNoTracking().ToListAsync();
            return _mapper.Map<List<Diary>>(diaryEntities);
        }

        public async Task<Diary> GetAsync(Guid id)
        {
            var diaryEntity = await _applicationContext.Diaries.FindAsync(id);
            if (diaryEntity == null)
                throw new ModelNotFoundException<Diary>();

            return _mapper.Map<Diary>(diaryEntity);
        }

        public async Task AddAsync(Diary diary)
        {
            var diaryEntity = _mapper.Map<DiaryEntity>(diary);
            await _applicationContext.Diaries.AddAsync(diaryEntity);
            diary.Id = diaryEntity.Id;
        }

        public async Task UpdateAsync(Diary diary)
        {
            var diaryEntity = await _applicationContext.Diaries.FindAsync(diary.Id);
            if (diaryEntity == null)
                throw new ModelNotFoundException<Diary>();

            diaryEntity.Title = diary.Title;
            diaryEntity.Description = diary.Description;
        }
        
        public async Task RemoveAsync(Diary diary)
        {
            var diaryEntity = await _applicationContext.Diaries.FindAsync(diary.Id);
            if (diaryEntity == null)
                throw new ModelNotFoundException<Diary>();

            _applicationContext.Diaries.Remove(diaryEntity);
        }

        #endregion
    }
}
