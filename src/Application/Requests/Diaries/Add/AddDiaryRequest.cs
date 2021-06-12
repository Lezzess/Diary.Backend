// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Application.Dtos;
using Core.Exceptions.Validation;
using MediatR;

namespace Application.Requests.Diaries.Add
{
    public record AddDiaryRequest : IRequest<DiaryDto>
    {
        #region Properties

        public string Title { get; }
        public string Description { get; }

        #endregion

        #region Constructors

        public AddDiaryRequest(string title, string description)
        {
            Title = title ?? throw new ValueIsRequiredException(nameof(Title));
            Description = description ?? throw new ValueIsRequiredException(nameof(Description));
        }

        #endregion
    }
}
