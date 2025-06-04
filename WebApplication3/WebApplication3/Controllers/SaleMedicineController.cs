using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Service;
using WebApplication3.Models;
using WebApplication3.Interfaces;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для части продажи
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SaleMedicineController:ControllerBase
    {
        private readonly IService<SaleMedicine> service;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис контроллера для продажи</param>
        public SaleMedicineController(IService<SaleMedicine> service)
        {
            this.service = service;
        }
        /// <summary>
        /// Метод для получения всех записей из БД 
        /// </summary>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает коллекцию продаж</returns>
        [HttpGet("getAll")]
        public async Task<IEnumerable<SaleMedicine>> GetAllAsync(CancellationToken token)
        {
            return await service.GetAllAsync(token);
        }
        /// <summary>
        /// Метод для добавления продажи в БД 
        /// </summary>
        /// <param name="obj">Объект продажа</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает id продажи</returns>
        /// <exception cref="ArgumentNullException">Объект был null</exception>
        [HttpPost("add")]
        public async Task<int> AddAsync([FromBody] SaleMedicine obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return await service.AddAsync(obj, token);
        }
        /// <summary>
        /// Метод для получения чека из Бд по id 
        /// </summary>
        /// <param name="id">id искомой записи</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает объект продажа</returns>
        /// <exception cref="Exception">id не может быть меньше 0 </exception>
        [HttpGet("getById")]
        public async Task<SaleMedicine> GetByIdAsync(int id, CancellationToken token)
        {
            if (id <= 0)
            {
                throw new Exception("id всегда больше 0");
            }
            return await service.GetByIdAsync(id, token);
        }
        /// <summary>
        /// Метод для удаления записи из БД по id
        /// </summary>
        /// <param name="id">id удаляемой записи</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция</returns>
        /// <exception cref="Exception">id не может быть меньше 0</exception>
        [HttpDelete("deleteById")]
        public async Task DeleteAsync(int id, CancellationToken token)
        {
            if (id <= 0)
            {
                throw new Exception("id всегда больше 0");
            }
            await service.DeleteAsync(id, token);
        }
        /// <summary>
        /// Мето для добавления обновления записи в БД 
        /// </summary>
        /// <param name="obj">Объект для изменения</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция</returns>
        /// <exception cref="ArgumentNullException">Объект null</exception>
        [HttpPut("update")]
        public async Task UpdateAsync(SaleMedicine obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await service.UpdateAsync(obj, token);
        }
    }
}
