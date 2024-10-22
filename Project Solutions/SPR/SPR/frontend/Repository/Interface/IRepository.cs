using System.Net;

namespace frontend.Repository.Interface
{
    public interface IRepository<T, X>
    where T : class
    {
        Task<List<T>> Get();
        Task<T> Get(X id);
        HttpStatusCode Post(T entity);
        HttpStatusCode Put(T entity);
        HttpStatusCode Delete(X id);
    }
}
