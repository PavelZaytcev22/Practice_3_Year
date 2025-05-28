using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис медикамента
    /// </summary>
    public class MedicineService:IService<Medicine>
    {
        IRepository<Medicine> repository;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public MedicineService(MedicineRepository repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления медикамента в БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task<int> AddAsync(Medicine obj, CancellationToken token)
        {
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления медикамента из БД 
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken token)
        {
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// Метод для обновления медикамента в БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Medicine obj, CancellationToken token)
        {
            await repository.UpdateAsync(obj, token);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Medicine>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Medicine> GetByIdAsync(int key, CancellationToken token)
        {
            return await repository.GetByIdAsync(key, token);
        }
    }
}
