using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
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
        public async Task<int> AddAsync(Post obj, CancellationToken token)
        {
            await db.Post.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Post.Entry(obj).Property("POST_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для удаления должности из БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.Post.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления должности в БД 
        /// </summary>
        /// <param name="obj">Объект должность</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Post obj, CancellationToken token)
        {
            db.Post.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Post>> GetAllAsync(CancellationToken token)
        {
            return await db.Post.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Post> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Post.FindAsync(new object[] { key }, token);
        }
    }
}
