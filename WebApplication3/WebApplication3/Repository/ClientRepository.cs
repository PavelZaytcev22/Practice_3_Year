using Microsoft.EntityFrameworkCore;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// репозиторий клиента 
    /// </summary>
    public class ClientRepository:IRepository<Client>
    {
        private ApplicationContext db;//Через контекст для каждой сущьности нужно делать 

        /// <summary>
        /// Конструктор репозитория 
        /// </summary>
        /// <param name="database"> Контекст БД</param>
        public ClientRepository(ApplicationContext database)
        {
            db = database;
        }

        /// <summary>
        /// Метод добавление в БД Клиента
        /// </summary>
        /// <param name="bb">Новый Клиент</param>
        /// <param name="token">Токкен для асинхронных операций </param>
        /// <returns>Возвращает id нового кдиента </returns>
        public async Task<int> Add(Client obj, CancellationToken token) 
        {
           await db.Clients.AddAsync(obj, token);
           await db.SaveChangesAsync(token);
           return (int)db.Clients.Entry(obj).Property("CLIENT_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="obj">Клиент под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Client obj, CancellationToken token)
        {
             db.Clients.Remove(obj);
             await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных в БД
        /// </summary>
        /// <param name="obj">Клиент под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Client obj, CancellationToken token)
        {
            db.Clients.Update(obj);
            await db.SaveChangesAsync(token);
        }
      
    }
}
