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
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id продажи</returns>
        public async Task<int> Add(SaleMedicine obj, CancellationToken token)
        {
            await db.SaleMedicines.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.SaleMedicines.Entry(obj).Property("SALE_MEDICINE_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для удаления продажи из БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(SaleMedicine obj, CancellationToken token)
        {
            db.SaleMedicines.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(SaleMedicine obj, CancellationToken token)
        {
            db.SaleMedicines.Update(obj);
            await db.SaveChangesAsync(token);
        }

    }
}
