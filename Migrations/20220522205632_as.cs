using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM_Simulation.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_Clients_ClientID",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CreditID",
                table: "CreditCards");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "CreditCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_Clients_ClientID",
                table: "CreditCards",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_Clients_ClientID",
                table: "CreditCards");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "CreditCards",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CreditID",
                table: "CreditCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_Clients_ClientID",
                table: "CreditCards",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID");
        }
    }
}
