using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Service;
using WebApplication3.Models;
using WebApplication3.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для производителя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy ="DepartmentOnly")]
    public class ManufacturerController:ControllerBase
    {
        private IService<Manufacturer> service;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис контроллера для производителя</param>
        public ManufacturerController(IService<Manufacturer> service) 
        {
            this.service = service;
        }

        /// <summary>
        /// Метод для получения всех производителей из БД 
        /// </summary>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Коллекция производителей</returns>
        [HttpGet("getAll")]
        public async Task<IEnumerable<Manufacturer>> GetAllAsync(CancellationToken token)
        {
            return await service.GetAllAsync(token);
        }

        /// <summary>
        /// Метод для добавления производителя в БД
        /// </summary>
        /// <param name="obj">Объект производитель</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>id добавленного производителя</returns>
        /// <exception cref="ArgumentNullException">Объект был null</exception>
        [HttpPost("add")]
        public async Task<int> AddAsync([FromBody] Manufacturer obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return await service.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод для получения производителя по id из БД
        /// </summary>
        /// <param name="id">id производителя</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Объект производитель</returns>
        /// <exception cref="Exception">id находится вне границ [1-..]</exception>
        [HttpGet("getById")]
        public async Task<Manufacturer> GetByIdAsync(int id, CancellationToken token)
        {
            if (id <= 0)
            {
                throw new Exception("id всегда больше 0");
            }
            return await service.GetByIdAsync(id, token);
        }

        /// <summary>
        /// Метод для удаления производителя из БД
        /// </summary>
        /// <param name="id">id производителя</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция без взвращаемого значения</returns>
        /// <exception cref="Exception">id находится вне границ [1-..]</exception>
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
        /// Метод для обновления производителя в БД 
        /// </summary>
        /// <param name="obj">Объект производитель</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция без взвращаемого значения</returns>
        /// <exception cref="ArgumentNullException">Объект был null</exception>
        [HttpPut("update")]
        public async Task UpdateAsync(Manufacturer obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await service.UpdateAsync(obj, token);
        }
    }
}
