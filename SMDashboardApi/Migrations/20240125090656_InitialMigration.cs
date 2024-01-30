using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMDashboardApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformDatasets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformDatasetId = table.Column<int>(type: "int", nullable: false),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformMetrics_PlatformDatasets_PlatformDatasetId",
                        column: x => x.PlatformDatasetId,
                        principalTable: "PlatformDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetricProgressList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    PlatformMetricId = table.Column<int>(type: "int", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricProgressList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricProgressList_PlatformMetrics_PlatformMetricId",
                        column: x => x.PlatformMetricId,
                        principalTable: "PlatformMetrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetricProgressList_PlatformMetricId",
                table: "MetricProgressList",
                column: "PlatformMetricId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDatasets_ClientId",
                table: "PlatformDatasets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformMetrics_PlatformDatasetId",
                table: "PlatformMetrics",
                column: "PlatformDatasetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetricProgressList");

            migrationBuilder.DropTable(
                name: "PlatformMetrics");

            migrationBuilder.DropTable(
                name: "PlatformDatasets");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
