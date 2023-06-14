using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoteResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteResult_VoteForm_FormId",
                        column: x => x.FormId,
                        principalTable: "VoteForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FormId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteValue_VoteForm_FormId",
                        column: x => x.FormId,
                        principalTable: "VoteForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteResultVoteValue",
                columns: table => new
                {
                    ResultsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValuesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteResultVoteValue", x => new { x.ResultsId, x.ValuesId });
                    table.ForeignKey(
                        name: "FK_VoteResultVoteValue_VoteResult_ResultsId",
                        column: x => x.ResultsId,
                        principalTable: "VoteResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteResultVoteValue_VoteValue_ValuesId",
                        column: x => x.ValuesId,
                        principalTable: "VoteValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteResult_FormId",
                table: "VoteResult",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteResultVoteValue_ValuesId",
                table: "VoteResultVoteValue",
                column: "ValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteValue_FormId",
                table: "VoteValue",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoteResultVoteValue");

            migrationBuilder.DropTable(
                name: "VoteResult");

            migrationBuilder.DropTable(
                name: "VoteValue");

            migrationBuilder.DropTable(
                name: "VoteForm");
        }
    }
}
