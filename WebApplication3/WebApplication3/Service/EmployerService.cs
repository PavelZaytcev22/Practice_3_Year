using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис работник
    /// </summary>
    public class EmployerService:IService<Employer>
    {
        private IRepository<Employer> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="reposirory">Репозиторий для сервиса</param>
        public EmployerService(EmployerRepository reposirory)
        {
            this.repository = reposirory;
        }

        /// <summary>
        /// Метод для добавления работника в БД
        /// </summary>
        /// <param name="obj">Объект работник</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id работника </returns>
        public async Task<int> Add(Employer obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления работника из БД 
        /// </summary>
        /// <param name="obj">Объект работник</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Employer obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">Объект работник</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Employer obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }
    }
}
