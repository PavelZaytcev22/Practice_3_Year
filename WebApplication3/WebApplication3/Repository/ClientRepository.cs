
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// репозиторий клиента 
    /// </summary>
    public class ClientRepository : IRepository<Client>
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
        /// <param name="obj">Новый Клиент</param>
        /// <param name="token">Токкен для асинхронных операций </param>
        /// <returns>Асинхронная операция возвращает id нового кдиента </returns>
        public async Task<int> AddAsync(Client obj, CancellationToken token)
        {
            if (obj != null)
            {
                await db.Client.AddAsync(obj, token);
                await db.SaveChangesAsync(token);
                return obj.ClientId;//Поле автоинкремент(в modelBilder), после сохранения инициализируется
            }
            return -1;
            //throw new Exception("Объект null");       
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="obj">Клиент под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
           await  db.Client.Where(u => u.ClientId == key).ExecuteDeleteAsync(token);
           await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных в БД
        /// </summary>
        /// <param name="obj">Клиент под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Client obj, CancellationToken token)
        {
            db.Client.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Client>> GetAllAsync(CancellationToken token)
        {
            return await db.Client.ToArrayAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Client> GetByIdAsync(int key , CancellationToken token) 
        {
            return await db.Client.FirstOrDefaultAsync(u=>u.ClientId==key, token);
           // return await db.Client.FindAsync(new object[]{ key },token);
        }
    }

}
