﻿using System.Data.Entity;
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
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
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
        /// 
        public async Task<int> AddAsync(Manufacturer obj, CancellationToken token) 
        {
            await db.Manufacturer.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Manufacturer.Entry(obj).Property("MUNUFACTURER_ID").CurrentValue;
        }
        /// <summary>
        ///  Метод для удаления поставщика из БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения </returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            var obj = await GetByIdAsync(key, token);
            if (obj != null)
            {
                db.Manufacturer.Remove(obj);
            }
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        ///  Метод для обновлении поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект потавщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Manufacturer obj, CancellationToken token)
        {
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
            return await db.Manufacturer.FindAsync(new object[] { key }, token);
        }

    }
}
