using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FeatureMany2ManyFrameworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Frameworks_FrameworkId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FrameworkId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FrameworkId",
                table: "Features");

            migrationBuilder.CreateTable(
                name: "FeatureFramework",
                columns: table => new
                {
                    FeaturesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FrameworksId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFramework", x => new { x.FeaturesId, x.FrameworksId });
                    table.ForeignKey(
                        name: "FK_FeatureFramework_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureFramework_Frameworks_FrameworksId",
                        column: x => x.FrameworksId,
                        principalTable: "Frameworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureFramework_FrameworksId",
                table: "FeatureFramework",
                column: "FrameworksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureFramework");

            migrationBuilder.AddColumn<Guid>(
                name: "FrameworkId",
                table: "Features",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_FrameworkId",
                table: "Features",
                column: "FrameworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Frameworks_FrameworkId",
                table: "Features",
                column: "FrameworkId",
                principalTable: "Frameworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
