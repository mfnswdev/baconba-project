using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaconBA.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Eartag = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    GenitorEartag = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    MatriarchEartag = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeightDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WeightValue = table.Column<double>(type: "REAL", nullable: false),
                    AnimalEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightEntity_Animals_AnimalEntityId",
                        column: x => x.AnimalEntityId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Eartag",
                table: "Animals",
                column: "Eartag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeightEntity_AnimalEntityId",
                table: "WeightEntity",
                column: "AnimalEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeightEntity");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
