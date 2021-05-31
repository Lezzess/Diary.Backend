// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using AutoMapper;
using Core.Models;
using Persistence.Entities;

namespace Persistence.Basis
{
    internal class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<Diary, DiaryEntity>()
                .ReverseMap().ConstructUsing(
                    entity => new Diary(entity.Title, entity.Description));
        }
    }
}
