﻿// <auto-generated />
using System;
using Grpc.Server.Data.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Grpc.Server.Data.PostgreSql.Migrations
{
    [DbContext(typeof(EfContext))]
    partial class EfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Grpc.Common.Entities.DataEntity", b =>
                {
                    b.Property<int>("PacketSeqNum")
                        .HasColumnType("integer")
                        .HasColumnName("packet_seq_num");

                    b.Property<int>("RecordSeqNum")
                        .HasColumnType("integer")
                        .HasColumnName("record_seq_num");

                    b.Property<double>("Decimal1")
                        .HasColumnType("double precision")
                        .HasColumnName("decimal1");

                    b.Property<double>("Decimal2")
                        .HasColumnType("double precision")
                        .HasColumnName("decimal2");

                    b.Property<double>("Decimal3")
                        .HasColumnType("double precision")
                        .HasColumnName("decimal3");

                    b.Property<double>("Decimal4")
                        .HasColumnType("double precision")
                        .HasColumnName("decimal4");

                    b.Property<DateTime>("PacketTimestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("packet_timestamp");

                    b.Property<DateTime>("RecordTimestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("record_timestamp");

                    b.HasKey("PacketSeqNum", "RecordSeqNum")
                        .HasName("pk_grpc_data");

                    b.ToTable("grpc_data", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
