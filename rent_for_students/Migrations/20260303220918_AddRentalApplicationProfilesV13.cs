using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_for_students.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalApplicationProfilesV13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalApplicationProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProfileName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    ApplicantName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalApplicationProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalApplicationProfiles_ProfileName",
                table: "RentalApplicationProfiles",
                column: "ProfileName");

            migrationBuilder.CreateIndex(
                name: "IX_RentalApplicationProfiles_UpdatedAtUtc",
                table: "RentalApplicationProfiles",
                column: "UpdatedAtUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalApplicationProfiles");
        }
    }
}
