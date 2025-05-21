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
        public async Task<int> Add(Cheque obj, CancellationToken token ) 
        {
            await db.Cheques.AddAsync(obj, token);
            await db.SaveChangesAsync(token);
            return (int)db.Cheques.Entry(obj).Property("CHEQUE_ID").CurrentValue;
        }
        /// <summary>
        /// Метод для  удаления чека в БД 
        /// </summary>
        /// <param name="obj">Объект для уддаления</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Cheque obj, CancellationToken token) 
        {
            db.Cheques.Remove(obj);
            await db.SaveChangesAsync(token);
        }
        /// <summary>
        /// Метод для обновления чека в БД 
        /// </summary>
        /// <param name="obj">Объект с новой информацией</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Cheque obj, CancellationToken token)
        {
            db.Cheques.Update(obj);
            await db.SaveChangesAsync(token);
        }

    }
}
