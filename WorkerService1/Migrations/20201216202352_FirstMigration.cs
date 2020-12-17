using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerService1.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MicrocontrollerModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicrocontrollerModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MicrocontrollerID = table.Column<int>(type: "int", nullable: false),
                    NotificationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationModels_MicrocontrollerModels_MicrocontrollerID",
                        column: x => x.MicrocontrollerID,
                        principalTable: "MicrocontrollerModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValuesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MicrocontrollerID = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    Dust = table.Column<float>(type: "real", nullable: false),
                    DoorOpen = table.Column<bool>(type: "bit", nullable: false),
                    Power = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuesModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuesModels_MicrocontrollerModels_MicrocontrollerID",
                        column: x => x.MicrocontrollerID,
                        principalTable: "MicrocontrollerModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModels_MicrocontrollerID",
                table: "NotificationModels",
                column: "MicrocontrollerID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuesModels_MicrocontrollerID",
                table: "ValuesModels",
                column: "MicrocontrollerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationModels");

            migrationBuilder.DropTable(
                name: "ValuesModels");

            migrationBuilder.DropTable(
                name: "MicrocontrollerModels");
        }
    }
}
