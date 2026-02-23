using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using rent_for_students.Infrastructure.Data;

#nullable disable

namespace rent_for_students.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260221170000_InitialSchemaV11")]
    public partial class InitialSchemaV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HousingListings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    District = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    PricePerMonth = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    RoomType = table.Column<int>(type: "INTEGER", nullable: false),
                    AreaSqm = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingListings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ListingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicantName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalApplications_HousingListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "HousingListings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HousingListings_City",
                table: "HousingListings",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_HousingListings_IsActive",
                table: "HousingListings",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_HousingListings_PricePerMonth",
                table: "HousingListings",
                column: "PricePerMonth");

            migrationBuilder.CreateIndex(
                name: "IX_RentalApplications_CreatedAtUtc",
                table: "RentalApplications",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_RentalApplications_ListingId",
                table: "RentalApplications",
                column: "ListingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalApplications");

            migrationBuilder.DropTable(
                name: "HousingListings");
        }
    }
}
