using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Service;
using WebApplication3.Models;
using WebApplication3.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для клиента
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Director,Employer,Maneger,User")]
    public class ClientController : ControllerBase
    {
        private readonly IService<Client> clientService;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="clientService">Сервис контроллера</param>
        public ClientController(IService<Client> clientService)
        {
            this.clientService = clientService;
        }

        /// <summary>
        /// Метод получения всех клентов из БД
        /// </summary>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает коллекцию клиентов</returns>
        [HttpGet("getAll")]
        public async Task<IEnumerable<Client>> GetAllAsync(CancellationToken token)
        {
            return await clientService.GetAllAsync(token);
        }

        /// <summary>
        /// Метод добавления клиентов в БД
        /// </summary>
        /// <param name="obj">Объект клиент</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает id добавленного клиента</returns>
        [HttpPost("add")]
        public async Task<int> AddAsync([FromBody] Client obj, CancellationToken token)
        {
            if (obj == null) 
            {
                throw new ArgumentNullException();
            }
            return await clientService.AddAsync(obj, token);
        }

        /// <summary>
        /// Метод получения клиента по id из БД
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция, которая возвращает объект клиент</returns>    
        [HttpGet("getById")]
        public async Task<Client> GetByIdAsync(int id, CancellationToken token) 
        {
            if (id<=0)
            {
                throw new Exception("id всегда больше 0");
            }
            return await clientService.GetByIdAsync(id , token);
        }

        /// <summary>
        /// Метод удаления клиента из БД
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция </returns>
        [HttpDelete("deleteById")]
        public async Task DeleteAsync(int id, CancellationToken token)
        {
            if (id <= 0)
            {
                throw new Exception("id всегда больше 0");
            }
            await clientService.DeleteAsync(id, token);
        }

        /// <summary>
        /// Метод обновления клиента в БД
        /// </summary>
        /// <param name="obj">Объект клиент</param>
        /// <param name="token">Токен http запросов</param>
        /// <returns>Асинхронная операция</returns>
        [HttpPut("update")]
        public async Task UpdateAsync(Client obj, CancellationToken token)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await clientService.UpdateAsync(obj , token);
        }

    }
}
