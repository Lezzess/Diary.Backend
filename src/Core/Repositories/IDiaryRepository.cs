// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repositories
{
    public interface IDiaryRepository
    {
        Task<List<Diary>> GetAllAsync();
        Task<Diary> GetAsync(Guid id);
        Task AddAsync(Diary diary);
        Task UpdateAsync(Diary diary);
        Task RemoveAsync(Diary diary);
    }
}
