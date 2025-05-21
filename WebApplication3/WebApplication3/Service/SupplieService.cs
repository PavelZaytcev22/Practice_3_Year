using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    public class SupplieService : IService<Supplie>
    {
        IRepository<Supplie> repository;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="repository">Репозиторий для сервиса</param>
        public SupplieService(SupplieRepository repository ) 
        {
            this.repository = repository;
        }

        /// <summary>
        /// Метод для добавления поставки в БД 
        /// </summary>
        /// <param name="obj">Объект поставка</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Id поставки</returns>
        public async Task<int> Add(Supplie obj, CancellationToken token)
        {
            return await repository.Add(obj, token);
        }

        /// <summary>
        /// Метод для удаления поставки из БД 
        /// </summary>
        /// <param name="obj">Объект поставка</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Supplie obj, CancellationToken token)
        {
            await repository.Delete(obj, token);
        }

        /// <summary>
        /// Метод для обновления поставки в БД 
        /// </summary>
        /// <param name="obj">Объект поставка</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Update(Supplie  obj, CancellationToken token)
        {
            await repository.Update(obj, token);
        }



    }
}
