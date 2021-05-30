using AutoMapper;
using Core.Models;
using Persistence.Entities;

namespace Persistence.Basis
{
    internal class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<DiaryEntry, DiaryEntryEntity>()
                .ReverseMap().ConstructUsing(
                    entity => new DiaryEntry(entity.Title, entity.Description));
        }
    }
}
