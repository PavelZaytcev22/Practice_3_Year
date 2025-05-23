namespace WebApplication3.Interfaces
{
    public interface IRepository<T> where T: class
    {
        //Видел, что некоторые реализациии с возвращением всей коллекции и элемента по id 
        Task<int> AddAsync(T obj, CancellationToken token);
        Task DeleteAsync(int key, CancellationToken token);
        Task UpdateAsync(T obj, CancellationToken token);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
        Task<T> GetByIdAsync(int id, CancellationToken token);
    }
}
