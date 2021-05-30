// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Services;

namespace Utilities.Services.Resources
{
    internal class AssemblyResourceManager : IAssemblyResourceManager
    {
        #region Public Methods

        public async Task<string> GetFileContentAsync(Assembly assembly, string filePath)
        {
            var resourcePath = ConvertToResourcePath(assembly, filePath);

            await using var stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
                throw new AssemblyResourceNotFoundException(assembly, filePath);

            using var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }

        #endregion

        #region Private Methods

        private static string ConvertToResourcePath(Assembly assembly, string filePath)
        {
            var assemblyName = assembly.GetName();
            var shortAssemblyName = assemblyName.Name;

            var dotSeparatedPath = filePath.Replace(Path.DirectorySeparatorChar, '.')
                                           .Replace(Path.AltDirectorySeparatorChar, '.');

            return $"{shortAssemblyName}.{dotSeparatedPath}";
        }

        #endregion
    }
}
