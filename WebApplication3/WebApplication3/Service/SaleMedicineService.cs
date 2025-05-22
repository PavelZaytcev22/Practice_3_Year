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
        public async Task<int> Add(SaleMedicine obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления продажи из БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(SaleMedicine obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(SaleMedicine obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }

    }
}
