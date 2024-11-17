using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class AddVerificationProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenExpiration",
                table: "Users",
                newName: "MobileNoTokenExpiration");

            migrationBuilder.RenameColumn(
                name: "MobileNoVerificationOtp",
                table: "Users",
                newName: "MobileNoToken");

            migrationBuilder.RenameColumn(
                name: "EmailVerificationToken",
                table: "Users",
                newName: "MobileNoOtp");

            migrationBuilder.RenameColumn(
                name: "EmailVerificationOtp",
                table: "Users",
                newName: "EmailToken");

            migrationBuilder.AddColumn<string>(
                name: "EmailOtp",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmailTokenExpiration",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EmailOtp", "EmailTokenExpiration", "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { null, null, true, true, "$argon2id$v=19$m=65536,t=3,p=1$tcl9ocISOsYfkqgMIqQnXQ$d4ztVC0dyoAucwgbN0mD5m848Re+AdusysEQLEyfrcA" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EmailOtp", "EmailTokenExpiration", "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { null, null, true, true, "$argon2id$v=19$m=65536,t=3,p=1$xiB1S+PHieb13g753cvtDQ$MHed+K3aT/PPvviNUDyOGGViwW7Il2d55dufa1+EZog" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EmailOtp", "EmailTokenExpiration", "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { null, null, true, true, "$argon2id$v=19$m=65536,t=3,p=1$Kv+nFQMP/F348Fp6wjX5Sg$r+a3bhOM/CCLPz8WyTNQoAI2LE8yBizL8oXKv6sHSR0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EmailOtp", "EmailTokenExpiration", "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { null, null, true, true, "$argon2id$v=19$m=65536,t=3,p=1$jgZQGTJHvsxQKAXuldYYOg$OHD46yxoXh8J9gdk9DJaVPsfpnFDts07JjEg/0ea9Wk" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EmailOtp", "EmailTokenExpiration", "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { null, null, true, true, "$argon2id$v=19$m=65536,t=3,p=1$vaL2QQ4Q3stYLnofHfECmQ$qo/UfSxXHjColNEaArFKjLta3d7ZHvfXO3qC//TbMvs" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailOtp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailTokenExpiration",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "MobileNoTokenExpiration",
                table: "Users",
                newName: "TokenExpiration");

            migrationBuilder.RenameColumn(
                name: "MobileNoToken",
                table: "Users",
                newName: "MobileNoVerificationOtp");

            migrationBuilder.RenameColumn(
                name: "MobileNoOtp",
                table: "Users",
                newName: "EmailVerificationToken");

            migrationBuilder.RenameColumn(
                name: "EmailToken",
                table: "Users",
                newName: "EmailVerificationOtp");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { false, false, "$argon2id$v=19$m=65536,t=3,p=1$BdMn4y1li+KDYxbzczV+Sg$vB9Tft640E6srr8v3b8qdkX7ZeHnf5QSQf+upDTNqs0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { false, false, "$argon2id$v=19$m=65536,t=3,p=1$NE+eHnEtrxZLqlQmGjcmZg$9Aih/daFPrcvPbQHJGoEFnkiAy0BAhHbHzKN9BUTD5g" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { false, false, "$argon2id$v=19$m=65536,t=3,p=1$HZkTjTUb05wTVat+lh4tog$4vSyUYofxYKA1qWvkL7Z0oAHnERDUe9+NptQeXgf4Wk" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { false, false, "$argon2id$v=19$m=65536,t=3,p=1$fjUj014f+AloXhHMtwPMKQ$6sg7i75zeK9mxEFxYRZfIkEFXYDuvqNfVySObnR15PY" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "IsEmailVerified", "IsMobileNoVerified", "Password" },
                values: new object[] { false, false, "$argon2id$v=19$m=65536,t=3,p=1$M0fvw6YR8wyCktdznyDW5g$UDhnCVUyI+dNwoS0pOFc94NO2GuYzHOiCt93qhQ+rXI" });
        }
    }
}
