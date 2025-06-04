
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.IdentityModel.Tokens;
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
        /// <param name="token">Токен http запросов </param>
        /// <returns>Асинхронная операция возвращает id нового кдиента </returns>
        public async Task<int> AddAsync(Client obj, CancellationToken token)
        {
            if (obj != null)
            {
                await db.Client.AddAsync(obj, token);
                await db.SaveChangesAsync(token);
                return obj.ClientId;//Поле автоинкремент(в modelBilder), после сохранения инициализируется
            }
            throw new ArgumentNullException();      
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="key">Ключ клиента под удаление</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id больше 0");
            }
            await  db.Client.Where(u => u.ClientId == key).ExecuteDeleteAsync(token);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления данных в БД
        /// </summary>
        /// <param name="obj">Клиент под удаление</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Client obj, CancellationToken token)
        {
            if (obj==null)
            {
                throw new ArgumentNullException();
            }
            db.Client.Update(obj);
            await db.SaveChangesAsync(token);
            //Другой вариант 
            /*  await db.Client.Where(u => u.ClientId == obj.ClientId).ExecuteUpdateAsync(
                  s => s.SetProperty(u => u.PhoneNumber, obj.PhoneNumber)
                  .SetProperty(u => u.Discount, obj.Discount),
                  token);*/
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Client>> GetAllAsync(CancellationToken token)
        {
            return await db.Client.ToArrayAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Client> GetByIdAsync(int key , CancellationToken token) 
        {
            if (key<=0)
            {
                throw new Exception("id больше 0");
            }
            return await db.Client.FirstOrDefaultAsync(u=>u.ClientId==key, token);//Проверить
           // return await db.Client.FindAsync(new object[]{ key },token);
        }
    }

}
