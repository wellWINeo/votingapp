using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteFormComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    VoteFormId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteFormComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteFormComment_VoteForm_VoteFormId",
                        column: x => x.VoteFormId,
                        principalTable: "VoteForm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteFormComment_VoteFormId",
                table: "VoteFormComment",
                column: "VoteFormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoteFormComment");
        }
    }
}
