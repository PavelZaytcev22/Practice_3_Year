using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Service;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    /// <summary>
    /// Контроллер для клиента
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService clientService;
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="clientService">Сервис контроллера</param>
        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        /// <summary>
        /// Метод получения всех клентов из БД
        /// </summary>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAllAsync(CancellationToken token)
        {
            return await clientService.GetAllAsync(token);
        }

        /// <summary>
        /// Метод добавления клиентов в БД
        /// </summary>
        /// <param name="obj">Объект клиент</param>
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddAsync(Client obj, CancellationToken token)
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
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns></returns>
        [HttpGet("{id}")]
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
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
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
        /// <param name="token">Токен hhtp запросов</param>
        /// <returns></returns>
        [HttpPut]
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
