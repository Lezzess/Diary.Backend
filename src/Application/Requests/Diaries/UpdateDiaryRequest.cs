// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Common.Services.Validation;
using Core.Exceptions;
using Core.Exceptions.Validation;
using Core.Models;
using Core.Repositories;
using MediatR;

namespace Application.Requests.Diaries
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

        #region Deconstructor

        public void Deconstruct(out Guid id, out string title, out string description)
        {
            id = Id;
            title = Title;
            description = Description;
        }

        #endregion
    }

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
            var (id, title, description) = request;

            _validator.Validate(title, d => d.Title);
            _validator.Validate(description, d => d.Description);

            var diary = await _diaryRepository.GetAsync(id);
            if (diary == null)
                throw new EntityNotFoundException(typeof(Diary));

            diary.ChangeTitle(title);
            diary.ChangeDescription(description);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
