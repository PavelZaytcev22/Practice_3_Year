using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий должности
    /// </summary>
    public class PostRepository:IRepository<Post>
    {
        private ApplicationContext db;

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        public PostRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления должности в БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id должности</returns>
        public async Task<int> Add(Post obj, CancellationToken token)
        {
            await db.Posts.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Posts.Entry(obj).Property("POST_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для удаления должности из БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Post obj, CancellationToken token)
        {
            db.Posts.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления должности в БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Post obj, CancellationToken token)
        {
            db.Posts.Update(obj);
            await db.SaveChangesAsync(token);
        }
    }
}
