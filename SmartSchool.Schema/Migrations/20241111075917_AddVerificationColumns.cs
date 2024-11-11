using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class AddVerificationColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerificationToken",
                table: "Users",
                newName: "MobileNoVerificationOtp");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmailOtpExpiration",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailVerificationOtp",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmailVerificationToken",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "MobileNoOtpExpiration",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EmailOtpExpiration", "EmailVerificationOtp", "EmailVerificationToken", "MobileNoOtpExpiration", "Password" },
                values: new object[] { null, null, null, null, "$argon2id$v=19$m=65536,t=3,p=1$YUZxdRLjzR89fJVJ9Clq1g$KOuRwAyRuoL79jF9roL7v0aY/8cDQK+pqCuf6WyyOC0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EmailOtpExpiration", "EmailVerificationOtp", "EmailVerificationToken", "MobileNoOtpExpiration", "Password" },
                values: new object[] { null, null, null, null, "$argon2id$v=19$m=65536,t=3,p=1$4CWmqtW6JsAohs2csG+o8A$pyaHDcgZ/T/vhn/gdYSkQDQugeebPFWdvCCyekOUYwY" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EmailOtpExpiration", "EmailVerificationOtp", "EmailVerificationToken", "MobileNoOtpExpiration", "Password" },
                values: new object[] { null, null, null, null, "$argon2id$v=19$m=65536,t=3,p=1$35lgVAvbVdxeWXprj/2Tlg$7hUM/Clbp2eFxyBm6/KO+iollGcbMQ6CkHsrK+UJiv0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EmailOtpExpiration", "EmailVerificationOtp", "EmailVerificationToken", "MobileNoOtpExpiration", "Password" },
                values: new object[] { null, null, null, null, "$argon2id$v=19$m=65536,t=3,p=1$WtZKooLTWX6Ju8J/q+dMBw$/X6kr6Qmo/WGL4GRtl9FRFr7dD5TgfEzH4RGi3lplQ4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EmailOtpExpiration", "EmailVerificationOtp", "EmailVerificationToken", "MobileNoOtpExpiration", "Password" },
                values: new object[] { null, null, null, null, "$argon2id$v=19$m=65536,t=3,p=1$En5snC2JqAfe2dlFfCLqbg$Dv0TiU+k5JgvqwyJZeWu/oyhH2KcOPuEc3NF+zuAt9s" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailOtpExpiration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailVerificationOtp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailVerificationToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MobileNoOtpExpiration",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "MobileNoVerificationOtp",
                table: "Users",
                newName: "VerificationToken");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$5XmJt8r7c+AB+NhgiO5FXQ$mqz93DapH1ZACWh3mCCqgEZnvKQx1P0eedFQS00Ckag");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$0HbcriGji0Gwm9IVo9bUzg$UIRREQQlDzF3j4x24q5jxj8gro67VrsxfvznR4raDL8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$k4EE7wLSXFjpV1iHTVktsA$c6btyak2P2jaBUogU34pfmuSBaP4p2G3IlYCgRqEmAI");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$sIDXFDUUF1/T631G/L9VTw$2JvBUBNoa/e/DQ+JuOA8bijOKmNPOZzjIE4X7Y7G4q8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$+cAN1eEgw8nngdKmJCOxEQ$QsZ4XhlytTjYWEX7ZgqYMRVP1acsEoW8TMbv45oKOhg");
        }
    }
}
