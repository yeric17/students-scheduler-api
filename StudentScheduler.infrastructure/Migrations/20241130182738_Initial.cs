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
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PermissionName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                })
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
                name: "RolePermissions",
                columns: table => new
                {
                    RolePermissionsId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdentityRoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PermissionId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.RolePermissionsId);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_IdentityRoleId",
                        column: x => x.IdentityRoleId,
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
                table: "Permissions",
                columns: new[] { "PermissionId", "PermissionName" },
                values: new object[,]
                {
                    { "082c5c27-b73a-43ed-911d-f82f55f649d7", "subjectAssignment:deleteOwn" },
                    { "867c86a7-5eab-4429-ad78-539b426967d7", "enrollment:updateOwn" },
                    { "86eff601-6a54-4295-8ecc-93bf531891b8", "subjectAssignment:updateOwn" },
                    { "b1e31dea-8432-49e6-b243-e002bbda55f1", "subjectAssignment:readOwn" },
                    { "c26fd380-5387-4430-a419-0080b53f4286", "subjectAssignment:createOwn" },
                    { "d066ac50-2ca3-4d58-ae0b-70ba051e8a66", "enrollment:createOwn" },
                    { "f093260c-4729-4d1f-bfbb-a320f8f854d0", "enrollment:deleteOwn" },
                    { "f4f15dbf-5a47-462f-bea4-6856895fcbf1", "enrollment:readOwn" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00d48d9f-d56d-470a-87f3-bdd1910198b5", null, "Admin", "ADMIN" },
                    { "37d9a3a7-6be1-4b94-b436-eefc727b65a8", null, "Student", "STUDENT" },
                    { "7818b82f-1705-447a-ad16-bd121a63b733", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Credits", "Description", "Name" },
                values: new object[,]
                {
                    { "197d92e9-a3e3-4122-ab4c-ad715806c1dc", 3, "Introducción a la Programación", "Introducción a la Programación" },
                    { "24dc14a9-1bb5-4b21-9599-2baf51d52a0c", 3, "Control de Versiones y Herramientas de Colaboración", "Control de Versiones y Herramientas de Colaboración" },
                    { "47fdaba8-5a1c-4b85-9e49-60e97a5bbb95", 3, "Computación en la Nube", "Computación en la Nube" },
                    { "6b14bb97-7ff7-405c-b20a-094b6f71cce6", 3, "Fundamentos de Ciberseguridad", "Fundamentos de Ciberseguridad" },
                    { "710dd901-acb9-4552-88d0-fa97afc05813", 3, "Sistemas de Gestión de Bases de Datos", "Sistemas de Gestión de Bases de Datos" },
                    { "82c67ba1-44e3-46c2-aaa2-06baad650e0d", 3, "Estructuras de Datos y Algoritmos", "Estructuras de Datos y Algoritmos" },
                    { "b84f60fa-6c10-42d0-ac74-d0b5db54e1e3", 3, "Ingeniería de Software", "Ingeniería de Software" },
                    { "c1e47552-90c1-4c6f-9713-9a172965a7dc", 3, "Desarrollo Web", "Desarrollo Web" },
                    { "d961b827-d21f-45d2-b597-f6b01ce716ac", 3, "Inteligencia Artificial y Aprendizaje Automático", "Inteligencia Artificial y Aprendizaje Automático" },
                    { "db823bee-1fa4-40aa-8ed4-7e5e77baa875", 3, "Desarrollo de Aplicaciones Móviles", "Desarrollo de Aplicaciones Móviles" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11c3a28d-151f-45a9-b425-56ea42cbf2f2", 0, "78db33b7-1094-4ef6-8d8d-24ad2e0d7ed8", "carlos.ramirez@inventado.com", true, "Carlos", "Ramírez", false, null, "CARLOS.RAMIREZ@INVENTADO.COM", "CARLOSRAMIREZ", "AQAAAAIAAYagAAAAEHlbY/GNM8qwtKG/Fpo6jfrXXPn4uvlLyAiF03Q9rwiZUJt+dFDPLRa36ALgBy8oXg==", null, false, "59050218-5801-452b-8777-0ee7feaafe8c", false, "CarlosRamirez" },
                    { "29e9a0c5-2785-49c8-be07-e70831c540cc", 0, "efb52c53-06f3-432e-9b6a-916beb65bc8f", "ana.martinez@inventado.com", true, "Ana", "Martínez", false, null, "ANA.MARTINEZ@INVENTADO.COM", "ANAMARTINEZ", "AQAAAAIAAYagAAAAEAxVslC786rg59iBvzLm2yTQszZW9CRVQIVt9X31MGccdkbincaaxxdzLUdlwBDGLg==", null, false, "d3a79481-03cc-4c8b-a293-1e5ba25a5c22", false, "AnaMartinez" },
                    { "49d16cb8-4c86-4449-9638-addf87d0d24f", 0, "fc54b4cf-e68f-4e4f-8892-73587731a3ba", "maria.gonzalez@inventado.com", true, "María", "González", false, null, "MARIA.GONZALEZ@INVENTADO.COM", "MARIAGONZALEZ", "AQAAAAIAAYagAAAAEFQGeEE18grJxsLRmq28bC56rJTBPDrEedrHWjJn6M3LVjbUw+lTYwvXwhc4Sp++6Q==", null, false, "3ab92c8b-fd2f-4dbf-ad54-5072d272c49a", false, "MariaGonzalez" },
                    { "b6c6c16d-de3e-48e5-9d6e-a0d0fd773b1a", 0, "6c1f7475-a6e2-4fef-bad8-4da15445f5f7", "luis.fernandez@inventado.com", true, "Luis", "Fernández", false, null, "LUIS.FERNANDEZ@INVENTADO.COM", "LUISFERNANDEZ", "AQAAAAIAAYagAAAAEChipy9r8GsHEDsqLBtAo2G0Ro9Iuc43qKfiaX5O/5aXBnu1npZU+bhvnr26dZTHng==", null, false, "c0852b65-e414-47f8-b58c-270fe6debb03", false, "LuisFernandez" },
                    { "f5408a62-9b5e-493e-85af-0df0b5d0c959", 0, "b1c4cbfc-b2e4-423f-a47c-e58ed4d2f709", "juan.perez@inventado.com", true, "Juan", "Pérez", false, null, "JUAN.PEREZ@INVENTADO.COM", "JUANPEREZ", "AQAAAAIAAYagAAAAEBNAkT7dmWJOn9a6BQROkgUMzsXquoqrXhSiiI4Wg89eKGaacbUABWXcT0NiU6KSWA==", null, false, "9d817ad7-1aa7-4a87-aa58-652cec75baed", false, "JuanPerez" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionsId", "IdentityRoleId", "PermissionId" },
                values: new object[,]
                {
                    { "14f816a6-6037-44ab-bba9-9a3ad340a06c", "37d9a3a7-6be1-4b94-b436-eefc727b65a8", "f4f15dbf-5a47-462f-bea4-6856895fcbf1" },
                    { "5012ec13-79c4-4be6-a1aa-a13a2f2367e6", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "c26fd380-5387-4430-a419-0080b53f4286" },
                    { "5054d63b-c34c-4196-a086-d8baa919848d", "37d9a3a7-6be1-4b94-b436-eefc727b65a8", "867c86a7-5eab-4429-ad78-539b426967d7" },
                    { "55d56670-47db-4a6d-8857-2de464164369", "7818b82f-1705-447a-ad16-bd121a63b733", "c26fd380-5387-4430-a419-0080b53f4286" },
                    { "5a70a0d7-0773-4b38-b4fc-1483c6425988", "7818b82f-1705-447a-ad16-bd121a63b733", "082c5c27-b73a-43ed-911d-f82f55f649d7" },
                    { "5aaf9d80-a9bd-4c2a-bf92-ce247c20f026", "7818b82f-1705-447a-ad16-bd121a63b733", "b1e31dea-8432-49e6-b243-e002bbda55f1" },
                    { "67fee206-b4dd-42b7-8d0a-42005aa06564", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "d066ac50-2ca3-4d58-ae0b-70ba051e8a66" },
                    { "702f708e-46bf-4bd3-a174-e0063c1c50fc", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "b1e31dea-8432-49e6-b243-e002bbda55f1" },
                    { "725588ea-d95b-4097-be2e-3ced2e0c65ef", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "f4f15dbf-5a47-462f-bea4-6856895fcbf1" },
                    { "78d1cbf1-17e9-452d-adf7-13e2debcad3e", "7818b82f-1705-447a-ad16-bd121a63b733", "86eff601-6a54-4295-8ecc-93bf531891b8" },
                    { "8d5fdc43-19dd-45fe-b44b-a96e83bc5287", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "86eff601-6a54-4295-8ecc-93bf531891b8" },
                    { "a67662dd-fade-41e8-9ff5-14af95db5195", "37d9a3a7-6be1-4b94-b436-eefc727b65a8", "f093260c-4729-4d1f-bfbb-a320f8f854d0" },
                    { "d7d0eb54-eeab-4321-bfcd-a9841a8534df", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "082c5c27-b73a-43ed-911d-f82f55f649d7" },
                    { "dfda65aa-2759-41cd-9485-b1c28d628ebd", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "867c86a7-5eab-4429-ad78-539b426967d7" },
                    { "f2c82317-0e2f-4af3-a5d8-d2d6ac0ab5a4", "00d48d9f-d56d-470a-87f3-bdd1910198b5", "f093260c-4729-4d1f-bfbb-a320f8f854d0" },
                    { "fcd2749e-5d2c-4bdd-8bce-06e623051873", "37d9a3a7-6be1-4b94-b436-eefc727b65a8", "d066ac50-2ca3-4d58-ae0b-70ba051e8a66" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7818b82f-1705-447a-ad16-bd121a63b733", "11c3a28d-151f-45a9-b425-56ea42cbf2f2" },
                    { "7818b82f-1705-447a-ad16-bd121a63b733", "29e9a0c5-2785-49c8-be07-e70831c540cc" },
                    { "7818b82f-1705-447a-ad16-bd121a63b733", "49d16cb8-4c86-4449-9638-addf87d0d24f" },
                    { "7818b82f-1705-447a-ad16-bd121a63b733", "b6c6c16d-de3e-48e5-9d6e-a0d0fd773b1a" },
                    { "7818b82f-1705-447a-ad16-bd121a63b733", "f5408a62-9b5e-493e-85af-0df0b5d0c959" }
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
                name: "IX_RolePermissions_IdentityRoleId",
                table: "RolePermissions",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

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
                name: "RolePermissions");

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
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
