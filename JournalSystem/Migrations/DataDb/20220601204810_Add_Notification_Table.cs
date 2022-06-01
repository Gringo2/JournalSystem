using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class Add_Notification_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hops",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hops",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Reciever",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Hops");

            migrationBuilder.RenameColumn(
                name: "HopId",
                table: "Papers",
                newName: "Hop_Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Hops",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "Hops",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Notify",
                table: "Hops",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Paper_Id",
                table: "Hops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Reciever_Id",
                table: "Hops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Sender_Id",
                table: "Hops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Hops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HopPaper",
                columns: table => new
                {
                    HopsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PapersPaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopPaper", x => new { x.HopsId, x.PapersPaperId });
                    table.ForeignKey(
                        name: "FK_HopPaper_Hops_HopsId",
                        column: x => x.HopsId,
                        principalTable: "Hops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopPaper_Papers_PapersPaperId",
                        column: x => x.PapersPaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hop_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notification_Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notification_Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Read = table.Column<bool>(type: "bit", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Hops_HopId",
                        column: x => x.HopId,
                        principalTable: "Hops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hops_UserId",
                table: "Hops",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HopPaper_PapersPaperId",
                table: "HopPaper",
                column: "PapersPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_HopId",
                table: "Notifications",
                column: "HopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hops_Users_UserId",
                table: "Hops",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hops_Users_UserId",
                table: "Hops");

            migrationBuilder.DropTable(
                name: "HopPaper");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Hops_UserId",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Notify",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Paper_Id",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Reciever_Id",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Sender_Id",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hops");

            migrationBuilder.RenameColumn(
                name: "Hop_Id",
                table: "Papers",
                newName: "HopId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Hops",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Reciever",
                table: "Hops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Hops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Hops",
                columns: new[] { "Id", "Reciever", "Sender" },
                values: new object[,]
                {
                    { 1, "Editor", "Author" },
                    { 2, "Reviewer", "Editor" },
                    { 3, "Editor", "Reviewer" },
                    { 4, "Author", "Editor" }
                });
        }
    }
}
