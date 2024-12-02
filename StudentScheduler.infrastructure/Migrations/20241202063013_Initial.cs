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
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
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
                    { "21b69887-8135-4cce-9d61-dccd33b06447", null, "Teacher", "TEACHER" },
                    { "41f0ea18-7b14-4165-aee7-3d140e9b2007", null, "Admin", "ADMIN" },
                    { "7c4f5d15-e437-471b-b72d-97abdde2201f", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Credits", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { "0ad7e81f-ba37-427f-a2d3-03622b687139", 3, "Control de Versiones y Herramientas de Colaboración", "images/contol-de-versiones-herramientas.jpg", "Control de Versiones y Herramientas de Colaboración" },
                    { "1f55d826-4ea6-4abf-b5af-48f6bf2a89a5", 3, "Inteligencia Artificial y Aprendizaje Automático", "images/inteligencia-artificial.jpg", "Inteligencia Artificial y Aprendizaje Automático" },
                    { "2b2e7534-7e2e-4b79-a576-ddc0e545b872", 3, "Desarrollo Web", "images/desarrollo-web.jpg", "Desarrollo Web" },
                    { "3282b1de-9958-4c9a-bbb3-2419e17afd58", 3, "Estructuras de Datos y Algoritmos", "images/estructura-de-datos-algorithmos.jpg", "Estructuras de Datos y Algoritmos" },
                    { "5fb201bc-ed9e-41fe-bc68-d3ff0576fba7", 3, "Fundamentos de Ciberseguridad", "images/ciberseguridad.jpg", "Fundamentos de Ciberseguridad" },
                    { "7c6fa2c3-b162-4e77-b012-97158776c83e", 3, "Ingeniería de Software", "images/ingenieria-software.jpg", "Ingeniería de Software" },
                    { "839d08f1-9d61-4bb9-a567-6836c4bfc811", 3, "Desarrollo de Aplicaciones Móviles", "images/aplicaciones-moviles.jpg", "Desarrollo de Aplicaciones Móviles" },
                    { "9d810479-0804-4ef2-aede-73f1f4279677", 3, "Computación en la Nube", "images/computacion-en-la-nube.jpg", "Computación en la Nube" },
                    { "c021a745-3487-480f-9136-12fe8c80a8b7", 3, "Sistemas de Gestión de Bases de Datos", "images/sistema-gestion-bases-datos.jpg", "Sistemas de Gestión de Bases de Datos" },
                    { "e1a4e6f2-a71a-4037-8c97-a2555046db6d", 3, "Introducción a la Programación", "images/Introduccion-a-la-programacion.jpg", "Introducción a la Programación" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02d32c03-19d1-464d-9d04-77f2ba0d1fdf", 0, "042a536f-5254-412b-b2d1-4e912739cf08", "maria.gonzalez@inventado.com", true, "María", "González", false, null, "MARIA.GONZALEZ@INVENTADO.COM", "MARIAGONZALEZ", "AQAAAAIAAYagAAAAEGth9e2nw/jxu5180vzWdP+JG+e4ILA5ns57/muOZ/tDXeWi+3z68Jv2dhAUAj13vg==", null, false, "092c6e55-e1b6-425a-a866-1d9a7c32c585", false, "MariaGonzalez" },
                    { "4a981043-3e27-4eb9-985b-7d9c3f5181d1", 0, "de5569c3-9b81-464e-b88a-707656693d27", "juan.perez@inventado.com", true, "Juan", "Pérez", false, null, "JUAN.PEREZ@INVENTADO.COM", "JUANPEREZ", "AQAAAAIAAYagAAAAEALF73FfcbTxH+Dd/qaITaOFsR1y6lhiTIpRB1zJ3fX4J1MXdC0UW6950ZRpRmIiZA==", null, false, "8bf081a6-4a18-4c1f-9e70-4ccd2d347d02", false, "JuanPerez" },
                    { "c67c8a9c-08d7-4ac1-9f5d-21bc5d597d4a", 0, "3a97565c-752d-4182-9cb4-6b3798668575", "ana.martinez@inventado.com", true, "Ana", "Martínez", false, null, "ANA.MARTINEZ@INVENTADO.COM", "ANAMARTINEZ", "AQAAAAIAAYagAAAAEJJphZpg0GPHCDFyRao+7/lbGHmG8nri+DJPQLr5o/3KNn2L8pyY4L1f3NU4oPIL3w==", null, false, "0a9c7135-2733-4a20-9d7a-34d3fe9feb27", false, "AnaMartinez" },
                    { "dbe29fc2-594b-4dc7-aa2b-870aaca49677", 0, "909a6efa-cf9e-4d5d-9764-8cda4b80ebd7", "luis.fernandez@inventado.com", true, "Luis", "Fernández", false, null, "LUIS.FERNANDEZ@INVENTADO.COM", "LUISFERNANDEZ", "AQAAAAIAAYagAAAAEGib6TZJhFYEuhyMmGaS0hFtIU8xJAO6KzRbrYPk3KgSQzPyhW/ZmEeSCt5/9b8tSg==", null, false, "9506e43b-68e3-4563-9fc5-483e4100181f", false, "LuisFernandez" },
                    { "e0376c18-cf7f-4dbd-9008-370882730e2a", 0, "fa0bd3f2-fddd-4b81-834b-4da2d7e945b6", "carlos.ramirez@inventado.com", true, "Carlos", "Ramírez", false, null, "CARLOS.RAMIREZ@INVENTADO.COM", "CARLOSRAMIREZ", "AQAAAAIAAYagAAAAEJmr797N+u+CuPHtU1vVfra8syQTP6K3rVKLdnOcLsfv+95tMKbwWJKGgAof3j7sBQ==", null, false, "7662f3b3-7aec-47bb-a179-7b704d8b0d36", false, "CarlosRamirez" }
                });

            migrationBuilder.InsertData(
                table: "SubjectAssignments",
                columns: new[] { "SubjectAssignmentId", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { "05518608-73e0-4ef4-b22d-4a405ed763e1", "839d08f1-9d61-4bb9-a567-6836c4bfc811", "4a981043-3e27-4eb9-985b-7d9c3f5181d1" },
                    { "169b83f0-25dc-436c-bf37-c904fb2f5aad", "2b2e7534-7e2e-4b79-a576-ddc0e545b872", "dbe29fc2-594b-4dc7-aa2b-870aaca49677" },
                    { "30c54e59-f43d-499c-8c2c-e2df064280d8", "5fb201bc-ed9e-41fe-bc68-d3ff0576fba7", "c67c8a9c-08d7-4ac1-9f5d-21bc5d597d4a" },
                    { "5f7d60b4-2f80-40bd-a8d0-ef49f75f467b", "3282b1de-9958-4c9a-bbb3-2419e17afd58", "02d32c03-19d1-464d-9d04-77f2ba0d1fdf" },
                    { "643de4cf-9a1b-4c25-ab77-7b1d60f03e8c", "c021a745-3487-480f-9136-12fe8c80a8b7", "e0376c18-cf7f-4dbd-9008-370882730e2a" },
                    { "7b25a2d8-23e6-47da-84da-2ae8f3a63bf8", "9d810479-0804-4ef2-aede-73f1f4279677", "02d32c03-19d1-464d-9d04-77f2ba0d1fdf" },
                    { "8a358eaa-5b30-4559-8019-0bb4b4032e18", "7c6fa2c3-b162-4e77-b012-97158776c83e", "c67c8a9c-08d7-4ac1-9f5d-21bc5d597d4a" },
                    { "8da9f807-c09b-4db6-abc8-322bb6488b5e", "e1a4e6f2-a71a-4037-8c97-a2555046db6d", "4a981043-3e27-4eb9-985b-7d9c3f5181d1" },
                    { "d274aa0d-2803-45c5-ad8a-5d35a1e20dd1", "1f55d826-4ea6-4abf-b5af-48f6bf2a89a5", "e0376c18-cf7f-4dbd-9008-370882730e2a" },
                    { "ec1c2790-84c7-49e1-bdc0-566b2e390af3", "0ad7e81f-ba37-427f-a2d3-03622b687139", "dbe29fc2-594b-4dc7-aa2b-870aaca49677" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "21b69887-8135-4cce-9d61-dccd33b06447", "02d32c03-19d1-464d-9d04-77f2ba0d1fdf" },
                    { "21b69887-8135-4cce-9d61-dccd33b06447", "4a981043-3e27-4eb9-985b-7d9c3f5181d1" },
                    { "21b69887-8135-4cce-9d61-dccd33b06447", "c67c8a9c-08d7-4ac1-9f5d-21bc5d597d4a" },
                    { "21b69887-8135-4cce-9d61-dccd33b06447", "dbe29fc2-594b-4dc7-aa2b-870aaca49677" },
                    { "21b69887-8135-4cce-9d61-dccd33b06447", "e0376c18-cf7f-4dbd-9008-370882730e2a" }
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
