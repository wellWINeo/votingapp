using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteFormComment_VoteForm_VoteFormId",
                table: "VoteFormComment");

            migrationBuilder.DropIndex(
                name: "IX_VoteFormComment_VoteFormId",
                table: "VoteFormComment");

            migrationBuilder.DropColumn(
                name: "VoteFormId",
                table: "VoteFormComment");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "VoteFormComment",
                type: "text",
                nullable: false,
                defaultValue: "05/16/2023 21:45:49",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "FormId",
                table: "VoteFormComment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VoteFormComment_FormId",
                table: "VoteFormComment",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteFormComment_VoteForm_FormId",
                table: "VoteFormComment",
                column: "FormId",
                principalTable: "VoteForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteFormComment_VoteForm_FormId",
                table: "VoteFormComment");

            migrationBuilder.DropIndex(
                name: "IX_VoteFormComment_FormId",
                table: "VoteFormComment");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "VoteFormComment");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "VoteFormComment",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "05/16/2023 21:45:49");

            migrationBuilder.AddColumn<Guid>(
                name: "VoteFormId",
                table: "VoteFormComment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoteFormComment_VoteFormId",
                table: "VoteFormComment",
                column: "VoteFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteFormComment_VoteForm_VoteFormId",
                table: "VoteFormComment",
                column: "VoteFormId",
                principalTable: "VoteForm",
                principalColumn: "Id");
        }
    }
}
