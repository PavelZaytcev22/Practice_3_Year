using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий проданной медицины
    /// </summary>
    public class SaleMedicineRepository:IRepository<SaleMedicine>
    {
        private ApplicationContext db;
        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст БД </param>
        public SaleMedicineRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }
        /// <summary>
        /// Метод для добавления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>id продажи</returns>
        public async Task<int> AddAsync(SaleMedicine obj, CancellationToken token)
        {
            if (obj != null)
            {
                await db.SaleMedicine.AddAsync(obj, token);
                await db.SaveChangesAsync(token);
                return obj.SaleMedecineId;
            }
            return -1; 
        }
        /// <summary>
        /// Метод для удаления продажи из БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.SaleMedicine.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(SaleMedicine obj, CancellationToken token)
        {
            db.SaleMedicine.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<SaleMedicine>> GetAllAsync(CancellationToken token)
        {
            return await db.SaleMedicine.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<SaleMedicine> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.SaleMedicine.FirstOrDefaultAsync(u => u.SaleMedecineId == key, token);
        }

    }
}
