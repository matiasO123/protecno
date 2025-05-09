using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Protecno.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_rolID",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Rols");

            migrationBuilder.RenameColumn(
                name: "rolID",
                table: "Usuarios",
                newName: "rolId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_rolID",
                table: "Usuarios",
                newName: "IX_Usuarios_rolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rols",
                table: "Rols",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    fechaNac = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dni = table.Column<int>(type: "INTEGER", nullable: false),
                    mail = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    tipo = table.Column<string>(type: "TEXT", nullable: true),
                    inicioActividad = table.Column<DateTime>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true),
                    usuarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    proveedor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_personas_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    marca = table.Column<string>(type: "TEXT", nullable: false),
                    modelo = table.Column<string>(type: "TEXT", nullable: false),
                    aniofabricacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false),
                    clienteid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_personas_clienteid",
                        column: x => x.clienteid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repuestos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    marca = table.Column<string>(type: "TEXT", nullable: false),
                    modelo = table.Column<string>(type: "TEXT", nullable: false),
                    proveedorid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_repuestos_personas_proveedorid",
                        column: x => x.proveedorid,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reparacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fechaAlta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fechaFinalizacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estadoReparacion = table.Column<string>(type: "TEXT", nullable: false),
                    precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    productoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reparacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reparacions_productos_productoID",
                        column: x => x.productoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    reparacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventos_reparacions_reparacionId",
                        column: x => x.reparacionId,
                        principalTable: "reparacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    importe = table.Column<decimal>(type: "TEXT", nullable: false),
                    medioPago = table.Column<string>(type: "TEXT", nullable: false),
                    ReparacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pago_reparacions_ReparacionId",
                        column: x => x.ReparacionId,
                        principalTable: "reparacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reparacionRepuestos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReparacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    RepuestoId = table.Column<string>(type: "TEXT", nullable: true),
                    precio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reparacionRepuestos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_reparacionRepuestos_reparacions_ReparacionId",
                        column: x => x.ReparacionId,
                        principalTable: "reparacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reparacionRepuestos_repuestos_RepuestoId",
                        column: x => x.RepuestoId,
                        principalTable: "repuestos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagoId = table.Column<int>(type: "INTEGER", nullable: false),
                    detalle = table.Column<string>(type: "TEXT", nullable: false),
                    nroFactura = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_pago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventos_reparacionId",
                table: "eventos",
                column: "reparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_factura_PagoId",
                table: "factura",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_pago_ReparacionId",
                table: "pago",
                column: "ReparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_usuarioId",
                table: "personas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_clienteid",
                table: "productos",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_reparacionRepuestos_ReparacionId",
                table: "reparacionRepuestos",
                column: "ReparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_reparacionRepuestos_RepuestoId",
                table: "reparacionRepuestos",
                column: "RepuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_reparacions_productoID",
                table: "reparacions",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_repuestos_proveedorid",
                table: "repuestos",
                column: "proveedorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rols_rolId",
                table: "Usuarios",
                column: "rolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rols_rolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "reparacionRepuestos");

            migrationBuilder.DropTable(
                name: "pago");

            migrationBuilder.DropTable(
                name: "repuestos");

            migrationBuilder.DropTable(
                name: "reparacions");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rols",
                table: "Rols");

            migrationBuilder.RenameTable(
                name: "Rols",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "rolId",
                table: "Usuarios",
                newName: "rolID");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_rolId",
                table: "Usuarios",
                newName: "IX_Usuarios_rolID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_rolID",
                table: "Usuarios",
                column: "rolID",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
