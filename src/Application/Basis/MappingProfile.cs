// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Application.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Basis
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DiaryEntry, DiaryEntryDto>();
        }
    }
}
