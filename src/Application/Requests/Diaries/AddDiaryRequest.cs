// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Common.Services.Validation;
using Core.Exceptions.Validation;
using Core.Models;
using Core.Repositories;
using MediatR;

namespace Application.Requests.Diaries
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

        #region Deconstructor

        public void Deconstruct(out string title, out string description)
        {
            title = Title;
            description = Description;
        }

        #endregion
    }

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
            var (title, description) = request;

            _validator.Validate(title, d => d.Title);
            _validator.Validate(description, d => d.Description);

            var diary = new Diary(title, description);
            await _diaryRepository.AddAsync(diary);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DiaryDto>(diary);
        }

        #endregion
    }
}
