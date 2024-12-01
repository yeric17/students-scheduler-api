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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    SubjectAssignmentId = table.Column<string>(type: "varchar(50)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Users_SubjectAssignments_SubjectAssignmentId",
                        column: x => x.SubjectAssignmentId,
                        principalTable: "SubjectAssignments",
                        principalColumn: "SubjectAssignmentId");
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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "PermissionName" },
                values: new object[,]
                {
                    { "001455ab-2bc8-41b4-b81e-3cc91f9419fe", "subjectAssignment:deleteOwn" },
                    { "0bf1470f-10c7-41a0-8fb0-61a00eba6e30", "subjectAssignment:updateOwn" },
                    { "2de2ccad-d0cc-4d91-aa42-6a2019e736b2", "enrollment:deleteOwn" },
                    { "4376a91d-0685-49c7-8608-7f9b7da1a21e", "subjectAssignment:readOwn" },
                    { "4ca83d37-9fc7-44c6-ba1d-8944ef939a4a", "enrollment:updateOwn" },
                    { "712d4463-fbb5-47dc-83a1-ce23c7cd2240", "enrollment:createOwn" },
                    { "9ebb0073-820e-4ff5-a5ae-419d89e12b96", "subjectAssignment:createOwn" },
                    { "c0e7da9e-73e6-4cb8-90a4-08141d5b5d13", "enrollment:readOwn" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53c0fc08-e0bf-4200-91a2-b594b4d004b8", null, "Admin", "ADMIN" },
                    { "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", null, "Teacher", "TEACHER" },
                    { "e3968c6b-5ef3-492a-9cbc-7ac243b3c5b2", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Credits", "Description", "Name" },
                values: new object[,]
                {
                    { "3b2ec835-b5ae-425d-b4b4-4f6e25e59326", 3, "Fundamentos de Ciberseguridad", "Fundamentos de Ciberseguridad" },
                    { "3f0b60ab-d3e5-4bf7-b8de-60ef3749f8f1", 3, "Computación en la Nube", "Computación en la Nube" },
                    { "6e8b8570-2802-4952-9abb-06704a97eef6", 3, "Estructuras de Datos y Algoritmos", "Estructuras de Datos y Algoritmos" },
                    { "7248fb57-c2a7-4d19-a95c-a51de59a5af5", 3, "Sistemas de Gestión de Bases de Datos", "Sistemas de Gestión de Bases de Datos" },
                    { "77adacb6-a671-4fed-9b23-54c3002945af", 3, "Desarrollo de Aplicaciones Móviles", "Desarrollo de Aplicaciones Móviles" },
                    { "7dc8bcc7-f26c-41aa-bd27-e4118c34e27a", 3, "Introducción a la Programación", "Introducción a la Programación" },
                    { "95b833d8-3625-4f90-85e3-830c155e5678", 3, "Desarrollo Web", "Desarrollo Web" },
                    { "9e6697ff-174a-43d3-bdc9-7481edc1f56f", 3, "Inteligencia Artificial y Aprendizaje Automático", "Inteligencia Artificial y Aprendizaje Automático" },
                    { "c1fe37ae-7bb8-446a-abd5-45b7a137a7a6", 3, "Ingeniería de Software", "Ingeniería de Software" },
                    { "f88d1ff0-9a27-44e1-8c6e-2e176a857c7b", 3, "Control de Versiones y Herramientas de Colaboración", "Control de Versiones y Herramientas de Colaboración" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubjectAssignmentId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "18cd856b-9c30-4454-8b57-f951026436fe", 0, "4369a37d-24bc-4ecd-abbd-cd80f4acbd36", "juan.perez@inventado.com", true, "Juan", "Pérez", false, null, "JUAN.PEREZ@INVENTADO.COM", "JUANPEREZ", "AQAAAAIAAYagAAAAEEShIOv867kYEVdBQwCWIhSqQGBM6lzeW5gHdXl8Pdhya0TV+YznidEUQU9zlTyIBQ==", null, false, "749e403e-6018-419a-8d0d-67ab06cd18a1", null, false, "JuanPerez" },
                    { "59277a80-b475-4272-9fa2-9066191cd86a", 0, "0c031890-23ec-4890-9547-e4dd1d153a21", "luis.fernandez@inventado.com", true, "Luis", "Fernández", false, null, "LUIS.FERNANDEZ@INVENTADO.COM", "LUISFERNANDEZ", "AQAAAAIAAYagAAAAEF5umRNA0PCooiexaaRJb5ryn19MTgtUvi/mNP2OJVoFW6fLz1FoEEdrHCfF8SyqdQ==", null, false, "4857dc82-b5d5-419e-9d59-f84f68d9ab29", null, false, "LuisFernandez" },
                    { "750e22b8-b158-45a1-93fd-8ff4b5fd861c", 0, "3bd3644b-0583-409a-8b9c-13959856fe87", "ana.martinez@inventado.com", true, "Ana", "Martínez", false, null, "ANA.MARTINEZ@INVENTADO.COM", "ANAMARTINEZ", "AQAAAAIAAYagAAAAEO2B+Vp3iTVijRqSc652TXu4ccdbE9Awe7ItwP5xM/+Cjwj6v3LQ5ovOqT0nsm8Y4w==", null, false, "18b8cc29-a320-4978-b910-a96e6a5037d1", null, false, "AnaMartinez" },
                    { "b7a567b5-fa54-477b-a698-8839baf876bb", 0, "36b53dc7-a508-45f1-af05-4ef22fe82b71", "maria.gonzalez@inventado.com", true, "María", "González", false, null, "MARIA.GONZALEZ@INVENTADO.COM", "MARIAGONZALEZ", "AQAAAAIAAYagAAAAECjHrkwFglPocFiAcMkhnkSoJXF/v1Tq2mH+1o0S9+hVBqW9PVdYcU8YUA7dGpN0cQ==", null, false, "54de6812-0b98-4a7d-bec0-da7205faac95", null, false, "MariaGonzalez" },
                    { "fa8f79d3-ffbe-4ecd-a446-d6fa925586d9", 0, "bbf8fef0-0e25-45d5-b6b9-11098909bd3b", "carlos.ramirez@inventado.com", true, "Carlos", "Ramírez", false, null, "CARLOS.RAMIREZ@INVENTADO.COM", "CARLOSRAMIREZ", "AQAAAAIAAYagAAAAEA0rgNagyronKjS9I1nE2VqlkyAiie0ps7ibYvDYZYQMsHmF6UiyveYssWVDT7Uw6w==", null, false, "797bc8d4-fdb5-41c0-bb37-5474cf15a1ea", null, false, "CarlosRamirez" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionsId", "IdentityRoleId", "PermissionId" },
                values: new object[,]
                {
                    { "1e6674ff-c1b0-4589-8130-84890204ecea", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "c0e7da9e-73e6-4cb8-90a4-08141d5b5d13" },
                    { "36d3d5c8-96cb-4e72-9783-874fa1b4c6bd", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "001455ab-2bc8-41b4-b81e-3cc91f9419fe" },
                    { "44c9d6d5-93e1-4960-b790-23ec4119467f", "e3968c6b-5ef3-492a-9cbc-7ac243b3c5b2", "2de2ccad-d0cc-4d91-aa42-6a2019e736b2" },
                    { "48f1a7ec-fea9-4a74-ba42-8f5360a13ae1", "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "0bf1470f-10c7-41a0-8fb0-61a00eba6e30" },
                    { "555a9f05-585a-4489-b64e-ce05cc6b28be", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "0bf1470f-10c7-41a0-8fb0-61a00eba6e30" },
                    { "5772b3b0-3df8-414a-92a0-0d4110153e4f", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "9ebb0073-820e-4ff5-a5ae-419d89e12b96" },
                    { "670d1bcb-c3a3-410c-888a-454d244950a6", "e3968c6b-5ef3-492a-9cbc-7ac243b3c5b2", "c0e7da9e-73e6-4cb8-90a4-08141d5b5d13" },
                    { "7aed509a-e3c4-4c7d-bbf0-162568d06a25", "e3968c6b-5ef3-492a-9cbc-7ac243b3c5b2", "712d4463-fbb5-47dc-83a1-ce23c7cd2240" },
                    { "87876198-f7a1-4494-8483-d214c3bcdecf", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "712d4463-fbb5-47dc-83a1-ce23c7cd2240" },
                    { "92cab7fc-afa2-470a-aa1f-745acfc556de", "e3968c6b-5ef3-492a-9cbc-7ac243b3c5b2", "4ca83d37-9fc7-44c6-ba1d-8944ef939a4a" },
                    { "a8ebb966-f9ce-4a93-a838-05a7cc423f4d", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "2de2ccad-d0cc-4d91-aa42-6a2019e736b2" },
                    { "b792edb2-e95b-4935-81c9-6301b4df3876", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "4ca83d37-9fc7-44c6-ba1d-8944ef939a4a" },
                    { "c92edbda-6202-44c9-8d6b-379a3528b495", "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "4376a91d-0685-49c7-8608-7f9b7da1a21e" },
                    { "d0e5b11f-43a0-4686-8f8b-1cc693ed2731", "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "001455ab-2bc8-41b4-b81e-3cc91f9419fe" },
                    { "e6d0d961-b0f9-41d0-a7dc-a3309779cb36", "53c0fc08-e0bf-4200-91a2-b594b4d004b8", "4376a91d-0685-49c7-8608-7f9b7da1a21e" },
                    { "f3650839-f92a-4f5b-8257-2f692efc606d", "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "9ebb0073-820e-4ff5-a5ae-419d89e12b96" }
                });

            migrationBuilder.InsertData(
                table: "SubjectAssignments",
                columns: new[] { "SubjectAssignmentId", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { "26032492-c81e-4e2e-a332-491aac5dbd66", "f88d1ff0-9a27-44e1-8c6e-2e176a857c7b", "59277a80-b475-4272-9fa2-9066191cd86a" },
                    { "289feb0e-dafe-47d0-a5e4-296ba21f75fc", "3f0b60ab-d3e5-4bf7-b8de-60ef3749f8f1", "b7a567b5-fa54-477b-a698-8839baf876bb" },
                    { "2a1dc4c7-aff1-4f1f-a9ec-5bce9edc5083", "6e8b8570-2802-4952-9abb-06704a97eef6", "b7a567b5-fa54-477b-a698-8839baf876bb" },
                    { "57bc0c1e-5f0b-46ce-8a20-2b9aadf03593", "3b2ec835-b5ae-425d-b4b4-4f6e25e59326", "750e22b8-b158-45a1-93fd-8ff4b5fd861c" },
                    { "682489cb-e2be-4ab4-862d-b196f8e24fb1", "7248fb57-c2a7-4d19-a95c-a51de59a5af5", "fa8f79d3-ffbe-4ecd-a446-d6fa925586d9" },
                    { "6c565099-5a55-454b-bd7b-8e712fd014ec", "9e6697ff-174a-43d3-bdc9-7481edc1f56f", "fa8f79d3-ffbe-4ecd-a446-d6fa925586d9" },
                    { "cfcccee5-4ec9-4d90-bc58-d525677872b8", "7dc8bcc7-f26c-41aa-bd27-e4118c34e27a", "18cd856b-9c30-4454-8b57-f951026436fe" },
                    { "d0e9da28-1f63-4c20-8517-3817f797369f", "77adacb6-a671-4fed-9b23-54c3002945af", "18cd856b-9c30-4454-8b57-f951026436fe" },
                    { "e24e860d-7e94-424a-8b0c-58f29fbd39ee", "c1fe37ae-7bb8-446a-abd5-45b7a137a7a6", "750e22b8-b158-45a1-93fd-8ff4b5fd861c" },
                    { "e26f9365-be56-48c1-b3dc-fd4a5a0b3b2f", "95b833d8-3625-4f90-85e3-830c155e5678", "59277a80-b475-4272-9fa2-9066191cd86a" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "18cd856b-9c30-4454-8b57-f951026436fe" },
                    { "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "59277a80-b475-4272-9fa2-9066191cd86a" },
                    { "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "750e22b8-b158-45a1-93fd-8ff4b5fd861c" },
                    { "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "b7a567b5-fa54-477b-a698-8839baf876bb" },
                    { "9da522c0-4fd0-4ae7-8f80-8570c42cc9ee", "fa8f79d3-ffbe-4ecd-a446-d6fa925586d9" }
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
                name: "IX_Users_SubjectAssignmentId",
                table: "Users",
                column: "SubjectAssignmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_SubjectAssignments_SubjectAssignmentId",
                table: "Enrollments",
                column: "SubjectAssignmentId",
                principalTable: "SubjectAssignments",
                principalColumn: "SubjectAssignmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssignments_Users_TeacherId",
                table: "SubjectAssignments",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubjectAssignments_SubjectAssignmentId",
                table: "Users");

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
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SubjectAssignments");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
