// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Exceptions.Validation;
using Core.Models;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Requests.Diaries
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

    internal class RemoveDiaryRequestHandler : IRequestHandler<RemoveDiaryRequest>
    {
        #region Dependencies

        private readonly IValidator<Diary> _validator;
        private readonly IDiaryRepository _diaryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public RemoveDiaryRequestHandler(
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

        public async Task<Unit> Handle(RemoveDiaryRequest request, CancellationToken cancellationToken)
        {
            _validator.Validate(request.Id, d => d.Id);

            var diary = await _diaryRepository.GetAsync(request.Id);
            if (diary == null)
                throw new ModelNotFoundException<Diary>();

            await _diaryRepository.RemoveAsync(diary);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }

        #endregion
    }
}
