using CatalogoAPI.Data;
using CatalogoAPI.Models;
using CatalogoAPI.Repository.Interfaces;

namespace CatalogoAPI.Repository.Implementations
{
    public class ProdutoRepository : RepositoryImplementation<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Produto> GetProdutosPorPreco()
        {
            return Get().OrderBy(c => c.Preco).ToList();
        }
    }
}
