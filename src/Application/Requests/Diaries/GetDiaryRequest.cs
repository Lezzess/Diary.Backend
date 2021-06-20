// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Core.Exceptions;
using Core.Exceptions.Validation;
using Core.Models;
using Core.Repositories;
using MediatR;

namespace Application.Requests.Diaries
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

    internal class GetDiaryRequestHandler : IRequestHandler<GetDiaryRequest, DiaryDto>
    {
        #region Dependencies

        private readonly IMapper _mapper;
        private readonly IDiaryRepository _diaryRepository;

        #endregion

        #region Constructors

        public GetDiaryRequestHandler(
            IMapper mapper,
            IDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
        }

        #endregion

        #region Public Methods

        public async Task<DiaryDto> Handle(GetDiaryRequest request, CancellationToken cancellationToken)
        {
            var diary = await _diaryRepository.GetAsync(request.Id);
            if (diary == null)
                throw new EntityNotFoundException(typeof(Diary));

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
