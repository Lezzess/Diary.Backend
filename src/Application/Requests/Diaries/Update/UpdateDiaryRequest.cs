// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Application.Dtos;
using Core.Exceptions.Validation;
using MediatR;

namespace Application.Requests.Diaries.Update
{
    public record UpdateDiaryRequest : IRequest<DiaryDto>
    {
        #region Properties

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }

        #endregion

        #region Constructors

        public UpdateDiaryRequest(Guid? id, string title, string description)
        {
            Id = id ?? throw new ValueIsRequiredException(nameof(Id));
            Title = title ?? throw new ValueIsRequiredException(nameof(Title));
            Description = description ?? throw new ValueIsRequiredException(nameof(Description));
        }

        #endregion
    }
}
