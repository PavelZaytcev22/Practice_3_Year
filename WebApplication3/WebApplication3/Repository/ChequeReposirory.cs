﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий для чека 
    /// </summary>
    public class ChequeReposirory:IRepository<Cheque>
    {
        private ApplicationContext db;//Через контекст для каждой сущьности нужно делать 
        /// <summary>
        /// Конструктор репозитория 
        /// </summary>
        /// <param name="dbContet">Контекст БД </param>
        public ChequeReposirory(ApplicationContext dbContet) 
        {
            db = dbContet;
        }

        /// <summary>
        /// Метод для добавления Чека в БД 
        /// </summary>
        /// <param name="obj">Объект для добавления</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id чека</returns>
        public async Task<int> AddAsync(Cheque obj, CancellationToken token ) 
        {
            await db.Cheque.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Cheque.Entry(obj).Property("CHEQUE_ID").CurrentValue;
        }

        /// <summary>
        /// Метод для  удаления чека в БД 
        /// </summary>
        /// <param name="obj">Объект для уддаления</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операций без возвращаемого значения</returns>
        public async Task DeleteAsync(int  key, CancellationToken token) 
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.Cheque.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления чека в БД 
        /// </summary>
        /// <param name="obj">Объект с новой информацией</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операций без возвращаемого значения</returns>
        public async Task UpdateAsync(Cheque obj, CancellationToken token)
        {
            db.Cheque.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Cheque>> GetAllAsync(CancellationToken token)
        {
            return await db.Cheque.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Cheque> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Cheque.FindAsync(new object[] { key }, token);
        }

    }
}
