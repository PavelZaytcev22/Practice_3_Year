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
        public async Task<int> Add(SupplieMedicine obj, CancellationToken token)
        {
            await db.SupplieMedicines.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.SupplieMedicines.Entry(obj).Property("SUPPL_MEDICINE_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для удаления части поставки из БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void </returns>
        public async Task Delete(SupplieMedicine obj, CancellationToken token)
        {
            db.SupplieMedicines.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления части поставки в БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(SupplieMedicine obj, CancellationToken token)
        {
            db.SupplieMedicines.Update(obj);
            await db.SaveChangesAsync(token);
        }

    }
}
