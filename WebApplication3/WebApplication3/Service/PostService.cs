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
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id должности</returns>
        public async Task<int> Add(Post obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления должности из БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Post obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления должности в БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Post obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }

    }
}
