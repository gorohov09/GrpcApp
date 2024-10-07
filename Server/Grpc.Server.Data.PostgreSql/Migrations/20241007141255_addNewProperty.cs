using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grpc.Server.Data.PostgreSql.Migrations
{
    public partial class addNewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "record_timestamp",
                schema: "public",
                table: "grpc_data",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "record_timestamp",
                schema: "public",
                table: "grpc_data");
        }
    }
}
