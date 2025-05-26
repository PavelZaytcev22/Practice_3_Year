using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий поставки
    /// </summary>
    public class SupplieRepository:IRepository<Supplie>
    {
        private ApplicationContext db;

        public SupplieRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления поставки в БД 
        /// </summary>
        /// <param name="obj">Объект поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Id поставки</returns>
        public async Task<int> AddAsync(Supplie obj, CancellationToken token)
        {
            if (obj!=null)
            {
                await db.Supplie.AddAsync(obj, token);
                await db.SaveChangesAsync(token);
                return obj.SupplieId;
            }
            return -1; 
        }

        /// <summary>
        /// Метод для удаления поставки из БД 
        /// </summary>
        /// <param name="obj">Объект поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.Supplie.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления поставки в БД 
        /// </summary>
        /// <param name="obj">Объект поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Supplie obj, CancellationToken token)
        {
            db.Supplie.Update(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Supplie>> GetAllAsync(CancellationToken token)
        {
            return await db.Supplie.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Supplie> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Supplie.FirstOrDefaultAsync(u=>u.SupplieId ==key,token);
        }

    }
}
