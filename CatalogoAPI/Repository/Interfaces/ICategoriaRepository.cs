using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAPI.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos();
    }
}
