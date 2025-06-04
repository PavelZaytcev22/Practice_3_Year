using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Service;
using WebApplication3.Models;
using WebApplication3.Interfaces;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для чека
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ChequeController : ControllerBase
    {
        private readonly IService<Cheque> service;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис контроллера для чека</param>
        public ChequeController(IService<Cheque> service)
        {
            this.service = service;
        }
        /// <summary>
        /// Метод для получения всех записей из БД 
        /// </summary>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает коллекцию чеков</returns>
        [HttpGet("getAll")]
        public async Task<IEnumerable<Cheque>> GetAllAsync(CancellationToken token)
        {
            return await service.GetAllAsync(token);
        }
        /// <summary>
        /// Метод для добавления чека в БД 
        /// </summary>
        /// <param name="obj">Объект чек</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает id чека</returns>
        /// <exception cref="ArgumentNullException">Объект был null</exception>
        [HttpPost("add")]
        public async Task<int> AddAsync([FromBody] Cheque obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return await service.AddAsync(obj, token);
        }
        /// <summary>
        /// Метод для получения чека из БД по id 
        /// </summary>
        /// <param name="id">id искомой записи</param>
        /// <param name="token">Токен для http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает объект чек</returns>
        /// <exception cref="Exception">id не может быть меньше 0 </exception>
        [HttpGet("getById")]
        public async Task<Cheque> GetByIdAsync(int id, CancellationToken token)
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
        public async Task UpdateAsync(Cheque obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await service.UpdateAsync(obj, token);
        }
    }
}
