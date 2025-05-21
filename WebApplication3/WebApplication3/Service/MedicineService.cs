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
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task<int> Add(Medicine obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления медикамента из БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Medicine obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления медикамента в БД 
        /// </summary>
        /// <param name="obj">Объект медикамент</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Medicine obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }

    }
}
