namespace WebApplication3.Interfaces
{
    public interface IService<T> where T:class
    {
       Task<int> AddAsync(T obj, CancellationToken tokken);
       Task DeleteAsync(int key, CancellationToken tokken);
       Task UpdateAsync(T obj,CancellationToken tokken);
       Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
       Task<T> GetByIdAsync(int id, CancellationToken token);
    }
}
