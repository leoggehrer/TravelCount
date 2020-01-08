using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelCount.Logic.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Currency = table.Column<string>(maxLength: 10, nullable: false),
                    Friends = table.Column<string>(maxLength: 1024, nullable: false),
                    Category = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Friend = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Travel_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_TravelId",
                table: "Expense",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_Designation",
                table: "Travel",
                column: "Designation",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Travel");
        }
    }
}
