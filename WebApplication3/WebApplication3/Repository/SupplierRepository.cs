using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий  поставщика
    /// </summary>
    public class SupplierRepository:IRepository<Supplier>
    {
        private ApplicationContext db;
        /// <summary>
        /// Коструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст БД </param>
       
        public SupplierRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Id поставщика </returns>
        /// 
        public async Task<int> Add(Supplier obj, CancellationToken token)
        {
            await db.Suppliers.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Suppliers.Entry(obj).Property("SUPPLIER_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления поставщика из БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Supplier obj, CancellationToken token)
        {
            db.Suppliers.Remove(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Supplier obj, CancellationToken token)
        {
            db.Suppliers.Update(obj);
            await db.SaveChangesAsync(token);
        }
    }
}
