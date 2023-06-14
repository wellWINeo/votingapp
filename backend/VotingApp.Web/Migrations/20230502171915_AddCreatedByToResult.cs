using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByToResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VoteResult",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_VoteResult_CreatedBy",
                table: "VoteResult",
                column: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VoteResult_CreatedBy",
                table: "VoteResult");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VoteResult");
        }
    }
}
