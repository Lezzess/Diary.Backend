// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Dependencies

        private readonly ApplicationContext _applicationContext;

        #endregion

        #region Constructors

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }        

        #endregion

        #region Public Methods

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _applicationContext.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
