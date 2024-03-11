using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMedica.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class mudandoBancoOutraVez : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBMedico_TBAtividade",
                table: "TBAtividade");

            migrationBuilder.DropIndex(
                name: "IX_TBAtividade_MedicoID",
                table: "TBAtividade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TBAtividade_MedicoID",
                table: "TBAtividade",
                column: "MedicoID");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMedico_TBAtividade",
                table: "TBAtividade",
                column: "MedicoID",
                principalTable: "TBMedico",
                principalColumn: "Id");
        }
    }
}
