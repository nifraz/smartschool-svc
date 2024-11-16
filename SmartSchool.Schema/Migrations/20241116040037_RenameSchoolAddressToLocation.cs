using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class RenameSchoolAddressToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Schools",
                newName: "Location");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Schools",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$YUZxdRLjzR89fJVJ9Clq1g$KOuRwAyRuoL79jF9roL7v0aY/8cDQK+pqCuf6WyyOC0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$4CWmqtW6JsAohs2csG+o8A$pyaHDcgZ/T/vhn/gdYSkQDQugeebPFWdvCCyekOUYwY");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$35lgVAvbVdxeWXprj/2Tlg$7hUM/Clbp2eFxyBm6/KO+iollGcbMQ6CkHsrK+UJiv0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$WtZKooLTWX6Ju8J/q+dMBw$/X6kr6Qmo/WGL4GRtl9FRFr7dD5TgfEzH4RGi3lplQ4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$En5snC2JqAfe2dlFfCLqbg$Dv0TiU+k5JgvqwyJZeWu/oyhH2KcOPuEc3NF+zuAt9s");
        }
    }
}
