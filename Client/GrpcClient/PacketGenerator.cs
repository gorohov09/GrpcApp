namespace GrpcClient
{
    /// <summary>
    /// Генератор пакета
    /// </summary>
    public static class PacketGenerator
    {
        /// <summary>
        /// Сгенерировать пакет
        /// </summary>
        /// <param name="packetSeqNum">Номер пакета</param>
        /// <param name="nRecords">Кол-во записей в пакете</param>
        /// <returns></returns>
        public static Packet GeneratePacket(int packetSeqNum, int nRecords)
        {
            var datas = new List<PacketRecord>();
            for (int i = 0; i < nRecords; i++)
                datas.Add(new PacketRecord
                {
                    Decimal1 = GenerateRandomDecimal(),
                    Decimal2 = GenerateRandomDecimal(),
                    Decimal3 = GenerateRandomDecimal(),
                    Decimal4 = GenerateRandomDecimal(),
                    Timestamp = DateTime.Now,
                });

            return new Packet
            {
                PacketSeqNum = packetSeqNum,
                NRecords = nRecords,
                PacketTimestamp = DateTime.Now,
                PacketData = datas
            };
        }

        public static decimal GenerateRandomDecimal()
        {
            Random random = new Random();
            double doubleValue = random.NextDouble();
            return (decimal)(doubleValue * (double)100000000000m);
        }
    }
}
