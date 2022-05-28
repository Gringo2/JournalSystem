using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class _initialized_Hop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
