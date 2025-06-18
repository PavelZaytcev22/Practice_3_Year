using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    /// <summary>
    /// Репозиторий для чека 
    /// </summary>
    public class ChequeRepository: IRepository<Cheque>
    {
        private ApplicationContext db;//Через контекст для каждой сущьности нужно делать 
        /// <summary>
        /// Конструктор репозитория 
        /// </summary>
        /// <param name="dbContet">Контекст БД </param>
        public ChequeRepository(ApplicationContext dbContet) 
        {
            db = dbContet;
        }

        /// <summary>
        /// Метод для добавления Чека в БД 
        /// </summary>
        /// <param name="obj">Объект для добавления</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>id чека</returns>
        public async Task<int> AddAsync(Cheque obj, CancellationToken token ) 
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await db.Cheque.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return obj.ChequeId;
        }

        /// <summary>
        /// Метод для  удаления чека в БД 
        /// </summary>
        /// <param name="obj">Объект для уддаления</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операций без возвращаемого значения</returns>
        public async Task DeleteAsync(int  key, CancellationToken token) 
        {
            if (key <= 0)
            {
                throw new Exception("id больше 0");
            }
            await db.Cheque.Where(u => u.ChequeId == key).ExecuteDeleteAsync(token);
            await db.SaveChangesAsync(token);
        }

        /// <summary>
        /// Метод для обновления чека в БД 
        /// </summary>
        /// <param name="obj">Объект с новой информацией</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операций без возвращаемого значения</returns>
        public async Task UpdateAsync(Cheque obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
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
            return await db.Cheque.FirstOrDefaultAsync(u => u.ChequeId== key, token);
        }

    }
}
