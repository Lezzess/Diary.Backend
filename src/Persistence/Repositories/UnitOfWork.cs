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

        public Task SaveChangesAsync()
        {
            return _applicationContext.SaveChangesAsync();
        }

        #endregion
    }
}
