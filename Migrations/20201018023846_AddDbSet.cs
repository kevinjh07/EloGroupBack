using Microsoft.EntityFrameworkCore.Migrations;

namespace EloGroupBack.Migrations
{
    public partial class AddDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Lead_LeadId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_StatusLead_StatusId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Lead_LeadId",
                table: "Opportunity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusLead",
                table: "StatusLead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opportunity",
                table: "Opportunity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lead",
                table: "Lead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "StatusLead",
                newName: "StatusLeads");

            migrationBuilder.RenameTable(
                name: "Opportunity",
                newName: "Opportunities");

            migrationBuilder.RenameTable(
                name: "Lead",
                newName: "Leads");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Opportunity_LeadId",
                table: "Opportunities",
                newName: "IX_Opportunities_LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Lead_StatusId",
                table: "Leads",
                newName: "IX_Leads_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_LeadId",
                table: "Customers",
                newName: "IX_Customers_LeadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusLeads",
                table: "StatusLeads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opportunities",
                table: "Opportunities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leads",
                table: "Leads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Leads_LeadId",
                table: "Customers",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_StatusLeads_StatusId",
                table: "Leads",
                column: "StatusId",
                principalTable: "StatusLeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Leads_LeadId",
                table: "Opportunities",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Leads_LeadId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_StatusLeads_StatusId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Leads_LeadId",
                table: "Opportunities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusLeads",
                table: "StatusLeads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opportunities",
                table: "Opportunities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leads",
                table: "Leads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "StatusLeads",
                newName: "StatusLead");

            migrationBuilder.RenameTable(
                name: "Opportunities",
                newName: "Opportunity");

            migrationBuilder.RenameTable(
                name: "Leads",
                newName: "Lead");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Opportunities_LeadId",
                table: "Opportunity",
                newName: "IX_Opportunity_LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_StatusId",
                table: "Lead",
                newName: "IX_Lead_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_LeadId",
                table: "Customer",
                newName: "IX_Customer_LeadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusLead",
                table: "StatusLead",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opportunity",
                table: "Opportunity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lead",
                table: "Lead",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Lead_LeadId",
                table: "Customer",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_StatusLead_StatusId",
                table: "Lead",
                column: "StatusId",
                principalTable: "StatusLead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Lead_LeadId",
                table: "Opportunity",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
