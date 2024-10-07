using Grpc.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grpc.Server.Data.PostgreSql.Configurations
{
    internal class DataEntityConfiguration : IEntityTypeConfiguration<DataEntity>
    {
        public void Configure(EntityTypeBuilder<DataEntity> builder)
        {
            builder.ToTable("grpc_data", "public");

            builder.HasKey(x => new { x.PacketSeqNum, x.RecordSeqNum });
        }
    }
}
