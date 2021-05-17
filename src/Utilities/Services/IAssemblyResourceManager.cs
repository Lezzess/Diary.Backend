// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Reflection;
using System.Threading.Tasks;

namespace Utilities.Services
{
    public interface IAssemblyResourceManager
    {
        Task<string> GetFileContentAsync(Assembly assembly, string filePath);
    }
}
