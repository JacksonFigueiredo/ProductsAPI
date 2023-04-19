using CatalogoAPI.Data;
using CatalogoAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Repository.Implementations
{
    public class RepositoryImplementation<T> : IRepository<T> where T : class
    {
        protected AppDbContext _dbContext;

        public RepositoryImplementation(AppDbContext context)
        {
            _dbContext = context;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity); 
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get()
        {
           return _dbContext.Set<T>().AsNoTracking();
        }

        public T GetById(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().SingleOrDefault(expression);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
