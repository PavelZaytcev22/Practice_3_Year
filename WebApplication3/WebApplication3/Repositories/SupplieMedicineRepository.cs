﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий поставленной медицины
    /// </summary>
    public class SupplieMedicineRepository:IRepository<SupplieMedicine>
    {
        private ApplicationContext db;

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="dbContext">Контекст БД </param>
        public SupplieMedicineRepository(ApplicationContext dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Метод для добавления части поставки в БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Id части поставки</returns>
        public async Task<int> AddAsync(SupplieMedicine obj, CancellationToken token)
        {
            if (obj==null)
            {
                throw new ArgumentNullException();
            }
            await db.SupplieMedicine.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return obj.SupplieMedicineId;            
        }

        /// <summary>
        /// Метод для удаления части поставки из БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения </returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id больше 0");
            }
            await db.SupplieMedicine.Where(u => u.SupplieMedicineId== key).ExecuteDeleteAsync(token);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления части поставки в БД 
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task UpdateAsync(SupplieMedicine obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            db.SupplieMedicine.Update(obj);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод получения всех атрибутов из БД 
        /// </summary>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция с возвратом коллекции</returns>
        public async Task<IEnumerable<SupplieMedicine>> GetAllAsync(CancellationToken token)
        {
            return await db.SupplieMedicine.ToListAsync(token);
        }

        /// <summary>
        /// Метод получения записи по PK
        /// </summary>
        /// <param name="key">PK для сущности</param>
        /// <param name="token">Токкен для асинхронных операций</param>
        /// <returns>Асинхронная операция без возвращаемого значения</returns>
        public async Task<SupplieMedicine> GetByIdAsync(int key, CancellationToken token)
        {
            return await db.SupplieMedicine.FirstOrDefaultAsync(u => u.SupplieMedicineId == key, token);
        }

    }
}
