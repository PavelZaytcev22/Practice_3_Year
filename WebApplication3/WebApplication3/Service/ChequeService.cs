using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис для чека
    /// </summary>
    public class ChequeService:IService<Cheque>
    {
        private IRepository<Cheque> repository;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="reposirory">Репозиторий для сервиса</param>
        public ChequeService(ChequeReposirory reposirory) 
        {
            this.repository = reposirory;
        }

        /// <summary>
        /// Метод для добавления чека в БД
        /// </summary>
        /// <param name="obj">Объект чек</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>id чека</returns>
        public async Task<int> AddAsync(Cheque obj, CancellationToken token) 
        {
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для добавления чека в БД
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken token) 
        {
            await repository.DeleteAsync(key,token);
        }

        /// <summary>
        /// Метод для добавления чека в БД
        /// </summary>
        /// <param name="obj">Объект чек</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Cheque obj, CancellationToken token) 
        {
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Cheque>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Cheque> GetByIdAsync(int key, CancellationToken token)
        {
            return await repository.GetByIdAsync(key, token);
        }

    }
}
