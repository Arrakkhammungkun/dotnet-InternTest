using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApiProject.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTablesWithStaticSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Total = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    StorageLocation = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Condition = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Borrowings",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BorrowedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateReturned = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowings", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_Borrowings_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrowing_Details",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConditionAfterReturn = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDamaged = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing_Details", x => new { x.BorrowingId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_Borrowing_Details_Borrowings_BorrowingId",
                        column: x => x.BorrowingId,
                        principalTable: "Borrowings",
                        principalColumn: "BorrowingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowing_Details_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Condition", "CreatedAt", "Description", "Name", "SerialNumber", "Status", "StorageLocation", "Total", "Unit" },
                values: new object[,]
                {
                    { 1, "Fair", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 1", "Equipment1", "SN001", "In Use", "Room 1", 2, "Unit" },
                    { 2, "Fair", new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 2", "Equipment2", "SN002", "Available", "Room 2", 3, "Unit" },
                    { 3, "Good", new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 3", "Equipment3", "SN003", "In Use", "Room 3", 4, "Unit" },
                    { 4, "Fair", new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 4", "Equipment4", "SN004", "Available", "Room 4", 5, "Unit" },
                    { 5, "Fair", new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 5", "Equipment5", "SN005", "In Use", "Room 5", 6, "Unit" },
                    { 6, "Good", new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 6", "Equipment6", "SN006", "Available", "Room 6", 7, "Unit" },
                    { 7, "Fair", new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 7", "Equipment7", "SN007", "In Use", "Room 7", 8, "Unit" },
                    { 8, "Fair", new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 8", "Equipment8", "SN008", "Available", "Room 8", 9, "Unit" },
                    { 9, "Good", new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 9", "Equipment9", "SN009", "In Use", "Room 9", 10, "Unit" },
                    { 10, "Fair", new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 10", "Equipment10", "SN010", "Available", "Room 10", 1, "Unit" },
                    { 11, "Fair", new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 11", "Equipment11", "SN011", "In Use", "Room 11", 2, "Unit" },
                    { 12, "Good", new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 12", "Equipment12", "SN012", "Available", "Room 12", 3, "Unit" },
                    { 13, "Fair", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 13", "Equipment13", "SN013", "In Use", "Room 13", 4, "Unit" },
                    { 14, "Fair", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 14", "Equipment14", "SN014", "Available", "Room 14", 5, "Unit" },
                    { 15, "Good", new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 15", "Equipment15", "SN015", "In Use", "Room 15", 6, "Unit" },
                    { 16, "Fair", new DateTime(2025, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 16", "Equipment16", "SN016", "Available", "Room 16", 7, "Unit" },
                    { 17, "Fair", new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 17", "Equipment17", "SN017", "In Use", "Room 17", 8, "Unit" },
                    { 18, "Good", new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 18", "Equipment18", "SN018", "Available", "Room 18", 9, "Unit" },
                    { 19, "Fair", new DateTime(2025, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 19", "Equipment19", "SN019", "In Use", "Room 19", 10, "Unit" },
                    { 20, "Fair", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 20", "Equipment20", "SN020", "Available", "Room 20", 1, "Unit" },
                    { 21, "Good", new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 21", "Equipment21", "SN021", "In Use", "Room 21", 2, "Unit" },
                    { 22, "Fair", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 22", "Equipment22", "SN022", "Available", "Room 22", 3, "Unit" },
                    { 23, "Fair", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 23", "Equipment23", "SN023", "In Use", "Room 23", 4, "Unit" },
                    { 24, "Good", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 24", "Equipment24", "SN024", "Available", "Room 24", 5, "Unit" },
                    { 25, "Fair", new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 25", "Equipment25", "SN025", "In Use", "Room 25", 6, "Unit" },
                    { 26, "Fair", new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 26", "Equipment26", "SN026", "Available", "Room 26", 7, "Unit" },
                    { 27, "Good", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 27", "Equipment27", "SN027", "In Use", "Room 27", 8, "Unit" },
                    { 28, "Fair", new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 28", "Equipment28", "SN028", "Available", "Room 28", 9, "Unit" },
                    { 29, "Fair", new DateTime(2025, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 29", "Equipment29", "SN029", "In Use", "Room 29", 10, "Unit" },
                    { 30, "Good", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 30", "Equipment30", "SN030", "Available", "Room 30", 1, "Unit" },
                    { 31, "Fair", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 31", "Equipment31", "SN031", "In Use", "Room 31", 2, "Unit" },
                    { 32, "Fair", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 32", "Equipment32", "SN032", "Available", "Room 32", 3, "Unit" },
                    { 33, "Good", new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 33", "Equipment33", "SN033", "In Use", "Room 33", 4, "Unit" },
                    { 34, "Fair", new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 34", "Equipment34", "SN034", "Available", "Room 34", 5, "Unit" },
                    { 35, "Fair", new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 35", "Equipment35", "SN035", "In Use", "Room 35", 6, "Unit" },
                    { 36, "Good", new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 36", "Equipment36", "SN036", "Available", "Room 36", 7, "Unit" },
                    { 37, "Fair", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 37", "Equipment37", "SN037", "In Use", "Room 37", 8, "Unit" },
                    { 38, "Fair", new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 38", "Equipment38", "SN038", "Available", "Room 38", 9, "Unit" },
                    { 39, "Good", new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 39", "Equipment39", "SN039", "In Use", "Room 39", 10, "Unit" },
                    { 40, "Fair", new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 40", "Equipment40", "SN040", "Available", "Room 40", 1, "Unit" },
                    { 41, "Fair", new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 41", "Equipment41", "SN041", "In Use", "Room 41", 2, "Unit" },
                    { 42, "Good", new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 42", "Equipment42", "SN042", "Available", "Room 42", 3, "Unit" },
                    { 43, "Fair", new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 43", "Equipment43", "SN043", "In Use", "Room 43", 4, "Unit" },
                    { 44, "Fair", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 44", "Equipment44", "SN044", "Available", "Room 44", 5, "Unit" },
                    { 45, "Good", new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 45", "Equipment45", "SN045", "In Use", "Room 45", 6, "Unit" },
                    { 46, "Fair", new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 46", "Equipment46", "SN046", "Available", "Room 46", 7, "Unit" },
                    { 47, "Fair", new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 47", "Equipment47", "SN047", "In Use", "Room 47", 8, "Unit" },
                    { 48, "Good", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 48", "Equipment48", "SN048", "Available", "Room 48", 9, "Unit" },
                    { 49, "Fair", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 49", "Equipment49", "SN049", "In Use", "Room 49", 10, "Unit" },
                    { 50, "Fair", new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Equipment 50", "Equipment50", "SN050", "Available", "Room 50", 1, "Unit" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "IsAdmin", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), "user1@example.com", "FirstName1", false, "LastName1", "1234567801" },
                    { 2, new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), "user2@example.com", "FirstName2", true, "LastName2", "1234567802" },
                    { 3, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), "user3@example.com", "FirstName3", false, "LastName3", "1234567803" },
                    { 4, new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "user4@example.com", "FirstName4", true, "LastName4", "1234567804" },
                    { 5, new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), "user5@example.com", "FirstName5", false, "LastName5", "1234567805" },
                    { 6, new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), "user6@example.com", "FirstName6", true, "LastName6", "1234567806" },
                    { 7, new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), "user7@example.com", "FirstName7", false, "LastName7", "1234567807" },
                    { 8, new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Utc), "user8@example.com", "FirstName8", true, "LastName8", "1234567808" },
                    { 9, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), "user9@example.com", "FirstName9", false, "LastName9", "1234567809" },
                    { 10, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "user10@example.com", "FirstName10", true, "LastName10", "1234567810" },
                    { 11, new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), "user11@example.com", "FirstName11", false, "LastName11", "1234567811" },
                    { 12, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "user12@example.com", "FirstName12", true, "LastName12", "1234567812" },
                    { 13, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user13@example.com", "FirstName13", false, "LastName13", "1234567813" },
                    { 14, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), "user14@example.com", "FirstName14", true, "LastName14", "1234567814" },
                    { 15, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc), "user15@example.com", "FirstName15", false, "LastName15", "1234567815" },
                    { 16, new DateTime(2025, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), "user16@example.com", "FirstName16", true, "LastName16", "1234567816" },
                    { 17, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), "user17@example.com", "FirstName17", false, "LastName17", "1234567817" },
                    { 18, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), "user18@example.com", "FirstName18", true, "LastName18", "1234567818" },
                    { 19, new DateTime(2025, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "user19@example.com", "FirstName19", false, "LastName19", "1234567819" },
                    { 20, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "user20@example.com", "FirstName20", true, "LastName20", "1234567820" },
                    { 21, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc), "user21@example.com", "FirstName21", false, "LastName21", "1234567821" },
                    { 22, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "user22@example.com", "FirstName22", true, "LastName22", "1234567822" },
                    { 23, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "user23@example.com", "FirstName23", false, "LastName23", "1234567823" },
                    { 24, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "user24@example.com", "FirstName24", true, "LastName24", "1234567824" },
                    { 25, new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), "user25@example.com", "FirstName25", false, "LastName25", "1234567825" },
                    { 26, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "user26@example.com", "FirstName26", true, "LastName26", "1234567826" },
                    { 27, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "user27@example.com", "FirstName27", false, "LastName27", "1234567827" },
                    { 28, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), "user28@example.com", "FirstName28", true, "LastName28", "1234567828" },
                    { 29, new DateTime(2025, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "user29@example.com", "FirstName29", false, "LastName29", "1234567829" },
                    { 30, new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "user30@example.com", "FirstName30", true, "LastName30", "1234567830" },
                    { 31, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), "user31@example.com", "FirstName31", false, "LastName31", "1234567831" },
                    { 32, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "user32@example.com", "FirstName32", true, "LastName32", "1234567832" },
                    { 33, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), "user33@example.com", "FirstName33", false, "LastName33", "1234567833" },
                    { 34, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "user34@example.com", "FirstName34", true, "LastName34", "1234567834" },
                    { 35, new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), "user35@example.com", "FirstName35", false, "LastName35", "1234567835" },
                    { 36, new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), "user36@example.com", "FirstName36", true, "LastName36", "1234567836" },
                    { 37, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), "user37@example.com", "FirstName37", false, "LastName37", "1234567837" },
                    { 38, new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), "user38@example.com", "FirstName38", true, "LastName38", "1234567838" },
                    { 39, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), "user39@example.com", "FirstName39", false, "LastName39", "1234567839" },
                    { 40, new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), "user40@example.com", "FirstName40", true, "LastName40", "1234567840" },
                    { 41, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), "user41@example.com", "FirstName41", false, "LastName41", "1234567841" },
                    { 42, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Utc), "user42@example.com", "FirstName42", true, "LastName42", "1234567842" },
                    { 43, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), "user43@example.com", "FirstName43", false, "LastName43", "1234567843" },
                    { 44, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user44@example.com", "FirstName44", true, "LastName44", "1234567844" },
                    { 45, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), "user45@example.com", "FirstName45", false, "LastName45", "1234567845" },
                    { 46, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), "user46@example.com", "FirstName46", true, "LastName46", "1234567846" },
                    { 47, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), "user47@example.com", "FirstName47", false, "LastName47", "1234567847" },
                    { 48, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "user48@example.com", "FirstName48", true, "LastName48", "1234567848" },
                    { 49, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), "user49@example.com", "FirstName49", false, "LastName49", "1234567849" },
                    { 50, new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), "user50@example.com", "FirstName50", true, "LastName50", "1234567850" }
                });

            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "BorrowingId", "BorrowedDate", "DateReturned", "DueDate", "EquipmentId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Returned", 1 },
                    { 2, new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Borrowed", 2 },
                    { 3, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Returned", 3 },
                    { 4, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Borrowed", 4 },
                    { 5, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), 5, "Returned", 5 },
                    { 6, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Borrowed", 6 },
                    { 7, new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), 7, "Returned", 7 },
                    { 8, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), 8, "Borrowed", 8 },
                    { 9, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Utc), 9, "Returned", 9 },
                    { 10, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), 10, "Borrowed", 10 },
                    { 11, new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 11, "Returned", 11 },
                    { 12, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), 12, "Borrowed", 12 },
                    { 13, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Utc), 13, "Returned", 13 },
                    { 14, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), 14, "Borrowed", 14 },
                    { 15, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), 15, "Returned", 15 },
                    { 16, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), 16, "Borrowed", 16 },
                    { 17, new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), 17, "Returned", 17 },
                    { 18, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), 18, "Borrowed", 18 },
                    { 19, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), 19, "Returned", 19 },
                    { 20, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 20, "Borrowed", 20 },
                    { 21, new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), 21, "Returned", 21 },
                    { 22, new DateTime(2025, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), 22, "Borrowed", 22 },
                    { 23, new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), 23, "Returned", 23 },
                    { 24, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc), 24, "Borrowed", 24 },
                    { 25, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), 25, "Returned", 25 },
                    { 26, new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), 26, "Borrowed", 26 },
                    { 27, new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc), 27, "Returned", 27 },
                    { 28, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), 28, "Borrowed", 28 },
                    { 29, new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), 29, "Returned", 29 },
                    { 30, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), 30, "Borrowed", 30 },
                    { 31, new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 31, "Returned", 31 },
                    { 32, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), 32, "Borrowed", 32 },
                    { 33, new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), 33, "Returned", 33 },
                    { 34, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Utc), 34, "Borrowed", 34 },
                    { 35, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), 35, "Returned", 35 },
                    { 36, new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), 36, "Borrowed", 36 },
                    { 37, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), 37, "Returned", 37 },
                    { 38, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), 38, "Borrowed", 38 },
                    { 39, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), 39, "Returned", 39 },
                    { 40, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), 40, "Borrowed", 40 },
                    { 41, new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Utc), 41, "Returned", 41 },
                    { 42, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 42, "Borrowed", 42 },
                    { 43, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Utc), 43, "Returned", 43 },
                    { 44, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), 44, "Borrowed", 44 },
                    { 45, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), 45, "Returned", 45 },
                    { 46, new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), 46, "Borrowed", 46 },
                    { 47, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), 47, "Returned", 47 },
                    { 48, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Utc), 48, "Borrowed", 48 },
                    { 49, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), 49, "Returned", 49 },
                    { 50, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), 50, "Borrowed", 50 }
                });

            migrationBuilder.InsertData(
                table: "Borrowing_Details",
                columns: new[] { "BorrowingId", "EquipmentId", "ConditionAfterReturn", "IsDamaged", "Note", "Quantity", "RecordedAt" },
                values: new object[,]
                {
                    { 1, 1, "Needs Repair", false, "Note for Borrowing 1", 2, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, "Good", false, "Note for Borrowing 2", 3, new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 3, "Needs Repair", true, "Note for Borrowing 3", 4, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 4, "Good", false, "Note for Borrowing 4", 5, new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 5, "Needs Repair", false, "Note for Borrowing 5", 1, new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 6, "Good", true, "Note for Borrowing 6", 2, new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 7, "Needs Repair", false, "Note for Borrowing 7", 3, new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 8, "Good", false, "Note for Borrowing 8", 4, new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 9, "Needs Repair", true, "Note for Borrowing 9", 5, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 10, "Good", false, "Note for Borrowing 10", 1, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 11, "Needs Repair", false, "Note for Borrowing 11", 2, new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 12, "Good", true, "Note for Borrowing 12", 3, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 13, "Needs Repair", false, "Note for Borrowing 13", 4, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 14, "Good", false, "Note for Borrowing 14", 5, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 15, "Needs Repair", true, "Note for Borrowing 15", 1, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 16, "Good", false, "Note for Borrowing 16", 2, new DateTime(2025, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 17, "Needs Repair", false, "Note for Borrowing 17", 3, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 18, "Good", true, "Note for Borrowing 18", 4, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 19, "Needs Repair", false, "Note for Borrowing 19", 5, new DateTime(2025, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 20, "Good", false, "Note for Borrowing 20", 1, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 21, "Needs Repair", true, "Note for Borrowing 21", 2, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 22, "Good", false, "Note for Borrowing 22", 3, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 23, "Needs Repair", false, "Note for Borrowing 23", 4, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 24, "Good", true, "Note for Borrowing 24", 5, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 25, "Needs Repair", false, "Note for Borrowing 25", 1, new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 26, "Good", false, "Note for Borrowing 26", 2, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, 27, "Needs Repair", true, "Note for Borrowing 27", 3, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, 28, "Good", false, "Note for Borrowing 28", 4, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, 29, "Needs Repair", false, "Note for Borrowing 29", 5, new DateTime(2025, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, 30, "Good", true, "Note for Borrowing 30", 1, new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 31, 31, "Needs Repair", false, "Note for Borrowing 31", 2, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 32, 32, "Good", false, "Note for Borrowing 32", 3, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 33, 33, "Needs Repair", true, "Note for Borrowing 33", 4, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 34, 34, "Good", false, "Note for Borrowing 34", 5, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 35, 35, "Needs Repair", false, "Note for Borrowing 35", 1, new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 36, 36, "Good", true, "Note for Borrowing 36", 2, new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 37, 37, "Needs Repair", false, "Note for Borrowing 37", 3, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 38, 38, "Good", false, "Note for Borrowing 38", 4, new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 39, 39, "Needs Repair", true, "Note for Borrowing 39", 5, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 40, 40, "Good", false, "Note for Borrowing 40", 1, new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 41, 41, "Needs Repair", false, "Note for Borrowing 41", 2, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 42, 42, "Good", true, "Note for Borrowing 42", 3, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 43, 43, "Needs Repair", false, "Note for Borrowing 43", 4, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 44, 44, "Good", false, "Note for Borrowing 44", 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 45, 45, "Needs Repair", true, "Note for Borrowing 45", 1, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 46, 46, "Good", false, "Note for Borrowing 46", 2, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 47, 47, "Needs Repair", false, "Note for Borrowing 47", 3, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 48, 48, "Good", true, "Note for Borrowing 48", 4, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 49, 49, "Needs Repair", false, "Note for Borrowing 49", 5, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 50, 50, "Good", false, "Note for Borrowing 50", 1, new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_Details_EquipmentId",
                table: "Borrowing_Details",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_EquipmentId",
                table: "Borrowings",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_UserId",
                table: "Borrowings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowing_Details");

            migrationBuilder.DropTable(
                name: "Borrowings");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
