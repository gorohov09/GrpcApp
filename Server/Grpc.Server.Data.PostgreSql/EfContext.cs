using Grpc.Common.Abstractions;
using Grpc.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grpc.Server.Data.PostgreSql
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class EfContext : DbContext, IDbContext
    {
        private const string DefaultSchema = "public";

        /// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="options">Параметры подключения к БД</param>
		public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Объекты Data
        /// </summary>
        public DbSet<DataEntity> Datas { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
        }
    }
}
