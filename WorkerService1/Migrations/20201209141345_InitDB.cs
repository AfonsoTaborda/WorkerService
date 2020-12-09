using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerService1.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ValuesModels",
                table: "ValuesModels");

            migrationBuilder.RenameTable(
                name: "ValuesModels",
                newName: "Values");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Values",
                table: "Values",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Values",
                table: "Values");

            migrationBuilder.RenameTable(
                name: "Values",
                newName: "ValuesModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValuesModels",
                table: "ValuesModels",
                column: "Id");
        }
    }
}
