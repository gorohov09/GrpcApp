namespace GrpcClient
{
    /// <summary>
    /// Модель пакета
    /// </summary>
    public class Packet
    {
        /// <summary>
        /// Номер пакета
        /// </summary>
        public int PacketSeqNum { get; set; }

        /// <summary>
        /// Кол-во записей в пакете
        /// </summary>
        public int NRecords { get; set; }

        /// <summary>
        /// Временная метка пакета
        /// </summary>
        public DateTime PacketTimestamp { get; set; }

        /// <summary>
        /// Информация в пакете
        /// </summary>
        public List<PacketRecord> PacketData { get; set; } = default!;
    }

    /// <summary>
    /// Модель записи в пакете
    /// </summary>
    public class PacketRecord
    {
        /// <summary>
        /// Число 1
        /// </summary>
        public decimal Decimal1 { get; set; }

        /// <summary>
        /// Число 2
        /// </summary>
        public decimal Decimal2 { get; set; }

        /// <summary>
        /// Число 3
        /// </summary>
        public decimal Decimal3 { get; set; }

        /// <summary>
        /// Число 4
        /// </summary>
        public decimal Decimal4 { get; set; }

        /// <summary>
        /// Временная метка записи
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
