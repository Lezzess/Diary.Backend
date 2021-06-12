// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Models;
using Core.Repositories;
using MediatR;

namespace Application.Requests.Diaries.Remove
{
    internal class RemoveDiaryRequestHandler : IRequestHandler<RemoveDiaryRequest>
    {
        #region Dependencies

        private readonly IDiaryRepository _diaryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public RemoveDiaryRequestHandler(
            IDiaryRepository diaryRepository, 
            IUnitOfWork unitOfWork)
        {
            _diaryRepository = diaryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        public async Task<Unit> Handle(RemoveDiaryRequest request, CancellationToken cancellationToken)
        {
            var diary = await _diaryRepository.GetAsync(request.Id);
            if (diary == null)
                throw new EntityNotFoundException(typeof(Diary));

            await _diaryRepository.RemoveAsync(diary);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }

        #endregion
    }
}
