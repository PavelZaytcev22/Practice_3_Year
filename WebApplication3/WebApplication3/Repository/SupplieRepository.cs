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
        public async Task<int> Add(Supplie obj, CancellationToken token)
        {
            await db.Supplies.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Supplies.Entry(obj).Property("SUPPLIE_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для удаления поставки из БД 
        /// </summary>
        /// <param name="obj">Объект поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Supplie obj, CancellationToken token)
        {
            db.Supplies.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления поставки в БД 
        /// </summary>
        /// <param name="obj">Объект поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Supplie obj, CancellationToken token)
        {
            db.Supplies.Update(obj);
            await db.SaveChangesAsync(token);
        }
    }
}
