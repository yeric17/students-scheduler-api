using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentScheduler.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubjectAssignments",
                columns: table => new
                {
                    SubjectAssignmentId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(50)", nullable: false),
                    TeacherId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAssignments", x => x.SubjectAssignmentId);
                    table.ForeignKey(
                        name: "FK_SubjectAssignments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAssignments_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SubjectAssignmentId = table.Column<string>(type: "varchar(50)", nullable: false),
                    StudentId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_SubjectAssignments_SubjectAssignmentId",
                        column: x => x.SubjectAssignmentId,
                        principalTable: "SubjectAssignments",
                        principalColumn: "SubjectAssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "209943fa-e10f-4b09-8910-3dcb8546b75a", null, "Student", "STUDENT" },
                    { "6a0330f1-75bc-4533-8ae6-2d99f969ccc6", null, "Admin", "ADMIN" },
                    { "fba5bdae-d7c9-438b-8e72-723437406c8e", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Credits", "Description", "Name" },
                values: new object[,]
                {
                    { "32ede726-e9a1-49d2-a398-d43a47a27bff", 3, "Desarrollo Web", "Desarrollo Web" },
                    { "37445bac-d730-45fa-8ecc-6dadb8aab435", 3, "Control de Versiones y Herramientas de Colaboración", "Control de Versiones y Herramientas de Colaboración" },
                    { "63581e6d-e82c-40f5-a688-b471b38250f7", 3, "Estructuras de Datos y Algoritmos", "Estructuras de Datos y Algoritmos" },
                    { "a852662e-fb82-44a7-83d4-6bbee7e8a125", 3, "Introducción a la Programación", "Introducción a la Programación" },
                    { "c657e2a0-a036-4e78-a053-3ad7e68d794f", 3, "Computación en la Nube", "Computación en la Nube" },
                    { "d2c67918-25de-4abf-bca8-58cd8e2713a9", 3, "Desarrollo de Aplicaciones Móviles", "Desarrollo de Aplicaciones Móviles" },
                    { "d731cfe0-3ec0-4e7b-9d59-b4e8f87cd6d9", 3, "Sistemas de Gestión de Bases de Datos", "Sistemas de Gestión de Bases de Datos" },
                    { "f3a4f062-6848-4b4f-b32d-5d382f3021f8", 3, "Ingeniería de Software", "Ingeniería de Software" },
                    { "f9e5dd1f-492c-4179-984d-4e08378fa891", 3, "Fundamentos de Ciberseguridad", "Fundamentos de Ciberseguridad" },
                    { "ff40cc71-b667-414e-9783-f6c2df8b628a", 3, "Inteligencia Artificial y Aprendizaje Automático", "Inteligencia Artificial y Aprendizaje Automático" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03009ae3-28ae-4b0a-bb1f-d23561806407", 0, "40204e55-3ce7-4c08-81af-df7757144464", "luis.fernandez@inventado.com", true, "Luis", "Fernández", false, null, "LUIS.FERNANDEZ@INVENTADO.COM", "LUISFERNANDEZ", "AQAAAAIAAYagAAAAEGqcjfxTidgBdaPfzFW21pvDYFQyOO9GOn5CzXktJ1D61SAv2peJHBogKu3GUqoZsA==", null, false, "6b1275c6-24cc-4836-8d75-68d079d6fce2", false, "LuisFernandez" },
                    { "1e42d7a8-4a79-42cb-9f62-22a8e5845f53", 0, "bc58fd2e-1e94-46e0-916a-cd995e0e2b66", "carlos.ramirez@inventado.com", true, "Carlos", "Ramírez", false, null, "CARLOS.RAMIREZ@INVENTADO.COM", "CARLOSRAMIREZ", "AQAAAAIAAYagAAAAEAncrA8E+TpEUgoSEmn3aPm4mk7wpPd27YBxEJ2XtFp6C/uyJxgdrGSFOfXpRUmzZQ==", null, false, "2b898706-fe15-4471-9913-c65256278b5e", false, "CarlosRamirez" },
                    { "91972418-cc87-4a17-806c-7a98e735d555", 0, "6a86db5d-f0fa-4516-9f51-adf4972ed9db", "maria.gonzalez@inventado.com", true, "María", "González", false, null, "MARIA.GONZALEZ@INVENTADO.COM", "MARIAGONZALEZ", "AQAAAAIAAYagAAAAEHadyc7hEIZUm7oKFGKtUH0W4FXPlR6SwjWoTb56xYNl/LA54Sm+Gx8adA73sPotRw==", null, false, "bfd4b131-145f-4dfb-98e3-05e5faeb9440", false, "MariaGonzalez" },
                    { "d3399591-9479-490a-821f-d492b9a781f2", 0, "eb2abf85-30d0-4833-aa63-3a6fbbe93646", "ana.martinez@inventado.com", true, "Ana", "Martínez", false, null, "ANA.MARTINEZ@INVENTADO.COM", "ANAMARTINEZ", "AQAAAAIAAYagAAAAECX+uuXHDkTK7E61beSUz/hUhmJ2SeGptrTXkzXpxRXZZyYrN5pmf3V10s/0rkEADQ==", null, false, "c9f1836a-73cc-456e-8960-09e11c2bf925", false, "AnaMartinez" },
                    { "e4b56a9f-32dd-4ab7-ac16-46945a2ac610", 0, "d9e9456d-1575-4c08-a089-6ec0204d21ff", "juan.perez@inventado.com", true, "Juan", "Pérez", false, null, "JUAN.PEREZ@INVENTADO.COM", "JUANPEREZ", "AQAAAAIAAYagAAAAEPX98ttJBH9qI70S81BP4teq4x6RMgiHjxb0p+kD6KbVfXIq1MOiA+b3bARgN6fIVA==", null, false, "49bbdcac-8a61-4254-b73c-508d970c5eba", false, "JuanPerez" }
                });

            migrationBuilder.InsertData(
                table: "SubjectAssignments",
                columns: new[] { "SubjectAssignmentId", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { "0de38964-42cb-455f-a9da-114268c65771", "f9e5dd1f-492c-4179-984d-4e08378fa891", "d3399591-9479-490a-821f-d492b9a781f2" },
                    { "19c33ef6-5a83-48ee-bc5a-83f2393b5bbd", "d2c67918-25de-4abf-bca8-58cd8e2713a9", "e4b56a9f-32dd-4ab7-ac16-46945a2ac610" },
                    { "2ab62f86-8cdd-475c-ace0-4f0b5ef84409", "f3a4f062-6848-4b4f-b32d-5d382f3021f8", "d3399591-9479-490a-821f-d492b9a781f2" },
                    { "33553385-82b3-4024-a61e-c8aa785db2cd", "c657e2a0-a036-4e78-a053-3ad7e68d794f", "91972418-cc87-4a17-806c-7a98e735d555" },
                    { "8c0a4e7c-b405-4a21-844a-4b7eb093563e", "d731cfe0-3ec0-4e7b-9d59-b4e8f87cd6d9", "1e42d7a8-4a79-42cb-9f62-22a8e5845f53" },
                    { "9493e727-9408-496f-b549-8b2d042e0d85", "63581e6d-e82c-40f5-a688-b471b38250f7", "91972418-cc87-4a17-806c-7a98e735d555" },
                    { "ac23e24e-e7fb-43a7-b4b3-fb16812e6519", "37445bac-d730-45fa-8ecc-6dadb8aab435", "03009ae3-28ae-4b0a-bb1f-d23561806407" },
                    { "b2200ef3-e989-4a73-8475-9373f5f22318", "32ede726-e9a1-49d2-a398-d43a47a27bff", "03009ae3-28ae-4b0a-bb1f-d23561806407" },
                    { "c422b0f7-0518-4e87-a779-f48cb2934cf7", "a852662e-fb82-44a7-83d4-6bbee7e8a125", "e4b56a9f-32dd-4ab7-ac16-46945a2ac610" },
                    { "ce948c81-709a-439c-84af-c1521a9971bf", "ff40cc71-b667-414e-9783-f6c2df8b628a", "1e42d7a8-4a79-42cb-9f62-22a8e5845f53" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fba5bdae-d7c9-438b-8e72-723437406c8e", "03009ae3-28ae-4b0a-bb1f-d23561806407" },
                    { "fba5bdae-d7c9-438b-8e72-723437406c8e", "1e42d7a8-4a79-42cb-9f62-22a8e5845f53" },
                    { "fba5bdae-d7c9-438b-8e72-723437406c8e", "91972418-cc87-4a17-806c-7a98e735d555" },
                    { "fba5bdae-d7c9-438b-8e72-723437406c8e", "d3399591-9479-490a-821f-d492b9a781f2" },
                    { "fba5bdae-d7c9-438b-8e72-723437406c8e", "e4b56a9f-32dd-4ab7-ac16-46945a2ac610" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SubjectAssignmentId",
                table: "Enrollments",
                column: "SubjectAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssignments_SubjectId",
                table: "SubjectAssignments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssignments_TeacherId",
                table: "SubjectAssignments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "SubjectAssignments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
