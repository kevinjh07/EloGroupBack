using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EloGroupBack.Migrations
{
    public partial class AddStatusLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusLead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLead", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lead_StatusId",
                table: "Lead",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_StatusLead_StatusId",
                table: "Lead",
                column: "StatusId",
                principalTable: "StatusLead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_StatusLead_StatusId",
                table: "Lead");

            migrationBuilder.DropTable(
                name: "StatusLead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_StatusId",
                table: "Lead");
        }
    }
}
