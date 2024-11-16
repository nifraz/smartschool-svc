using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schools",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$BdMn4y1li+KDYxbzczV+Sg$vB9Tft640E6srr8v3b8qdkX7ZeHnf5QSQf+upDTNqs0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$NE+eHnEtrxZLqlQmGjcmZg$9Aih/daFPrcvPbQHJGoEFnkiAy0BAhHbHzKN9BUTD5g");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$HZkTjTUb05wTVat+lh4tog$4vSyUYofxYKA1qWvkL7Z0oAHnERDUe9+NptQeXgf4Wk");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$fjUj014f+AloXhHMtwPMKQ$6sg7i75zeK9mxEFxYRZfIkEFXYDuvqNfVySObnR15PY");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$M0fvw6YR8wyCktdznyDW5g$UDhnCVUyI+dNwoS0pOFc94NO2GuYzHOiCt93qhQ+rXI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schools");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$ygMGUmFsaMd/P6kSy3X6vg$2Sy2oHakEZwPujo4Kbh0h+39BwMEhM9RJ5yB1/KZn+g");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$Z501/REMEJYVe8B93R0mOQ$1xP8Rx8YXaraTqaOByvLu7rId6VnalhGKhyoysSOAA0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$pX4Kr5QbaaVcyte2C2b6cg$QIttuJ0xaWrTK/3WXnL9mHl+lijOg9XznrcJUUP8I/Y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$H0xYsS1ZtI12+tTmpzHLdg$OFkcIkmLf+GmRRNgE9JGBV39qvc3dooLRqv13c3Hm/I");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$XrrGxyZezVDu1d2e1Ul7Qw$qQrIaSqlwhUKllek9ynF2lxbc8ToYH3eptCYcNt9Hug");
        }
    }
}
