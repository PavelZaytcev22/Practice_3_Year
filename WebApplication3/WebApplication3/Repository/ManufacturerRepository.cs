using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст репозитория </param>
        public ManufacturerRepository(ApplicationContext dbContext) 
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>id производителя</returns>
        /// 
        public async Task<int> AddAsync(Manufacturer obj, CancellationToken token) 
        {
            if (obj != null) 
            {
                await db.Manufacturer.AddAsync(obj, token);
                return obj.ManufacturerId;
            }
            throw new ArgumentNullException();
        }
        /// <summary>
        ///  Метод для удаления поставщика из БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения </returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id больше 0");
            }
            await db.Manufacturer.Where(u => u.ManufacturerId== key).ExecuteDeleteAsync(token);
        }
        /// <summary>
        ///  Метод для обновлении поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Manufacturer obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            db.Manufacturer.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Manufacturer>> GetAllAsync(CancellationToken token)
        {
            return await db.Manufacturer.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Manufacturer> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Manufacturer.FirstOrDefaultAsync(u => u.ManufacturerId == key, token);
        }

    }
}
