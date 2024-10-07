using Grpc.Common.Abstractions;
using Grpc.Common.Entities;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Grpc.Server.Services
{
    /// <summary>
    /// Сервис для работы с пакетами
    /// </summary>
    public class PacketService : Packeter.PacketerBase
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<PacketService> _logger;

        public PacketService(IDbContext dbContext, ILogger<PacketService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Получение пакета
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="context">Контекст</param>
        /// <returns></returns>
        public override async Task<ReceivePacketResponse> ReceivePacket(
            ReceivePacketRequest request, 
            ServerCallContext context)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            _logger.LogInformation($"Пакет с Id: {request.PacketSeqNum} принят");

            if (request.PacketData == null)
                throw new ArgumentNullException(nameof(request.PacketData));

            if (request.PacketData.Count != request.NRecords)
                return new ReceivePacketResponse { Success = false, ErrorMessaage = "Колличество записей в масиве неравно свойству NRecords" };

            var isPacketExist = await _dbContext.Datas.AnyAsync(x => x.PacketSeqNum == request.PacketSeqNum);
            if (isPacketExist)
                return new ReceivePacketResponse { Success = false, ErrorMessaage = $"Пакет с Id: {request.PacketSeqNum} уже добавлен в БД" };

            var datas = request.PacketData.Select((x, index) => new DataEntity
            {
                PacketSeqNum = request.PacketSeqNum,
                PacketTimestamp = request.PacketTimestamp.ToDateTime(),
                RecordSeqNum = index + 1,
                RecordTimestamp = x.Timestamp.ToDateTime(),
                Decimal1 = x.Decimal1,
                Decimal2 = x.Decimal2,
                Decimal3 = x.Decimal3,
                Decimal4 = x.Decimal4,
            });

            _dbContext.Datas.AddRange(datas);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Пакет с Id: {request.PacketSeqNum} успешно добавлен в БД");
            return new ReceivePacketResponse { Success = true };
        }
    }
}
