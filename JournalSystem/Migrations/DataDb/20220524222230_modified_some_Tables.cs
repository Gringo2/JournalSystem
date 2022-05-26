using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class modified_some_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Papers_Reviewers_ReviewerId",
                table: "Papers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewers",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reviewers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewerId",
                table: "Papers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewers",
                table: "Reviewers",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Papers_Reviewers_ReviewerId",
                table: "Papers",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Papers_Reviewers_ReviewerId",
                table: "Papers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewers",
                table: "Reviewers");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Reviewers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Reviewers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Reviewers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Reviewers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Reviewers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Reviewers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Reviewers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerId",
                table: "Papers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewers",
                table: "Reviewers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Papers_Reviewers_ReviewerId",
                table: "Papers",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
