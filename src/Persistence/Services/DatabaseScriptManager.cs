// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Core.Services;

namespace Persistence.Services
{
    internal class DatabaseScriptManager : IDatabaseScriptManager
    {
        #region Constants

        private const string ScriptsDirectoryName = "Scripts";
        private const string CreateTablesScriptName = "CreateTables.sql";

        #endregion

        #region Dependencies

        private readonly IAssemblyResourceManager _assemblyResourceManager;

        #endregion

        #region Constructors

        public DatabaseScriptManager(IAssemblyResourceManager assemblyResourceManager)
        {
            _assemblyResourceManager = assemblyResourceManager;
        }

        #endregion

        #region Public Methods

        public Task<string> GetCreateTablesScriptContentAsync()
        {
            var path = Path.Combine(ScriptsDirectoryName, CreateTablesScriptName);
            var assembly = Assembly.GetExecutingAssembly();

            return _assemblyResourceManager.GetFileContentAsync(assembly, path);
        }

        #endregion
    }
}
