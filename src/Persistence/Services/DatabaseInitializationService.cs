// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Services
{
    internal class DatabaseInitializationService : IDatabaseInitializationService
    {
        #region Dependencies

        private readonly ApplicationContext _applicationContext;
        private readonly IDatabaseScriptManager _databaseScriptManager;

        #endregion

        #region Constructors

        public DatabaseInitializationService(
            ApplicationContext applicationContext, 
            IDatabaseScriptManager databaseScriptManager)
        {
            _applicationContext = applicationContext;
            _databaseScriptManager = databaseScriptManager;
        }

        #endregion

        #region Public Methods

        public async Task InitializeDatabaseAsync()
        {
            if (await IsDatabaseInitializedAsync())
                return;

            var creationScriptSql = await _databaseScriptManager.GetCreateTablesScriptContentAsync();
            await _applicationContext.Database.ExecuteSqlRawAsync(creationScriptSql);
        }

        #endregion

        #region Private Methods

        private async Task<bool> IsDatabaseInitializedAsync()
        {
            var tableName = GetDatabaseInformationTableName();
            var sql = $"select isnull(object_id('{tableName}', 'U'), -1) as [database_version]";

            var databaseInformation = await _applicationContext.DatabaseInformation.FromSqlRaw(sql).SingleAsync();
            return databaseInformation.DatabaseVersion >= 0;
        }

        private static string GetDatabaseInformationTableName()
        {
            var databaseInformationType = typeof(DatabaseInformation);
            var tableAttribute = databaseInformationType.GetCustomAttribute<TableAttribute>();

            if (tableAttribute == null)
            {
                throw new ApplicationInitializationException(
                    $"Table attribute is not specified on the {databaseInformationType} type");
            }

            return tableAttribute.Name;
        }

        #endregion
    }
}
