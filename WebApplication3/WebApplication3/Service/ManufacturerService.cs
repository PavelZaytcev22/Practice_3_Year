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
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id производителя</returns>
        public async Task<int> Add(Manufacturer obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления производителя из БД 
        /// </summary>
        /// <param name="obj">Объект производителя</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Manufacturer obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления производителя
        /// </summary>
        /// <param name="obj">Объект производителя</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Manufacturer obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }
    }
}
