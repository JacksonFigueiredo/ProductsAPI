using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categorias (Nome,ImagemUrl) values ('Bebidas','bebida.jpg')");
            migrationBuilder.Sql("insert into Categorias (Nome,ImagemUrl) values ('Congelados','Biscoitos.jpg')");
            migrationBuilder.Sql("insert into Categorias (Nome,ImagemUrl) values ('Biscoitos','Biscoitos.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Categorias");
        }
    }
}
