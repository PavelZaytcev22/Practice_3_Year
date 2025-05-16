namespace WebApplication3.Interfaces
{
    public interface IService<T> where T:class
    {
       void  CreateAsync(T obj);
       bool  DeleteAsync(T obj);
       bool UpdateAsync(T obj);
    
    }
}
