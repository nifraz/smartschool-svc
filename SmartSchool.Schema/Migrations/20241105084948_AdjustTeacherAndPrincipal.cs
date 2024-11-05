using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTeacherAndPrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PensionDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PensionDate",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "ServiceGrade",
                table: "Principals");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNo",
                table: "Teachers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Sex",
                value: (byte)9);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "BcNo", "CreatedTime", "CreatedUserId", "DateOfBirth", "DeletedTime", "DeletedUserId", "Email", "FullName", "Image", "LastModifiedTime", "LastModifiedUserId", "MobileNo", "NicNo", "Nickname", "PassportNo", "Sex", "ShortName" },
                values: new object[,]
                {
                    { 3L, "61/3, Napana, Gunnepana", "123", null, null, new DateOnly(1962, 3, 19), null, null, "ayesha@live.com", "Ayesha Rauf", null, null, null, "0776791138", null, "Ayesha", null, (byte)2, "Ayesha" },
                    { 4L, "61/3, Napana, Gunnepana", "123", null, null, new DateOnly(1952, 3, 19), null, null, "navahz@gmail.com", "Mohamad Navahz", null, null, null, "0756825831", null, "Navahz", null, (byte)1, "Navahz" },
                    { 5L, "123, Madawala Bazaar", "123", null, null, new DateOnly(1980, 3, 19), null, null, "nisry@gmail.com", "Nisry Ahamed", null, null, null, "0770808306", null, "Nisry", null, (byte)1, "Nisry" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "PersonId" },
                values: new object[] { 1L, null, null, null, null, null, null, 2L });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$cdehqfYCPbQHX63fQxqfLg$oawuxtLX+cMbF3UO12iHKGkA58NMxqVW99+CzXgqeg8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$FvkIIOHXUonmhWzs1gRQUA$l2g+RU5jJLF9yUvwd2zGrINaLkfAW7M/dVdFUuD1Syk");

            migrationBuilder.InsertData(
                table: "Principals",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "DeletedTime", "DeletedUserId", "LastModifiedTime", "LastModifiedUserId", "PersonId" },
                values: new object[] { 1L, null, null, null, null, null, null, 5L });

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
                    { 3L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$rsaOyWHslAmxr7NmdxzqMA$QkUFzXL4FX8RnREKQctq3oSt9hzCh+pY3QcUJEIIzCE", 3L, null, null },
                    { 4L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$Ryzh2cFeHEmCRk401lLMyw$szcKUI2q4KwcydevKttOKynzlBmCrDOfDJQx2ePycYs", 4L, null, null },
                    { 5L, null, null, null, null, false, false, null, null, "$argon2id$v=19$m=65536,t=3,p=1$gLJqm1WvwX42yjs/SvjJbw$NrCgkpAvMIN3qq0C6grvOpvrUbahm2JUaljc+gIhiP8", 5L, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Principals",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "RegistrationNo",
                keyValue: null,
                column: "RegistrationNo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNo",
                table: "Teachers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "PensionDate",
                table: "Teachers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PensionDate",
                table: "Principals",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "Principals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ServiceGrade",
                table: "Principals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Sex",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$MzUOTm00bDbnvjk9pbTtsA$B8K/VHuayMVU/QnawaB6SnyzyD1EowtQgctxTTnpTBU");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$lUBhTdelGKc3o9K42siNPw$+rX6Uz2VC78Iqe19gTfyi6RlfFQR4JUvtIojThnNf+4");
        }
    }
}
