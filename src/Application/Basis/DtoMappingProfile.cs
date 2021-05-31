// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Application.Dtos;
using AutoMapper;
using Core.Models;

namespace Application.Basis
{
    internal class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Diary, DiaryDto>();
        }
    }
}
