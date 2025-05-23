using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class EmployerRepository:IRepository<Employer>
    {
        /// <summary>
        /// Контекст БД 
        /// </summary>
        private ApplicationContext db;//Через контекст для каждой сущьности нужно делать 

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="dbContext"> Контекст БД </param>
        public EmployerRepository(ApplicationContext dbContext) 
        {
            db = dbContext;
        }

        /// <summary>
        /// Добавление работника в БД 
        /// </summary>
        /// <param name="obj">Объект работник</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id работника</returns>
        public async Task<int> AddAsync(Employer obj, CancellationToken token)
        {
            await db.Employer.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Employer.Entry(obj).Property("EMPLOYER_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="key">Работник под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.Employer.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных в БД
        /// </summary>
        /// <param name="obj">Работник под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Employer obj, CancellationToken token)
        {
            db.Employer.Update(obj);
            await db.SaveChangesAsync(token);
        }


        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Employer>> GetAllAsync(CancellationToken token)
        {
            return await db.Employer.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Employer> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Employer.FindAsync(new object[] { key }, token);
        }

    }
}
