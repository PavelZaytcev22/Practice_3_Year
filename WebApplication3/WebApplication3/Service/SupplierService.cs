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
        IRepository<Supplier> repository;
        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public SupplierService(SupplierRepository repository) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления поставщика в БД
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id поставщика</returns>
        public async Task<int> Add(Supplier obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }


        /// <summary>
        /// Метод для удаления поставщика из БД
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Supplier obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления поставщика в БД
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Supplier obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }

    }
}
