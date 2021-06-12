// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Application.Dtos;
using Core.Exceptions.Validation;
using MediatR;

namespace Application.Requests.Diaries.Get
{
    public record GetDiaryRequest : IRequest<DiaryDto>
    {
        #region Properties

        public Guid Id { get; }

        #endregion

        #region Constructors

        public GetDiaryRequest(Guid? id)
        {
            Id = id ?? throw new ValueIsRequiredException(nameof(Id));
        }

        #endregion
    }
}
