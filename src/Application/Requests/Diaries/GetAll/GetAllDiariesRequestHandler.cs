// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Core.Services;
using MediatR;

namespace Application.Requests.Diaries.GetAll
{
    internal class GetAllDiariesRequestHandler : IRequestHandler<GetAllDiariesRequest, List<DiaryEntryDto>>
    {
        #region Dependencies

        private readonly IMapper _mapper;
        private readonly IDiaryRepository _diaryRepository;

        #endregion

        #region Constructors

        public GetAllDiariesRequestHandler(
            IMapper mapper,
            IDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
        }

        #endregion

        #region Public Methods

        public async Task<List<DiaryEntryDto>> Handle(
            GetAllDiariesRequest request, CancellationToken cancellationToken)
        {
            var diaries = await _diaryRepository.GetAllAsync();
            return _mapper.Map<List<DiaryEntryDto>>(diaries);
        }

        #endregion
    }
}
