using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Repository.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInCinemaCarts",
                table: "TicketInCinemaCarts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInCinemaCarts",
                table: "TicketInCinemaCarts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrders",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInCinemaCarts_TicketId",
                table: "TicketInCinemaCarts",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.DropIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInCinemaCarts",
                table: "TicketInCinemaCarts");

            migrationBuilder.DropIndex(
                name: "IX_TicketInCinemaCarts_TicketId",
                table: "TicketInCinemaCarts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                columns: new[] { "TicketId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInCinemaCarts",
                table: "TicketInCinemaCarts",
                columns: new[] { "TicketId", "CinemaCartId" });
        }
    }
}
