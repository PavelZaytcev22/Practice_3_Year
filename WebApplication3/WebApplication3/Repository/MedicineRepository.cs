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
        public async Task<int> Add(Medicine obj, CancellationToken token)
        {
            await db.Medicines.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Medicines.Entry(obj).Property("MEDICINE_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для удаления медикамента из БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Medicine obj, CancellationToken token)
        {
            db.Medicines.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления медикамента в БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Medicine obj, CancellationToken token)
        {
            db.Medicines.Update(obj);
            await db.SaveChangesAsync(token);
        }
    }
}
