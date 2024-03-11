using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMedica.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class mudandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBMedico_TBAtividade",
                columns: table => new
                {
                    AtividadesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMedico_TBAtividade", x => new { x.AtividadesId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_TBMedico_TBAtividade_TBAtividade_AtividadesId",
                        column: x => x.AtividadesId,
                        principalTable: "TBAtividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBMedico_TBAtividade_TBMedico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "TBMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBMedico_TBAtividade_MedicosId",
                table: "TBMedico_TBAtividade",
                column: "MedicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBMedico_TBAtividade");
        }
    }
}
