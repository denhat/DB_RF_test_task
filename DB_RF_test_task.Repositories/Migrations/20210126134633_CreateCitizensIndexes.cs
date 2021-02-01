using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_RF_test_task.Repositories.Migrations
{
    public partial class CreateCitizensIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex("Index_fullname", "Citizens", new[] { "last_name", "first_name", "patronymic" });
            migrationBuilder.CreateIndex("Index_inn", "Citizens", "inn");
            migrationBuilder.CreateIndex("Index_snils", "Citizens", "snils");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("Index_fullname", "Citizens");
            migrationBuilder.DropIndex("Index_inn", "Citizens");
            migrationBuilder.DropIndex("Index_snils", "Citizens");
        }
    }
}
