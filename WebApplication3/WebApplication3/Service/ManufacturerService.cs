using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис для производителя
    /// </summary>
    public class ManufacturerService:IService<Manufacturer>
    {
        IRepository<Manufacturer> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public ManufacturerService(ManufacturerRepository repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления производителя в БД 
        /// </summary>
        /// <param name="obj">Объект производителя</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>id производителя</returns>
        public async Task<int> AddAsync(Manufacturer obj, CancellationToken token)
        {
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления производителя из БД 
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// Метод для обновления производителя
        /// </summary>
        /// <param name="obj">Объект производителя</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Manufacturer obj, CancellationToken token)
        {
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Manufacturer>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Manufacturer> GetByIdAsync(int key, CancellationToken token)
        {
            return await repository.GetByIdAsync(key, token);
        }
    }
}
