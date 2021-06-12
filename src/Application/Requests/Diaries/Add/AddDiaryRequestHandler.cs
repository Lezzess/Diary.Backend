// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Extensions;
using AutoMapper;
using Core.Models;
using Core.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Requests.Diaries.Add
{
    internal class AddDiaryRequestHandler : IRequestHandler<AddDiaryRequest, DiaryDto>
    {
        #region Dependencies

        private readonly IValidator<Diary> _validator;
        private readonly IMapper _mapper;
        private readonly IDiaryRepository _diaryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public AddDiaryRequestHandler(
            IValidator<Diary> validator,
            IMapper mapper,
            IDiaryRepository diaryRepository,
            IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _mapper = mapper;
            _diaryRepository = diaryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        public async Task<DiaryDto> Handle(AddDiaryRequest request, CancellationToken cancellationToken)
        {
            var diary = new Diary(request.Title, request.Description);
            await _validator.ValidateStrictAsync(
                diary, 
                options => options.IncludeProperties(
                    d => d.Title, d => d.Description), 
                cancellationToken);

            await _diaryRepository.AddAsync(diary);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
