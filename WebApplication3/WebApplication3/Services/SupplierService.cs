using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    /// <summary>
    /// Сервис поставщика
    /// </summary>
    public class SupplierService: IService<Supplier>
    {
        private IRepository<Supplier> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public SupplierService(IRepository<Supplier> repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления поставщика в БД
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>id поставщика</returns>
        public async Task<int> AddAsync(Supplier obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return await repository.AddAsync(obj, token);
        }


        /// <summary>
        /// Метод для удаления поставщика из БД
        /// </summary>
        /// <param name="key">PK атрибута сущьности</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key , CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id не может быть 0");
            }
            await repository.DeleteAsync(key, token);
        }

        /// <summary>
        /// Метод для обновления поставщика в БД
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>void</returns>
        public async Task UpdateAsync(Supplier obj, CancellationToken token)
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
        public async Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Supplier> GetByIdAsync(int key, CancellationToken token)
        {
            if (key <= 0)
            {
                throw new Exception("id не может быть 0");
            }
            return await repository.GetByIdAsync(key, token);
        }
    }
}
