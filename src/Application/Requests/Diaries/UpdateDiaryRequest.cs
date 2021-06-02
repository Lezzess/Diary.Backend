// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Requests.Diaries
{
    public record UpdateDiaryRequest(Guid? Id, string Title, string Description) : IRequest<DiaryDto>;

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
            _validator = validator;
            _diaryRepository = diaryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        public async Task<DiaryDto> Handle(UpdateDiaryRequest request, CancellationToken cancellationToken)
        {
            var (id, title, description) = request;

            _validator.Validate(id, d => d.Id);
            _validator.Validate(title, d => d.Title);
            _validator.Validate(description, d => d.Description);

            var diary = await _diaryRepository.GetAsync(id!.Value);
            diary.Title = title;
            diary.Description = description;

            await _diaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
