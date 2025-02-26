using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteCadastros.Migrations
{
    /// <inheritdoc />
    public partial class AddRuaToProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Rua",
            table: "Produtos",
            nullable: true); // Permite valores nulos nos registros atuais
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Rua",
            table: "Produtos");
        }
    }
}
