using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class CreateCustomer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassifyCustomer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifyCustomer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_GroupID",
                table: "Customer",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ClassifyCustomer_GroupID",
                table: "Customer",
                column: "GroupID",
                principalTable: "ClassifyCustomer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ClassifyCustomer_GroupID",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "ClassifyCustomer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_GroupID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Customer");
        }
    }
}
