// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Core.Exceptions;
using Core.Models;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Requests.Diaries
{
    public record GetDiaryRequest(Guid? Id) : IRequest<DiaryDto>;

    internal class GetDiaryRequestHandler : IRequestHandler<GetDiaryRequest, DiaryDto>
    {
        #region Dependencies

        private readonly IMapper _mapper;
        private readonly IValidator<Diary> _validator;
        private readonly IDiaryRepository _diaryRepository;

        #endregion

        #region Constructors

        public GetDiaryRequestHandler(
            IMapper mapper,
            IValidator<Diary> validator,
            IDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _diaryRepository = diaryRepository;
        }

        #endregion

        #region Public Methods

        public async Task<DiaryDto> Handle(GetDiaryRequest request, CancellationToken cancellationToken)
        {
            _validator.Validate(request.Id, d => d.Id);

            var diary = await _diaryRepository.GetAsync(request.Id!.Value);
            if (diary == null)
                throw new ModelNotFoundException<Diary>();

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
