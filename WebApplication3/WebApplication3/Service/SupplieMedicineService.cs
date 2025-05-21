using Microsoft.Identity.Client.Kerberos;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
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
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>id части поставки</returns>
        public async Task<int> Add(SupplieMedicine obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления части поставки из БД
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(SupplieMedicine obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления части поставки в БД
        /// </summary>
        /// <param name="obj">Объект часть поставки</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(SupplieMedicine obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }
    }
}
