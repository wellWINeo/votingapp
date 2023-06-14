using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteValue_VoteForm_FormId",
                table: "VoteValue");

            migrationBuilder.DropTable(
                name: "VoteResultVoteValue");

            migrationBuilder.DropColumn(
                name: "AllowMultiple",
                table: "VoteForm");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "VoteValue",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteValue_FormId",
                table: "VoteValue",
                newName: "IX_VoteValue_QuestionId");

            migrationBuilder.CreateTable(
                name: "VoteQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsMultipleAllowed = table.Column<bool>(type: "boolean", nullable: false),
                    IsCustomAllowed = table.Column<bool>(type: "boolean", nullable: false),
                    FormId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteQuestion_VoteForm_FormId",
                        column: x => x.FormId,
                        principalTable: "VoteForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteQuestionResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteQuestionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteQuestionResult_VoteQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "VoteQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteQuestionResult_VoteResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VoteResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteQuestionResultVoteValue",
                columns: table => new
                {
                    ValuesId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoteQuestionResultId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteQuestionResultVoteValue", x => new { x.ValuesId, x.VoteQuestionResultId });
                    table.ForeignKey(
                        name: "FK_VoteQuestionResultVoteValue_VoteQuestionResult_VoteQuestion~",
                        column: x => x.VoteQuestionResultId,
                        principalTable: "VoteQuestionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteQuestionResultVoteValue_VoteValue_ValuesId",
                        column: x => x.ValuesId,
                        principalTable: "VoteValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteQuestion_FormId",
                table: "VoteQuestion",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteQuestionResult_QuestionId",
                table: "VoteQuestionResult",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteQuestionResult_ResultId",
                table: "VoteQuestionResult",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteQuestionResultVoteValue_VoteQuestionResultId",
                table: "VoteQuestionResultVoteValue",
                column: "VoteQuestionResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteValue_VoteQuestion_QuestionId",
                table: "VoteValue",
                column: "QuestionId",
                principalTable: "VoteQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteValue_VoteQuestion_QuestionId",
                table: "VoteValue");

            migrationBuilder.DropTable(
                name: "VoteQuestionResultVoteValue");

            migrationBuilder.DropTable(
                name: "VoteQuestionResult");

            migrationBuilder.DropTable(
                name: "VoteQuestion");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "VoteValue",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteValue_QuestionId",
                table: "VoteValue",
                newName: "IX_VoteValue_FormId");

            migrationBuilder.AddColumn<bool>(
                name: "AllowMultiple",
                table: "VoteForm",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                name: "IX_VoteResultVoteValue_ValuesId",
                table: "VoteResultVoteValue",
                column: "ValuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteValue_VoteForm_FormId",
                table: "VoteValue",
                column: "FormId",
                principalTable: "VoteForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
