using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCase.EFDataAccess.Migrations
{
    public partial class createTales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COUNTRIES",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    NAME = table.Column<string>(nullable: false),
                    CALTURE = table.Column<string>(nullable: false),
                    Weekends = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOOK_TRACES",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    BOOK_CHECKOUT_DATE = table.Column<DateTime>(nullable: false),
                    BOOK_RETURN_DATE = table.Column<DateTime>(nullable: true),
                    COUNTRY_ID = table.Column<Guid>(nullable: false),
                    CALCULATED = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK_TRACES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOK_TRACES_COUNTRIES_COUNTRY_ID",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY_HOLIDAYS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    COUNTRY_ID = table.Column<Guid>(nullable: false),
                    HOLIDAY = table.Column<DateTime>(nullable: false),
                    HOLIDAY_TYPE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY_HOLIDAYS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COUNTRY_HOLIDAYS_COUNTRIES_COUNTRY_ID",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_TRACES_COUNTRY_ID",
                table: "BOOK_TRACES",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COUNTRY_HOLIDAYS_COUNTRY_ID",
                table: "COUNTRY_HOLIDAYS",
                column: "COUNTRY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOK_TRACES");

            migrationBuilder.DropTable(
                name: "COUNTRY_HOLIDAYS");

            migrationBuilder.DropTable(
                name: "COUNTRIES");
        }
    }
}
