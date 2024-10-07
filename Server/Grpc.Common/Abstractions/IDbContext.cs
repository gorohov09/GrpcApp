using Grpc.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grpc.Common.Abstractions
{
    /// <summary>
    /// Контеккст БД
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Объекты Data
        /// </summary>
        DbSet<DataEntity> Datas { get; }

        /// <summary>
		/// Сохранить изменения в БД
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Количество обновленных записей</returns>
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
