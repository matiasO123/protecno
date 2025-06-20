using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Protecno.Migrations
{
    /// <inheritdoc />
    public partial class tercermigrac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reparacionRepuestos_repuestos_RepuestoId",
                table: "reparacionRepuestos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "repuestos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "RepuestoId",
                table: "reparacionRepuestos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reparacionRepuestos_repuestos_RepuestoId",
                table: "reparacionRepuestos",
                column: "RepuestoId",
                principalTable: "repuestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reparacionRepuestos_repuestos_RepuestoId",
                table: "reparacionRepuestos");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "repuestos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "RepuestoId",
                table: "reparacionRepuestos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_reparacionRepuestos_repuestos_RepuestoId",
                table: "reparacionRepuestos",
                column: "RepuestoId",
                principalTable: "repuestos",
                principalColumn: "Id");
        }
    }
}
