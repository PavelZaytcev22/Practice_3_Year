using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий поставленной медицины
    /// </summary>
    public class SupplieMedicineRepository:IRepository<SupplieMedicine>
    {
        private ApplicationContext db;

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст БД </param>
        public SupplieMedicineRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления части поставки в БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Id части поставки</returns>
        public async Task<int> AddAsync(SupplieMedicine obj, CancellationToken token)
        {
            await db.SupplieMedicine.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.SupplieMedicine.Entry(obj).Property("SUPPL_MEDICINE_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления части поставки из БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения </returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.SupplieMedicine.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления части поставки в БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(SupplieMedicine obj, CancellationToken token)
        {
            db.SupplieMedicine.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<SupplieMedicine>> GetAllAsync(CancellationToken token)
        {
            return await db.SupplieMedicine.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<SupplieMedicine> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.SupplieMedicine.FindAsync(new object[] { key }, token);
        }

    }
}
