using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class Edit_Hop_Variables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Hops",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Hops",
                newName: "Reciever");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Hops",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "Reciever",
                table: "Hops",
                newName: "From");
        }
    }
}
