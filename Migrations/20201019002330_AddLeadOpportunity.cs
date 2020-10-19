using Microsoft.EntityFrameworkCore.Migrations;

namespace EloGroupBack.Migrations
{
    public partial class AddLeadOpportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Leads_LeadId",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_LeadId",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Opportunities");

            migrationBuilder.CreateTable(
                name: "LeadOpportunities",
                columns: table => new
                {
                    LeadId = table.Column<int>(nullable: false),
                    OpportunityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadOpportunities", x => new { x.LeadId, x.OpportunityId });
                    table.ForeignKey(
                        name: "FK_LeadOpportunities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadOpportunities_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadOpportunities_OpportunityId",
                table: "LeadOpportunities",
                column: "OpportunityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadOpportunities");

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Opportunities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_LeadId",
                table: "Opportunities",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Leads_LeadId",
                table: "Opportunities",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
