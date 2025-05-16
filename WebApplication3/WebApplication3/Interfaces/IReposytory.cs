namespace WebApplication3.Interfaces
{
    public interface IReposytory<T> where T: class
    {
        //Видел, что некоторые реализациии с возвращением всей коллекции и элемента по id 
        public void Add(T obj);
        public bool Delete(T obj);
        public bool Update(T obj);
       
    }
}
