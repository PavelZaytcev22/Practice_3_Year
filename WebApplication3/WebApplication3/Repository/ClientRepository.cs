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
        /// <param name="tokken">Токкен для асинхронных операций </param>
        /// <returns>Возвращает id нового кдиента </returns>
        public async Task<int> Add(Client bb, CancellationToken tokken) 
        {
           await db.Clients.AddAsync(bb,tokken);
           await db.SaveChangesAsync(tokken);
           return (int)db.Clients.Entry(bb).Property("CLIENT_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="bb">Клиент под удаление</param>
        /// <param name="tokken">Токкен для асинхронных операций</param>
        /// <returns></returns>
        public async Task Delete(Client bb, CancellationToken tokken)
        {
             await db.Clients.AddAsync(bb,tokken);
             await db.SaveChangesAsync(tokken);
        }

        /// <summary>
        /// Метод для обновления данных в БД
        /// </summary>
        /// <param name="bb">Клиент под удаление</param>
        /// <param name="tokken">Токкен для асинхронных операций</param>
        /// <returns></returns>
        public async Task Update(Client bb, CancellationToken tokken)
        {
            db.Clients.Update(bb);
            await db.SaveChangesAsync(tokken);
        }
      
    }
}
