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
        public async Task<int> Add(Employer obj, CancellationToken token)
        {
            await db.Emploers.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Emploers.Entry(obj).Property("EMPLOYER_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="obj">Работник под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Employer obj, CancellationToken token)
        {
            db.Emploers.Remove(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных в БД
        /// </summary>
        /// <param name="obj">Работник под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Employer obj, CancellationToken token)
        {
            db.Emploers.Update(obj);
            await db.SaveChangesAsync(token);
        }

    }
}
