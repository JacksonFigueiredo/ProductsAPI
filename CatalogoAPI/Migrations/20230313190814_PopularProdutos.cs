using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PRODUTOS (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " + "VALUES " + "('Ruffles','Pacote 75g',6.00,'Ruffles.jpg',50,now(),3)");
            migrationBuilder.Sql("INSERT INTO PRODUTOS (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " + "VALUES " + "('Coca Cola','Lata 350ml',4.00,'coca.jpg',50,now(),1)");
            migrationBuilder.Sql("INSERT INTO PRODUTOS (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " + "VALUES " + "('Lasanha Sadia Frango','Lasanha Congelada 300g',9.00,'lasanha.jpg',50,now(),2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Produtos");
        }
    }
}
