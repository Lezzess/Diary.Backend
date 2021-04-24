// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace Application.Dtos
{
    public record DiaryEntryDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
