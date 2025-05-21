namespace WebApplication3.Interfaces
{
    public interface IRepository<T> where T: class
    {
        //Видел, что некоторые реализациии с возвращением всей коллекции и элемента по id 
        public  Task<int> Add(T obj, CancellationToken token);
        public Task Delete(T obj, CancellationToken token);
        public Task Update(T obj, CancellationToken token);
       
    }
}
