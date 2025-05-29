using Microsoft.Identity.Client.Kerberos;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис частипоставки
    /// </summary>
    public class SupplieMedicineService:IService<SupplieMedicine>
    {
        IRepository<SupplieMedicine> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public SupplieMedicineService(SupplieMedicineRepository repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавление части поставки в БД
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>id части поставки</returns>
        public async Task<int> AddAsync(SupplieMedicine obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return await repository.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для удаления части поставки из БД
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен hhtp запросов</param>
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
        /// Метод для обновления части поставки в БД
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(SupplieMedicine obj, CancellationToken token)
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
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<SupplieMedicine>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<SupplieMedicine> GetByIdAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id не может быть 0");
            }
            return await repository.GetByIdAsync(key, token);
        }
    }
}
