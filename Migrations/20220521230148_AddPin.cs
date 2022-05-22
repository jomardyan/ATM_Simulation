using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM_Simulation.Migrations
{
    public partial class AddPin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PIN",
                table: "Clients",
                type: "INTEGER",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIN",
                table: "Clients");
        }
    }
}
