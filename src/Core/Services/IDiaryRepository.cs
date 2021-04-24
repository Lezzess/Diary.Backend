// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services
{
    public interface IDiaryRepository
    {
        Task<List<DiaryEntry>> GetAllAsync();
    }
}
