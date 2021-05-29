using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
