using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Grpc.Server.Data.PostgreSql
{
    /// <summary>
    /// Мигратор
    /// </summary>
    public class DbMigrator
    {
        private readonly EfContext _documentDbContext;
        private readonly ILogger<DbMigrator> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        /// <param name="logger">Логгер</param>
        /// <param name="dbSeeder">Сервис добавления данных в БД</param>
        public DbMigrator(EfContext dbContext, ILogger<DbMigrator> logger)
        {
            _documentDbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Мигрировать БД
        /// </summary>
        /// <returns>Ничего</returns>
        public async Task MigrateAsync()
        {
            var operationId = Guid.NewGuid().ToString().Substring(0, 4);
            _logger.LogInformation($"UpdateDatabase:{operationId}: starting...");
            try
            {
                await _documentDbContext.Database.MigrateAsync().ConfigureAwait(false);
                await _documentDbContext.Database.ExecuteSqlRawAsync("DELETE FROM grpc_data");
                _logger.LogInformation($"UpdateDatabase:{operationId}: successfully done");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"UpdateDatabase:{operationId}: failed");
                throw;
            }
        }
    }
}
