using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class seed_EditDecisions_Hop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Accept')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Pending Revision')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Resubmit')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Decline')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Send To Production')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('External Review')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Recommend Accept')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Recommend Pending Revision')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Recommend Resubmit')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Recommend Decline')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('New External Round')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Revert Decline')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Skip External Review')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Back To Review')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Back To CopyEditing')");
            migrationBuilder.Sql("INSERT INTO EditDecisions (Decision_Name) VALUES ('Back To Submission From CopyEditing')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * EditDecisions");
        }
    }
}
