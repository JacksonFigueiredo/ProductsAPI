namespace CatalogoAPI.Repository.Interfaces
{
    public interface IUnitofWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        void Commit();
    }
}
