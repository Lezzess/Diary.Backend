// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Extensions;
using AutoMapper;
using Core.Exceptions;
using Core.Models;
using Core.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Requests.Diaries.Update
{
    internal class UpdateDiaryRequestHandler : IRequestHandler<UpdateDiaryRequest, DiaryDto>
    {
        #region Dependencies

        private readonly IMapper _mapper;
        private readonly IValidator<Diary> _validator;
        private readonly IDiaryRepository _diaryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public UpdateDiaryRequestHandler(
            IMapper mapper,
            IValidator<Diary> validator,
            IDiaryRepository diaryRepository, 
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _diaryRepository = diaryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        public async Task<DiaryDto> Handle(UpdateDiaryRequest request, CancellationToken cancellationToken)
        {
            var diary = await _diaryRepository.GetAsync(request.Id);
            if (diary == null)
                throw new EntityNotFoundException(typeof(Diary));

            diary.ChangeTitle(request.Title);
            diary.ChangeDescription(request.Description);

            await _validator.ValidateStrictAsync(
                diary,
                options => options.IncludeProperties(
                    d => d.Title, d => d.Description),
                cancellationToken);

            await _diaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
