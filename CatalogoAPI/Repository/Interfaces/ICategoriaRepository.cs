using CatalogoAPI.Models;

namespace CatalogoAPI.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
