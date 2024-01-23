using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterResponse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualsAffected",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamageCases = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualsAffected", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AidType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aids_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AidRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    AmountProvided = table.Column<int>(type: "int", nullable: false),
                    AidId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndividualAffectedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AidRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AidRequests_Aids_AidId",
                        column: x => x.AidId,
                        principalTable: "Aids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AidRequests_IndividualsAffected_IndividualAffectedId",
                        column: x => x.IndividualAffectedId,
                        principalTable: "IndividualsAffected",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeAid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeAid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeAid_Aids_AidId",
                        column: x => x.AidId,
                        principalTable: "Aids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomeAid_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AidRequests_AidId",
                table: "AidRequests",
                column: "AidId");

            migrationBuilder.CreateIndex(
                name: "IX_AidRequests_IndividualAffectedId",
                table: "AidRequests",
                column: "IndividualAffectedId");

            migrationBuilder.CreateIndex(
                name: "IX_Aids_DonorId",
                table: "Aids",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeAid_AidId",
                table: "IncomeAid",
                column: "AidId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeAid_DonorId",
                table: "IncomeAid",
                column: "DonorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AidRequests");

            migrationBuilder.DropTable(
                name: "IncomeAid");

            migrationBuilder.DropTable(
                name: "IndividualsAffected");

            migrationBuilder.DropTable(
                name: "Aids");

            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
