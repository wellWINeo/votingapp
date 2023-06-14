using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "VoteFormComment",
                type: "text",
                nullable: false,
                defaultValue: "05/27/2023 09:03:19",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "05/16/2023 21:45:49");

            migrationBuilder.AddColumn<int>(
                name: "Access",
                table: "VoteForm",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "VoteForm");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "VoteFormComment",
                type: "text",
                nullable: false,
                defaultValue: "05/16/2023 21:45:49",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "05/27/2023 09:03:19");
        }
    }
}
