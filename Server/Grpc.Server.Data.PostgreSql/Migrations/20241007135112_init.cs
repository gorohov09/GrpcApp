using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grpc.Server.Data.PostgreSql.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "grpc_data",
                schema: "public",
                columns: table => new
                {
                    packet_seq_num = table.Column<int>(type: "integer", nullable: false),
                    record_seq_num = table.Column<int>(type: "integer", nullable: false),
                    packet_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    decimal1 = table.Column<double>(type: "double precision", nullable: false),
                    decimal2 = table.Column<double>(type: "double precision", nullable: false),
                    decimal3 = table.Column<double>(type: "double precision", nullable: false),
                    decimal4 = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grpc_data", x => new { x.packet_seq_num, x.record_seq_num });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grpc_data",
                schema: "public");
        }
    }
}
