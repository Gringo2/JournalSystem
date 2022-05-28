using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class Add_Seed_Data_To_Hop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Hops (Sender) VALUES ('Author'); INSERT INTO Hops (Reciever) VALUES ('Editor')");
            migrationBuilder.Sql("INSERT INTO Hops (Sender) VALUES ('Editor'); INSERT INTO Hops (Reciever) VALUES ('Reviewer')");
            migrationBuilder.Sql("INSERT INTO Hops (Sender) VALUES ('Reviewer'); INSERT INTO Hops (Reciever) VALUES ('Editor')");
            migrationBuilder.Sql("INSERT INTO Hops (Sender) VALUES ('Editor'); INSERT INTO Hops (Reciever) VALUES ('Author')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * Hops");
        }
    }
}
