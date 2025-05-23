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
        public async Task<int> AddAsync(Employer obj, CancellationToken token)
        {
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления работника из БД 
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">Объект работник</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Employer obj, CancellationToken token)
        {
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Employer>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Employer> GetByIdAsync(int key, CancellationToken token)
        {
            return await repository.GetByIdAsync(key, token);
        }
    }
}
