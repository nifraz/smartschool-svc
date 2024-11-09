using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Year = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Year);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IetfTag = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SinhalaName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamilName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SinhalaName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamilName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SinhalaName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamilName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SinhalaName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamilName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Section = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageCode = table.Column<string>(type: "varchar(2)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassStudentEnrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RollNo = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemovedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemoveReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    ClassId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolStudentEnrollmentId = table.Column<long>(type: "bigint", nullable: false),
                    AcademicYearYear = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudentEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudentEnrollments_AcademicYears_AcademicYearYear",
                        column: x => x.AcademicYearYear,
                        principalTable: "AcademicYears",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudentEnrollments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassTeacherEnrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemovedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemovedReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    ClassId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolTeacherEnrollmentId = table.Column<long>(type: "bigint", nullable: false),
                    AcademicYearYear = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacherEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassTeacherEnrollments_AcademicYears_AcademicYearYear",
                        column: x => x.AcademicYearYear,
                        principalTable: "AcademicYears",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeacherEnrollments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonQualifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AwardedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    QualificationId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonQualifications_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonRelationships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentPersonId = table.Column<long>(type: "bigint", nullable: false),
                    ChildPersonId = table.Column<long>(type: "bigint", nullable: false),
                    ParentToChildRelationship = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRelationships", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nickname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    BcNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sex = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    NicNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PassportNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMobileNoVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VerificationToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TokenExpiration = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Principals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Principals_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Principals_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Principals_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Principals_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CensusNo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schools_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schools_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schools_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistrationNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServiceGrade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolPrincipalEnrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    No = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemovedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    PrincipalId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPrincipalEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolPrincipalEnrollments_Principals_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolPrincipalEnrollments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolPrincipalEnrollments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolPrincipalEnrollments_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolPrincipalEnrollments_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolStudentEnrollmentRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    AcademicYearYear = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolStudentEnrollmentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollmentRequests_AcademicYears_AcademicYearYe~",
                        column: x => x.AcademicYearYear,
                        principalTable: "AcademicYears",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollmentRequests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollmentRequests_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollmentRequests_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollmentRequests_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollmentRequests_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolTeacherEnrollmentRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTeacherEnrollmentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollmentRequests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollmentRequests_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollmentRequests_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollmentRequests_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollmentRequests_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolTeacherEnrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    No = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemovedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTeacherEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollments_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolTeacherEnrollments_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolStudentEnrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    No = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolStudentEnrollmentRequestId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolStudentEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollments_SchoolStudentEnrollmentRequests_Sch~",
                        column: x => x.SchoolStudentEnrollmentRequestId,
                        principalTable: "SchoolStudentEnrollmentRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollments_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolStudentEnrollments_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "Year", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1998, new DateOnly(1998, 12, 31), new DateOnly(1998, 1, 1) },
                    { 1999, new DateOnly(1999, 12, 31), new DateOnly(1999, 1, 1) },
                    { 2024, new DateOnly(2024, 12, 31), new DateOnly(2024, 1, 1) },
                    { 2025, new DateOnly(2025, 12, 31), new DateOnly(2025, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "IetfTag", "Name" },
                values: new object[,]
                {
                    { "ar", "ar-SA", "Arabic" },
                    { "en", "en-UK", "English" },
                    { "si", "si-LK", "Sinhala" },
                    { "ta", "ta-LK", "Tamil" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "BcNo", "CreatedTime", "CreatedUserId", "DateOfBirth", "DeletedTime", "DeletedUserId", "Email", "FullName", "Image", "LastModifiedTime", "LastModifiedUserId", "MobileNo", "NicNo", "Nickname", "PassportNo", "Sex", "ShortName" },
                values: new object[,]
                {
                    { 1L, "123, Kandy", "111", null, null, new DateOnly(2000, 1, 1), null, null, "admin@system.com", "System Admin", null, null, null, "0000000000", "1111111111", "Admin", null, (byte)9, "System" },
                    { 2L, "61/3, Napana, Gunnepana", "123", null, null, new DateOnly(1993, 3, 19), null, null, "nifraz@live.com", "Nifraz Navahz", null, null, null, "0712319319", "930793922V", "Nifraz", null, (byte)1, "Nifraz" },
                    { 3L, "61/3, Napana, Gunnepana", "123", null, null, new DateOnly(1962, 3, 19), null, null, "ayesha@live.com", "Ayesha Rauf", null, null, null, "0776791138", null, "Ayesha", null, (byte)2, "Ayesha" },
                    { 4L, "61/3, Napana, Gunnepana", "123", null, null, new DateOnly(1952, 3, 19), null, null, "navahz@gmail.com", "Mohamad Navahz", null, null, null, "0756825831", null, "Navahz", null, (byte)1, "Navahz" },
                    { 5L, "123, Madawala Bazaar", "123", null, null, new DateOnly(1980, 3, 19), null, null, "nisry@gmail.com", "Nisry Ahamed", null, null, null, "0770808306", null, "Nisry", null, (byte)1, "Nisry" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "SinhalaName", "TamilName" },
                values: new object[,]
                {
                    { 1, "Western", "බස්නාහිර", "மேற்கு" },
                    { 2, "Central", "මධ්‍යම", "மத்திய" },
                    { 3, "Southern", "දකුණු", "தெற்கு" },
                    { 4, "Northern", "උතුරු", "வடக்கு" },
                    { 5, "Eastern", "නැගෙනහිර", "கிழக்கு" },
                    { 6, "North Western", "වයඹ", "வடமேற்கு" },
                    { 7, "North Central", "උතුරුමැද", "வடமத்திய" },
                    { 8, "Uva", "ඌව", "ஊவா" },
                    { 9, "Sabaragamuwa", "සබරගමුව", "சபரகமுவா" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Name", "ProvinceId", "SinhalaName", "TamilName" },
                values: new object[,]
                {
                    { 1, "Colombo", 1, "කොළඹ", "கொழும்பு" },
                    { 2, "Gampaha", 1, "ගම්පහ", "கம்பகா" },
                    { 3, "Kalutara", 1, "කළුතර", "களுத்துறை" },
                    { 4, "Kandy", 2, "මහනුවර", "கண்டி" },
                    { 5, "Matale", 2, "මාතලේ", "மாத்தளை" },
                    { 6, "Nuwara Eliya", 2, "නුවරඑළිය", "நுவரெலியா" },
                    { 7, "Galle", 3, "ගාල්ල", "காலி" },
                    { 8, "Matara", 3, "මාතර", "மாத்தறை" },
                    { 9, "Hambantota", 3, "හම්බන්තොට", "அம்பாந்தோட்டை" },
                    { 10, "Jaffna", 4, "යාපනය", "யாழ்ப்பாணம்" },
                    { 11, "Mannar", 4, "මන්නාරම", "மன்னார்" },
                    { 12, "Vavuniya", 4, "වවුනියාව", "வவுனியா" },
                    { 13, "Mullativu", 4, "මුලතිව්", "முல்லைத்தீவு" },
                    { 14, "Killinochchi", 4, "කිලිනොච්චිය", "கிளிநொச்சி" },
                    { 15, "Batticaloa", 5, "මඩකලපුව", "மட்டக்களப்பு" },
                    { 16, "Ampara", 5, "අම්පාර", "அம்பாறை" },
                    { 17, "Trincomalee", 5, "ත්‍රිකුණාමල", "திருகோணமலை" },
                    { 18, "Kurunegala", 6, "කුරුණෑගල", "குருநாகல்" },
                    { 19, "Puttalam", 6, "පුත්තලම", "புத்தளம்" },
                    { 20, "Anuradhapura", 7, "අනුරාධපුර", "அனுராதபுரம்" },
                    { 21, "Polonnaruwa", 7, "පොලොන්නරු", "பொலநறுவை" },
                    { 22, "Badulla", 8, "බදුල්ල", "பதுளை" },
                    { 23, "Moneragala", 8, "මොණරාගල", "மொனராகலை" },
                    { 24, "Ratnapura", 9, "රත්නපුර", "இரத்தினபுரி" },
                    { 25, "Kegalle", 9, "කෑගල්ල", "கேகாலை" }
                });

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "PersonId" },
                values: new object[] { 1L, null, null, null, null, null, null, 5L });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "PersonId" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, 2L },
                    { 2L, null, null, null, null, null, null, 3L }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "PersonId", "RegistrationNo", "ServiceGrade" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, 3L, null, null },
                    { 2L, null, null, null, null, null, null, 4L, null, null },
                    { 3L, null, null, null, null, null, null, 5L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "IsEmailVerified", "IsMobileNoVerified", "LastModifiedTime", "LastModifiedUserId", "Password", "PersonId", "TokenExpiration", "VerificationToken" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$lHv+DlfpllvYbs+8GWuNsA$+WTNNrQanqHp8E6S+GIrCszW6uLC3Mfg2E4Ms46F6UA", 1L, null, null },
                    { 2L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$s9Jpw9YuIHifyU3xe2cr+w$F0d46kxMb4JzagVLUEafFrnp9Mn4lfiRQmJ2hue3WZQ", 2L, null, null },
                    { 3L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$T5pFTxioBddRwnwsyvrZaA$rc90zpKMZ/asixe7QEUsI4GWwUAunDJNZmvlIuFP1D4", 3L, null, null },
                    { 4L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$AIMGxr8Y/MPsI3H7knXFcQ$Pqaz7xjzp8WQtS7BgGcLXkWSwnuVQ58TQd6B7JuDmKo", 4L, null, null },
                    { 5L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$+pdX6kgi7ppWc0ZiAQZR1g$ayXNZw8T/w3NlkGFzmQgXQ3kr4O8IFo0S6fUom3BVo8", 5L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "Id", "DistrictId", "Name", "SinhalaName", "TamilName" },
                values: new object[,]
                {
                    { 1, 1, "Colombo Zone", "කොළඹ කලාපය", "கொழும்பு வலயம்" },
                    { 2, 1, "Homagama Zone", "හෝමාගම කලාපය", "ஹோமாகம வலயம்" },
                    { 3, 1, "Piliyandala Zone", "පිළියන්දල කලාපය", "பிலியந்தல வலயம்" },
                    { 4, 1, "Sri Jayawardenapura Zone", "ශ්‍රී ජයවර්ධනපුර කලාපය", "ஸ்ரீ ஜயவர்த்தனபுர வலயம்" },
                    { 5, 2, "Gampaha Zone", "ගම්පහ කලාපය", "கம்பஹா வலயம்" },
                    { 6, 2, "Kelaniya Zone", "කැලණිය කලාපය", "கெலனியா வலயம்" },
                    { 7, 2, "Minuwangoda Zone", "මිනුවන්ගොඩ කලාපය", "மினுவாங்கொட வலயம்" },
                    { 8, 2, "Negombo Zone", "නිකඹා කලාපය", "நிகம்போ வலயம்" },
                    { 9, 3, "Horana Zone", "හොරණ කලාපය", "ஹோரனா வலயம்" },
                    { 10, 3, "Kalutara Zone", "කළුතර කලාපය", "களுத்துறை வலயம்" },
                    { 11, 3, "Matugama Zone", "මතුගම කලාපය", "மதுகம வலயம்" },
                    { 12, 4, "Denuwara Zone", "දෙනුවර කලාපය", "தெனுவர வலயம்" },
                    { 13, 4, "Gampola Zone", "ගම්පොල කලාපය", "கம்பொலா வலயம்" },
                    { 14, 4, "Kandy Zone", "මහනුවර කලාපය", "கண்டி வலயம்" },
                    { 15, 4, "Katugastota Zone", "කටුගස්තොට කලාපය", "கட்டுகஸ்தோட்ட வலயம்" },
                    { 16, 4, "Teldeniya Zone", "තෙල්දෙණිය කලාපය", "தெல்தெணிய வலயம்" },
                    { 17, 4, "Wattegama Zone", "වත්තේගම කලාපය", "வத்தேகம வலயம்" },
                    { 18, 5, "Galewala Zone", "ගලේවල කලාපය", "கலேவலா வலயம்" },
                    { 19, 5, "Matale Zone", "මාතලේ කලාපය", "மாத்தலே வலயம்" },
                    { 20, 5, "Naula Zone", "නාවුල කලාපය", "நௌலா வலயம்" },
                    { 21, 5, "Wilgamuwa Zone", "විල්ගමුව කලාපය", "வில்கமுவ வலயம்" },
                    { 22, 6, "Hanguranketha Zone", "හඟුරන්කෙත කලාපය", "ஹங்குரன்கெத வலயம்" },
                    { 23, 6, "Hatton Zone", "හැටන් කලාපය", "ஹட்டன் வலயம்" },
                    { 24, 6, "Kotmale Zone", "කොත්මලේ කලාපය", "கொத்மலே வலயம்" },
                    { 25, 6, "Nuwara Eliya Zone", "නුවර එළිය කලාපය", "நுவரெலியா வலயம்" },
                    { 26, 6, "Walapane Zone", "වලපනේ කලාපය", "வலபனே வலயம்" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "Name", "SinhalaName", "TamilName", "ZoneId" },
                values: new object[,]
                {
                    { 1, "Borella", "බොරැල්ල", "பொரெல்ல", 1 },
                    { 2, "Colombo Central", "කොළඹ මධ්‍යම", "மத்திய கொழும்பு", 1 },
                    { 3, "Colombo North", "කොළඹ උතුර", "வட கொழும்பு", 1 },
                    { 4, "Colombo South", "කොළඹ දකුණ", "தெற்கு கொழும்பு", 1 },
                    { 5, "Hanwella", "හාන්වැල්ල", "ஹான்வெல்ல", 2 },
                    { 6, "Homagama", "හෝමාගම", "ஹோமாகம", 2 },
                    { 7, "Padukka", "පඩුක්ක", "பதுக்கா", 2 },
                    { 8, "Dehiwala", "දෙහිවල", "தேஹிவளை", 3 },
                    { 9, "Kesbewa", "කැස්බෑව", "கெஸ்பேவ", 3 },
                    { 10, "Moratuwa", "මොරටුව", "மொறட்டுவ", 3 },
                    { 11, "Kaduwela", "කඩුවෙල", "கடுவெல", 4 },
                    { 12, "Kolonnawa", "කොළොන්නාව", "கொலன்னாவ", 4 },
                    { 13, "Maharagama", "මහරගම", "மஹரகம", 4 },
                    { 14, "Nugegoda", "නුගේගොඩ", "நுகேகொடா", 4 },
                    { 15, "Attanagalla", "අත්තනගල්ල", "அத்தனகல்ல", 5 },
                    { 16, "Dompe (Weke)", "දොම්පේ (වේකේ)", "டொம்பே (வேக்கே)", 5 },
                    { 17, "Gampaha", "ගම්පහ", "கம்பஹா", 5 },
                    { 18, "Biyagama", "බියගම", "பியகம", 6 },
                    { 19, "Kelaniya", "කැලණිය", "கெலனியா", 6 },
                    { 20, "Mahara", "මහර", "மஹர", 6 },
                    { 21, "Wattala", "වත්තල", "வட்டலா", 6 },
                    { 22, "Divulapitiya", "දිවුලපිටිය", "திவுலபிட்டிய", 7 },
                    { 23, "Meerigama", "මීරිගම", "மீரிகம", 7 },
                    { 24, "Minuwangoda", "මිනුවන්ගොඩ", "மினுவாங்கொட", 7 },
                    { 25, "Ja-Ela", "ජා-ඇල", "ஜா-எல", 8 },
                    { 26, "Katana", "කටාන", "கடானா", 8 },
                    { 27, "Negombo", "නිකඹො", "நிகம்போ", 8 },
                    { 28, "Bandaragama", "බණ්ඩාරගම", "பண்டாரகம", 9 },
                    { 29, "Bulathsinhala", "බුලත්සිංහල", "புலத்சிங்கள", 9 },
                    { 30, "Horana", "හොරණ", "ஹோரனா", 9 },
                    { 31, "Beruwala", "බේරුවල", "பேருவலா", 10 },
                    { 32, "Dodangoda", "දොඩංගොඩ", "தொடங்கோட", 10 },
                    { 33, "Kalutara", "කළුතර", "களுத்துறை", 10 },
                    { 34, "Panadura", "පානදුර", "பாணதுரை", 10 },
                    { 35, "Agalawatta", "අගලවත්ත", "அகலவத்த", 11 },
                    { 36, "Matugama", "මතුගම", "மதுகம", 11 },
                    { 37, "Palindanuwara", "පාලිඳනුවර", "பாலிந்தனுவர", 11 },
                    { 38, "Walallawita", "වලල්ලවිට", "வலல்லவிட", 11 },
                    { 39, "Udunuwara", "උඩුනුවර", "உடுநுவர", 12 },
                    { 40, "Yatinuwara", "යටිනුවර", "யடிநுவர", 12 },
                    { 41, "Ganga Ihala Korale", "ගංගා ඉහල කොරලේ", "கங்கா இஹலா கொரலே", 13 },
                    { 42, "Pasbage Korale", "පස්බාගේ කොරලේ", "பச்பகே கொரலே", 13 },
                    { 43, "Udapalatha", "උඩපාලත", "உடபாலத", 13 },
                    { 44, "Gangawata Korale", "ගංගාවට කොරලේ", "கங்காவட்ட கொரலே", 14 },
                    { 45, "Pathahewaheta", "පතහේවාහේට", "பதஹேவஹேட்ட", 14 },
                    { 46, "Akurana", "අකුරණ", "அகுரண", 15 },
                    { 47, "Galagedara", "ගලගෙදර", "கலகெதர", 15 },
                    { 48, "Harispattuwa", "හරිස්පත්තුව", "ஹரிஸ்பத்துவ", 15 },
                    { 49, "Hatharaliyadda", "හතරලියද්ද", "ஹதரலியதத", 15 },
                    { 50, "Poojapitiya", "පූජාපිටිය", "பூஜாபிடிய", 15 },
                    { 51, "Medadumbara", "මැදදුම්බර", "மெதடும்பர", 16 },
                    { 52, "Minipe", "මිනිපේ", "மினிபே", 16 },
                    { 53, "Ududumbara", "උඩුදුම්බර", "உடுடும்பர", 16 },
                    { 54, "Kundasale", "කුන්දසාලෙ", "குந்தசாலே", 17 },
                    { 55, "Panvila", "පන්විල", "பன்விலா", 17 },
                    { 56, "Pathadumbara", "පාතදුම්බර", "பாததும்பர", 17 },
                    { 57, "Dambulla", "දඹුල්ල", "தம்புள்ள", 18 },
                    { 58, "Galewela", "ගලේවල", "கலேவலா", 18 },
                    { 59, "Pallepola", "පල්ලෙපොල", "பலலெபொல", 18 },
                    { 60, "Matale", "මාතලේ", "மாத்தலே", 19 },
                    { 61, "Rattota", "රත්තොට", "ரதொட்ட", 19 },
                    { 62, "Ukuwela", "උකුවෙල", "உகுவல", 19 },
                    { 63, "Yatawatta", "යටවත්ත", "யடவட்ட", 19 },
                    { 64, "Ambanganga Korale", "අම්බන්ගංග කොරලේ", "அம்பங்கங்கா கொரலே", 20 },
                    { 65, "Naula", "නාවුල", "நௌலா", 20 },
                    { 66, "Laggala", "ලග්ගල", "லக்கலா", 21 },
                    { 67, "Wilgamuwa", "විල්ගමුව", "வில்கமுவ", 21 },
                    { 68, "Udahewaheta", "උඩහේවාහැට", "உடஹேவஹெட்ட", 22 },
                    { 69, "Ambagamuwa", "අම්බගමුව", "அம்பகமுவ", 23 },
                    { 70, "Hatton Tamil - I", "හැටන් දෙමළ - I", "ஹட்டன் தமிழ் - I", 23 },
                    { 71, "Hatton Tamil - II", "හැටන් දෙමළ - II", "ஹட்டன் தமிழ் - II", 23 },
                    { 72, "Hatton Tamil - III", "හැටන් දෙමළ - III", "ஹட்டன் தமிழ் - III", 23 },
                    { 73, "Kotmale", "කොත්මලේ", "கொத்மலே", 24 },
                    { 74, "Nuwara Eliya", "නුවර එළිය", "நுவரெலியா", 25 },
                    { 75, "Nuwara Eliya Tamil-1", "නුවරඑළිය දෙමළ - 1", "நுவரெலியா தமிழ் - 1", 25 },
                    { 76, "Nuwara Eliya Tamil-2", "නුවරඑළිය දෙමළ - 2", "நுவரெலியா தமிழ் - 2", 25 },
                    { 77, "Nuwara Eliya Tamil-3", "නුවරඑළිය දෙමළ - 3", "நுவரெலியா தமிழ் - 3", 25 },
                    { 78, "Walapane", "වලපනේ", "வலபனே", 26 }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "CensusNo", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "DivisionId", "Email", "LastModifiedTime", "LastModifiedUserId", "Name", "PhoneNo", "Type" },
                values: new object[,]
                {
                    { 1L, "GUNNEPANA", "03270", null, null, null, null, 56, null, null, null, "AL-AQSA MUS.V", null, (byte)3 },
                    { 2L, "MADAWALA BAZAAR", "03263", null, null, null, null, 56, null, null, null, "MADINA N S", null, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "Grade", "LanguageCode", "LastModifiedTime", "LastModifiedUserId", "Location", "SchoolId", "Section" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, (byte)1, "ta", null, null, null, 1L, "A" },
                    { 2L, null, null, null, null, (byte)2, "ta", null, null, null, 1L, "A" },
                    { 3L, null, null, null, null, (byte)3, "ta", null, null, null, 1L, "A" },
                    { 4L, null, null, null, null, (byte)4, "ta", null, null, null, 1L, "A" },
                    { 5L, null, null, null, null, (byte)5, "ta", null, null, null, 1L, "A" },
                    { 6L, null, null, null, null, (byte)6, "ta", null, null, null, 1L, "A" },
                    { 7L, null, null, null, null, (byte)7, "ta", null, null, null, 1L, "A" },
                    { 8L, null, null, null, null, (byte)8, "ta", null, null, null, 1L, "A" },
                    { 9L, null, null, null, null, (byte)9, "ta", null, null, null, 1L, "A" }
                });

            migrationBuilder.InsertData(
                table: "SchoolPrincipalEnrollments",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "No", "PrincipalId", "RemovedTime", "SchoolId", "Status", "Time" },
                values: new object[] { 1L, null, null, null, null, null, null, 123, 1L, null, 1L, (byte)1, null });

            migrationBuilder.InsertData(
                table: "SchoolStudentEnrollments",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "No", "SchoolId", "SchoolStudentEnrollmentRequestId", "Status", "StudentId", "Time" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, 622, 1L, null, (byte)2, 1L, null },
                    { 2L, null, null, null, null, null, null, 13336, 2L, null, (byte)4, 1L, null }
                });

            migrationBuilder.InsertData(
                table: "SchoolTeacherEnrollments",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "No", "RemovedTime", "SchoolId", "Status", "TeacherId", "Time" },
                values: new object[] { 1L, null, null, null, null, null, null, 123, null, 1L, (byte)5, 1L, null });

            migrationBuilder.InsertData(
                table: "ClassStudentEnrollments",
                columns: new[] { "Id", "AcademicYearYear", "ClassId", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "RemoveReason", "RemovedTime", "RollNo", "SchoolStudentEnrollmentId", "Status", "Time" },
                values: new object[] { 1L, 1999, 1L, null, null, null, null, null, null, null, null, null, 1L, (byte)4, null });

            migrationBuilder.InsertData(
                table: "ClassTeacherEnrollments",
                columns: new[] { "Id", "AcademicYearYear", "ClassId", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "RemovedReason", "RemovedTime", "SchoolTeacherEnrollmentId", "Status", "Time" },
                values: new object[] { 1L, 1998, 6L, null, null, null, null, null, null, null, null, 1L, (byte)5, null });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CreatedUserId",
                table: "Classes",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DeletedUserId",
                table: "Classes",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LanguageCode",
                table: "Classes",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LastModifiedUserId",
                table: "Classes",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentEnrollments_AcademicYearYear",
                table: "ClassStudentEnrollments",
                column: "AcademicYearYear");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentEnrollments_ClassId",
                table: "ClassStudentEnrollments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentEnrollments_CreatedUserId",
                table: "ClassStudentEnrollments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentEnrollments_DeletedUserId",
                table: "ClassStudentEnrollments",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentEnrollments_LastModifiedUserId",
                table: "ClassStudentEnrollments",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentEnrollments_SchoolStudentEnrollmentId",
                table: "ClassStudentEnrollments",
                column: "SchoolStudentEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherEnrollments_AcademicYearYear",
                table: "ClassTeacherEnrollments",
                column: "AcademicYearYear");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherEnrollments_ClassId",
                table: "ClassTeacherEnrollments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherEnrollments_CreatedUserId",
                table: "ClassTeacherEnrollments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherEnrollments_DeletedUserId",
                table: "ClassTeacherEnrollments",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherEnrollments_LastModifiedUserId",
                table: "ClassTeacherEnrollments",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherEnrollments_SchoolTeacherEnrollmentId",
                table: "ClassTeacherEnrollments",
                column: "SchoolTeacherEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ZoneId",
                table: "Divisions",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQualifications_CreatedUserId",
                table: "PersonQualifications",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQualifications_DeletedUserId",
                table: "PersonQualifications",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQualifications_LastModifiedUserId",
                table: "PersonQualifications",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQualifications_PersonId",
                table: "PersonQualifications",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQualifications_QualificationId",
                table: "PersonQualifications",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationships_ChildPersonId",
                table: "PersonRelationships",
                column: "ChildPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationships_CreatedUserId",
                table: "PersonRelationships",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationships_DeletedUserId",
                table: "PersonRelationships",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationships_LastModifiedUserId",
                table: "PersonRelationships",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRelationships_ParentPersonId",
                table: "PersonRelationships",
                column: "ParentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreatedUserId",
                table: "Persons",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DeletedUserId",
                table: "Persons",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LastModifiedUserId",
                table: "Persons",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_CreatedUserId",
                table: "Principals",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_DeletedUserId",
                table: "Principals",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_LastModifiedUserId",
                table: "Principals",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_PersonId",
                table: "Principals",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrincipalEnrollments_CreatedUserId",
                table: "SchoolPrincipalEnrollments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrincipalEnrollments_DeletedUserId",
                table: "SchoolPrincipalEnrollments",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrincipalEnrollments_LastModifiedUserId",
                table: "SchoolPrincipalEnrollments",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrincipalEnrollments_PrincipalId",
                table: "SchoolPrincipalEnrollments",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrincipalEnrollments_SchoolId",
                table: "SchoolPrincipalEnrollments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CensusNo",
                table: "Schools",
                column: "CensusNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CreatedUserId",
                table: "Schools",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_DeletedUserId",
                table: "Schools",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_DivisionId",
                table: "Schools",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_LastModifiedUserId",
                table: "Schools",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollmentRequests_AcademicYearYear",
                table: "SchoolStudentEnrollmentRequests",
                column: "AcademicYearYear");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollmentRequests_CreatedUserId",
                table: "SchoolStudentEnrollmentRequests",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollmentRequests_DeletedUserId",
                table: "SchoolStudentEnrollmentRequests",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollmentRequests_LastModifiedUserId",
                table: "SchoolStudentEnrollmentRequests",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollmentRequests_PersonId",
                table: "SchoolStudentEnrollmentRequests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollmentRequests_SchoolId",
                table: "SchoolStudentEnrollmentRequests",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollments_CreatedUserId",
                table: "SchoolStudentEnrollments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollments_DeletedUserId",
                table: "SchoolStudentEnrollments",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollments_LastModifiedUserId",
                table: "SchoolStudentEnrollments",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollments_SchoolId",
                table: "SchoolStudentEnrollments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollments_SchoolStudentEnrollmentRequestId",
                table: "SchoolStudentEnrollments",
                column: "SchoolStudentEnrollmentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolStudentEnrollments_StudentId",
                table: "SchoolStudentEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollmentRequests_CreatedUserId",
                table: "SchoolTeacherEnrollmentRequests",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollmentRequests_DeletedUserId",
                table: "SchoolTeacherEnrollmentRequests",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollmentRequests_LastModifiedUserId",
                table: "SchoolTeacherEnrollmentRequests",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollmentRequests_PersonId",
                table: "SchoolTeacherEnrollmentRequests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollmentRequests_SchoolId",
                table: "SchoolTeacherEnrollmentRequests",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollments_CreatedUserId",
                table: "SchoolTeacherEnrollments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollments_DeletedUserId",
                table: "SchoolTeacherEnrollments",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollments_LastModifiedUserId",
                table: "SchoolTeacherEnrollments",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollments_SchoolId",
                table: "SchoolTeacherEnrollments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacherEnrollments_TeacherId",
                table: "SchoolTeacherEnrollments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CreatedUserId",
                table: "Students",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeletedUserId",
                table: "Students",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LastModifiedUserId",
                table: "Students",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonId",
                table: "Students",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CreatedUserId",
                table: "Teachers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DeletedUserId",
                table: "Teachers",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_LastModifiedUserId",
                table: "Teachers",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PersonId",
                table: "Teachers",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedUserId",
                table: "Users",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedUserId",
                table: "Users",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastModifiedUserId",
                table: "Users",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_DistrictId",
                table: "Zones",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_CreatedUserId",
                table: "Classes",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_DeletedUserId",
                table: "Classes",
                column: "DeletedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_LastModifiedUserId",
                table: "Classes",
                column: "LastModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudentEnrollments_SchoolStudentEnrollments_SchoolStude~",
                table: "ClassStudentEnrollments",
                column: "SchoolStudentEnrollmentId",
                principalTable: "SchoolStudentEnrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudentEnrollments_Users_CreatedUserId",
                table: "ClassStudentEnrollments",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudentEnrollments_Users_DeletedUserId",
                table: "ClassStudentEnrollments",
                column: "DeletedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudentEnrollments_Users_LastModifiedUserId",
                table: "ClassStudentEnrollments",
                column: "LastModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacherEnrollments_SchoolTeacherEnrollments_SchoolTeach~",
                table: "ClassTeacherEnrollments",
                column: "SchoolTeacherEnrollmentId",
                principalTable: "SchoolTeacherEnrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacherEnrollments_Users_CreatedUserId",
                table: "ClassTeacherEnrollments",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacherEnrollments_Users_DeletedUserId",
                table: "ClassTeacherEnrollments",
                column: "DeletedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacherEnrollments_Users_LastModifiedUserId",
                table: "ClassTeacherEnrollments",
                column: "LastModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonQualifications_Persons_PersonId",
                table: "PersonQualifications",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonQualifications_Users_CreatedUserId",
                table: "PersonQualifications",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonQualifications_Users_DeletedUserId",
                table: "PersonQualifications",
                column: "DeletedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonQualifications_Users_LastModifiedUserId",
                table: "PersonQualifications",
                column: "LastModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRelationships_Persons_ChildPersonId",
                table: "PersonRelationships",
                column: "ChildPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRelationships_Persons_ParentPersonId",
                table: "PersonRelationships",
                column: "ParentPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRelationships_Users_CreatedUserId",
                table: "PersonRelationships",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRelationships_Users_DeletedUserId",
                table: "PersonRelationships",
                column: "DeletedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRelationships_Users_LastModifiedUserId",
                table: "PersonRelationships",
                column: "LastModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_CreatedUserId",
                table: "Persons",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_DeletedUserId",
                table: "Persons",
                column: "DeletedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_LastModifiedUserId",
                table: "Persons",
                column: "LastModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_CreatedUserId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_DeletedUserId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_LastModifiedUserId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "ClassStudentEnrollments");

            migrationBuilder.DropTable(
                name: "ClassTeacherEnrollments");

            migrationBuilder.DropTable(
                name: "PersonQualifications");

            migrationBuilder.DropTable(
                name: "PersonRelationships");

            migrationBuilder.DropTable(
                name: "SchoolPrincipalEnrollments");

            migrationBuilder.DropTable(
                name: "SchoolTeacherEnrollmentRequests");

            migrationBuilder.DropTable(
                name: "SchoolStudentEnrollments");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "SchoolTeacherEnrollments");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Principals");

            migrationBuilder.DropTable(
                name: "SchoolStudentEnrollmentRequests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
