using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalSystem.Migrations.DataDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Institutiion_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institution_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institution_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institution_website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    f_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    l_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                    table.ForeignKey(
                        name: "FK_Authors_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTopic",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicsTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTopic", x => new { x.CategoryId, x.TopicsTopicId });
                    table.ForeignKey(
                        name: "FK_CategoryTopic_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTopic_Topic_TopicsTopicId",
                        column: x => x.TopicsTopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    PaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abstract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Page_size = table.Column<int>(type: "int", nullable: false),
                    Tracking_no = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.PaperId);
                    table.ForeignKey(
                        name: "FK_Papers_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPaper",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PapersPaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPaper", x => new { x.AuthorId, x.PapersPaperId });
                    table.ForeignKey(
                        name: "FK_AuthorPaper_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPaper_Papers_PapersPaperId",
                        column: x => x.PapersPaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPaper",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PapersPaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPaper", x => new { x.CategoriesCategoryId, x.PapersPaperId });
                    table.ForeignKey(
                        name: "FK_CategoryPaper_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPaper_Papers_PapersPaperId",
                        column: x => x.PapersPaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPaper_PapersPaperId",
                table: "AuthorPaper",
                column: "PapersPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_InstitutionId",
                table: "Authors",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPaper_PapersPaperId",
                table: "CategoryPaper",
                column: "PapersPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTopic_TopicsTopicId",
                table: "CategoryTopic",
                column: "TopicsTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_TopicId",
                table: "Papers",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPaper");

            migrationBuilder.DropTable(
                name: "CategoryPaper");

            migrationBuilder.DropTable(
                name: "CategoryTopic");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
