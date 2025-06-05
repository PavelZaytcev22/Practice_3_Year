using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Service;
using WebApplication3.Models;
using WebApplication3.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для поставщика
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "DepartmentOnly")]
    public class SupplierController : ControllerBase
    {
        private readonly IService<Supplier> service;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис контроллера для поставщика</param>
        public SupplierController(IService<Supplier> service)
        {
            this.service = service;
        }
        /// <summary>
        /// Метод для получения всех записей из БД 
        /// </summary>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает коллекцию поставщиков</returns>
        [HttpGet("getAll")]
        public async Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken token)
        {
            return await service.GetAllAsync(token);
        }
        /// <summary>
        /// Метод для добавления поставщика в БД 
        /// </summary>
        /// <param name="obj">Объект поставщик</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает id поставщика</returns>
        /// <exception cref="ArgumentNullException">Объект был null</exception>
        [HttpPost("add")]
        public async Task<int> AddAsync([FromBody] Supplier obj, CancellationToken token)
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
        /// <returns>Асинхронная операция, которая возвращает объект поставщик </returns>
        /// <exception cref="Exception">id не может быть меньше 0 </exception>
        [HttpGet("getById")]
        public async Task<Supplier> GetByIdAsync(int id, CancellationToken token)
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
        public async Task UpdateAsync(Supplier obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await service.UpdateAsync(obj, token);
        }

    }
}
