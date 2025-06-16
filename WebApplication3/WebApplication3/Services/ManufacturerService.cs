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
        private IRepository<Manufacturer> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public ManufacturerService(IRepository<Manufacturer> repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления производителя в БД 
        /// </summary>
        /// <param name="obj">Объект производителя</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>id производителя</returns>
        public async Task<int> AddAsync(Manufacturer obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления производителя из БД 
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id не может быть 0");
            }
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// Метод для обновления производителя
        /// </summary>
        /// <param name="obj">Объект производителя</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Manufacturer obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Manufacturer>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Manufacturer> GetByIdAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id не может быть 0");
            }
            return await repository.GetByIdAsync(key, token);
        }
    }
}
