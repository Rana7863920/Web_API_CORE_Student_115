using System.Linq.Expressions;

namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        T Find(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);
        T FirstorDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
