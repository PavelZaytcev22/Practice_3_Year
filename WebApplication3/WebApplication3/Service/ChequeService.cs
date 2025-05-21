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
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id чека</returns>
        public async Task<int> Add(Cheque obj, CancellationToken token) 
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для добавления чека в БД
        /// </summary>
        /// <param name="obj">Объект чек</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Cheque obj, CancellationToken token) 
        {
            await repository.Delete(obj,token);
        }

        /// <summary>
        /// Метод для добавления чека в БД
        /// </summary>
        /// <param name="obj">Объект чек</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Cheque obj, CancellationToken token) 
        {
            await repository.Update(obj, token);
        }

    }
}
