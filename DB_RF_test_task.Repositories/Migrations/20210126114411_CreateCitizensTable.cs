using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_RF_test_task.Repositories.Migrations
{
    public partial class CreateCitizensTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    udate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    patronymic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    inn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    snils = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    death_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizens");
        }
    }
}
