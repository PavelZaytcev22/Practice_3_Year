using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис для должности
    /// </summary>
    public class PostService:IService<Post>
    {
        IRepository<Post> repository;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public PostService(PostRepository repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления должности в БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>id должности</returns>
        public async Task<int> AddAsync(Post obj, CancellationToken token)
        {
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления должности из БД 
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// Метод для обновления должности в БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Post obj, CancellationToken token)
        {
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Post>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Post> GetByIdAsync(int key, CancellationToken token)
        {
            return await repository.GetByIdAsync(key, token);
        }
    }
}
