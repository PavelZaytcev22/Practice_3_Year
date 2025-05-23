﻿using Microsoft.EntityFrameworkCore;
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
        /// <param name="bb">Новый Клиент</param>
        /// <param name="token">Токкен для асинхронных операций </param>
        /// <returns>Асинхронная операция возвращает id нового кдиента </returns>
        public async Task<int> AddAsync(Client obj, CancellationToken token)
        {
            var i = await db.Client.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Client.Entry(obj).Property("CLIENT_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для удаления записей из БД 
        /// </summary>
        /// <param name="obj">Клиент под удаление</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key,token);
            if (obj!=null)
            {
                db.Client.Remove(obj);
            }
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
            return await db.Client.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Client> GetByIdAsync(int key , CancellationToken token) 
        {
            return await db.Client.FindAsync(new object[]{ key },token);
        }
    }

}
