using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Sample.Migrations
{
    /// <inheritdoc />
    public partial class DB_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    maxMachines = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachinesAttirbutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    timestamp = table.Column<double>(type: "float", nullable: true),
                    speed = table.Column<double>(type: "float", nullable: true),
                    imei = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachinesAttirbutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineSerial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Trademark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineHours = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineHours = table.Column<double>(type: "float", nullable: true),
                    FuelFilter = table.Column<bool>(type: "bit", nullable: true),
                    EngineOilAmmount = table.Column<int>(type: "int", nullable: true),
                    TransmisionOilAmmount = table.Column<int>(type: "int", nullable: true),
                    CabAirFilter = table.Column<bool>(type: "bit", nullable: true),
                    EngineAirFilter = table.Column<bool>(type: "bit", nullable: true),
                    Aditional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Machines",
                        column: x => x.Id,
                        principalTable: "Machines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_AccountId",
                table: "Machines",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachinesAttirbutes");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
