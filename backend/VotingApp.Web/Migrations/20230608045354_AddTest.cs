using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "VoteFormComment",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "05/27/2023 09:03:19");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VoteFormComment",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 4, 53, 54, 704, DateTimeKind.Utc).AddTicks(9180),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "VoteFormComment",
                type: "text",
                nullable: false,
                defaultValue: "05/27/2023 09:03:19",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VoteFormComment",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 8, 4, 53, 54, 704, DateTimeKind.Utc).AddTicks(9180));
        }
    }
}
