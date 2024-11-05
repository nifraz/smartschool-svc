using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class AddImageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Persons",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Image",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Persons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$KBM0pAozr1Q/cASpXz51qA$5jV2ObiXrl2U1CkOOyS01hauTz14pvEBo+9cqv4xxkk");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$aanJKrXoq2i0xIgDnSIpzw$BbxxBeXdDDPTKcJkmEPwdW4La9Qx8/my0Nnq0DwuMe4");
        }
    }
}
