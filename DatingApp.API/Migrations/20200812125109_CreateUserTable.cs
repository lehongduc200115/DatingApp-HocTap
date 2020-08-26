using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class CreateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ClassifyCustomer_GroupID",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "GroupID",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ClassifyCustomer_GroupID",
                table: "Customer",
                column: "GroupID",
                principalTable: "ClassifyCustomer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ClassifyCustomer_GroupID",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<int>(
                name: "GroupID",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ClassifyCustomer_GroupID",
                table: "Customer",
                column: "GroupID",
                principalTable: "ClassifyCustomer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
