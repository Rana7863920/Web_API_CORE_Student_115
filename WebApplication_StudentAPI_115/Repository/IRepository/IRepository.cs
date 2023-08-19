namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        T Find(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
