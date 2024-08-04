using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.Schema.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueConstraintFromStudentsNic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_NicNo",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "NicNo",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NicNo",
                table: "Students",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NicNo",
                table: "Students",
                column: "NicNo",
                unique: true);
        }
    }
}
