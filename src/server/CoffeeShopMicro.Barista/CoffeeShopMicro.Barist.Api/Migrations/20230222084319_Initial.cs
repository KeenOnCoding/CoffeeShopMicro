using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShopMicro.Barista.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToGoOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BaristaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToGoOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToGoOrder_Baristas_BaristaId",
                        column: x => x.BaristaId,
                        principalTable: "Baristas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToGoOrderMenuItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToGoOrderMenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToGoOrderMenuItem_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToGoOrderMenuItem_ToGoOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ToGoOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToGoOrder_BaristaId",
                table: "ToGoOrder",
                column: "BaristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ToGoOrderMenuItem_MenuItemId",
                table: "ToGoOrderMenuItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ToGoOrderMenuItem_OrderId",
                table: "ToGoOrderMenuItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToGoOrderMenuItem");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "ToGoOrder");

            migrationBuilder.DropTable(
                name: "Baristas");
        }
    }
}
