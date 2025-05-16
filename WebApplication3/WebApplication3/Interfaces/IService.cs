namespace WebApplication3.Interfaces
{
    public interface IService<T> where T:class
    {
       Task  CreateAsync(T obj, CancellationToken tokken);
       Task  DeleteAsync(T obj, CancellationToken tokken);
       Task UpdateAsync(T obj,CancellationToken tokken);
    
    }
}
