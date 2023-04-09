using System.Linq.Expressions;

namespace CatalogoAPI.Repository.Implementations
{
    public interface IRepository<T> // An interface of anykind.
    {
        IQueryable<T> Get();
        T GetById(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
