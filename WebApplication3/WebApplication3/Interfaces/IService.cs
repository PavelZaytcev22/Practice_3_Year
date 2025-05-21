namespace WebApplication3.Interfaces
{
    public interface IService<T> where T:class
    {
       Task<int>  Add(T obj, CancellationToken tokken);
       Task  Delete(T obj, CancellationToken tokken);
       Task  Update(T obj,CancellationToken tokken);
    
    }
}
