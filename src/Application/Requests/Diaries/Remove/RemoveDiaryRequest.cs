// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Core.Exceptions.Validation;
using MediatR;

namespace Application.Requests.Diaries.Remove
{
    public record RemoveDiaryRequest : IRequest
    {
        #region Properties

        public Guid Id { get; }

        #endregion

        #region Constructors

        public RemoveDiaryRequest(Guid? id)
        {
            Id = id ?? throw new ValueIsRequiredException(nameof(Id));
        }

        #endregion
    }
}
