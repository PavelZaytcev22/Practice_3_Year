﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий  поставщика
    /// </summary>
    public class SupplierRepository:IRepository<Supplier>
    {
        private ApplicationContext db;
        /// <summary>
        /// Коструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст БД </param>
       
        public SupplierRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Id поставщика </returns>
        /// 
        public async Task<int> AddAsync(Supplier obj, CancellationToken token)
        {
            if (obj == null)
            {
               throw new ArgumentNullException();
            }
            await db.Supplier.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return obj.SupplierId;
        }

        /// <summary>
        /// Метод для удаления поставщика из БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id больше 0");
            }
            await db.Supplier.Where(u => u.SupplierId== key).ExecuteDeleteAsync(token);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(Supplier obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            db.Supplier.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken token)
        {
            return await db.Supplier.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<Supplier> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.Supplier.FirstOrDefaultAsync(u => u.SupplierId == key, token);
        }

    }
}
