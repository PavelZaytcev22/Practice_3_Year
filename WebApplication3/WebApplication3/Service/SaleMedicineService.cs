using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис продажи
    /// </summary>
    public class SaleMedicineService:IService<SaleMedicine>
    {
        IRepository<SaleMedicine> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public SaleMedicineService(SaleMedicineRepository repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id продажи</returns>
        public async Task<int> AddAsync(SaleMedicine obj, CancellationToken token)
        {
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления продажи из БД 
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int  key, CancellationToken token)
        {
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// Метод для обновления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(SaleMedicine obj, CancellationToken token)
        {
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<SaleMedicine>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<SaleMedicine> GetByIdAsync(int key, CancellationToken token)
        {
            return await repository.GetByIdAsync(key, token);
        }
    }
}
