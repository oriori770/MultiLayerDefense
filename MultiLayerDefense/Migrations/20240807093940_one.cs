using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multi_Layer_Defense.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interceptor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterceptsThrough = table.Column<int>(type: "int", nullable: false),
                    ForType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interceptor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    EffectiveDistance = table.Column<int>(type: "int", nullable: false),
                    CounterMeasure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    InterceptorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Interceptor_InterceptorId",
                        column: x => x.InterceptorId,
                        principalTable: "Interceptor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threat_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreatId = table.Column<int>(type: "int", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterceptTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InterceptorId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Response_Interceptor_InterceptorId",
                        column: x => x.InterceptorId,
                        principalTable: "Interceptor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Response_Threat_ThreatId",
                        column: x => x.ThreatId,
                        principalTable: "Threat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InterceptorId",
                table: "Inventory",
                column: "InterceptorId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_InterceptorId",
                table: "Response",
                column: "InterceptorId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_ThreatId",
                table: "Response",
                column: "ThreatId");

            migrationBuilder.CreateIndex(
                name: "IX_Threat_WeaponId",
                table: "Threat",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Interceptor");

            migrationBuilder.DropTable(
                name: "Threat");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
