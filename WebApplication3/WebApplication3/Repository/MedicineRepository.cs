using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий медикамента
    /// </summary>
    public class MedicineRepository:IRepository<Medicine>
    {
        private ApplicationContext db;
        public MedicineRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }
        /// <summary>
        /// Метод для добавления медикамента в БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id медикамента</returns>
        public async Task<int> AddAsync(Medicine obj, CancellationToken token)
        {
            if (obj != null) 
            {
                await db.Medicine.AddAsync(obj, token);
                await db.SaveChangesAsync(token);
                return obj.MedicineId;
            }
            return -1;           
        }

        /// <summary>
        /// Метод для удаления медикамента из БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.Medicine.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления медикамента в БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Medicine obj, CancellationToken token)
        {
            db.Medicine.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Medicine>> GetAllAsync(CancellationToken token)
        {
            return await db.Medicine.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Medicine> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Medicine.FirstOrDefaultAsync(u => u.MedicineId == key, token);
        }
    }
}
