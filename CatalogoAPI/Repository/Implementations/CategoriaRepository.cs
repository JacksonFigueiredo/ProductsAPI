using CatalogoAPI.Data;
using CatalogoAPI.Models;
using CatalogoAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Repository.Implementations
{
    public class CategoriaRepository : RepositoryImplementation<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
