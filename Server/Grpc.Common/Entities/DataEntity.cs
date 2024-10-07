namespace Grpc.Common.Entities
{
    /// <summary>
    /// Объект Data в БД
    /// </summary>
    public class DataEntity
    {
        /// <summary>
        /// Номер пакета
        /// </summary>
        public int PacketSeqNum { get; set; }

        /// <summary>
        /// Временная метка пакета
        /// </summary>
        public DateTime PacketTimestamp { get; set; }

        /// <summary>
        /// Порядковый номер записи в пакете
        /// </summary>
        public int RecordSeqNum { get; set; }

        /// <summary>
        /// Число 1
        /// </summary>
        public double Decimal1 { get; set; }

        /// <summary>
        /// Число 2
        /// </summary>
        public double Decimal2 { get; set; }

        /// <summary>
        /// Число 3
        /// </summary>
        public double Decimal3 { get; set; }

        /// <summary>
        /// Число 4
        /// </summary>
        public double Decimal4 { get; set; }

        /// <summary>
        /// Временная метка записи
        /// </summary>
        public DateTime RecordTimestamp { get; set; }
    }
}
