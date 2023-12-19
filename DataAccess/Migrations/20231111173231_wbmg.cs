using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class wbmg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seriya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriyaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerilmeYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verilmetarixi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dogumtarixi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatikiUnvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillialKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesabNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubHesab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Create", "Name", "Update" },
                values: new object[] { 1, new DateTime(2023, 11, 11, 21, 32, 31, 502, DateTimeKind.Local).AddTicks(2226), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Create", "Name", "Update" },
                values: new object[] { 2, new DateTime(2023, 11, 11, 21, 32, 31, 502, DateTimeKind.Local).AddTicks(2262), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Company", "Create", "Email", "Image", "ImageURL", "Password", "PasswordHash", "RoleId", "Salt", "Update", "UserName" },
                values: new object[] { 1, null, new DateTime(2023, 11, 11, 21, 32, 31, 502, DateTimeKind.Local).AddTicks(3106), "naib.ibishov@asb.az", null, "user.png", "20012008Nq!", "	nj'9�vV��qM���B�\\������\rV\r", 1, "pnvy8wrrpo6OLw==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "naib.ibishov" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCards_UserId",
                table: "OrderCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
