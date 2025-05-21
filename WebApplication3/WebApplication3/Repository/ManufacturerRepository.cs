using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий поставщика
    /// </summary>
    public class ManufacturerRepository:IRepository<Manufacturer>
    {
        private ApplicationContext db;
        public ManufacturerRepository(ApplicationContext dbContext) 
        {
            db = dbContext;
        }
        /// <summary>
        /// Метод для добавления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id производителя</returns>
        public async Task<int> Add(Manufacturer obj, CancellationToken token) 
        {
            await db.Manufacturers.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Manufacturers.Entry(obj).Property("MUNUFACTURER_ID").CurrentValue;
        }
        /// <summary>
        ///  Метод для удаления поставщика из БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void </returns>
        public async Task Delete(Manufacturer obj, CancellationToken token)
        {
            db.Manufacturers.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        ///  Метод для обновлении поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Manufacturer obj, CancellationToken token)
        {
            db.Manufacturers.Update(obj);
            await db.SaveChangesAsync(token);
        }

    }
}
