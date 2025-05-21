using WebApplication3.Interfaces;
using WebApplication3.Models; 

namespace WebApplication3.Service
{
    /// <summary>
    /// Класс сервис для клиента 
    /// </summary>
    public class ClientService: IService<Client>
    {
        private IRepository<Client> clientReposytory;

        /// <summary>
        /// Конструктор клиента 
        /// </summary>
        /// <param name="clientRep">Репозиторий клиента</param>
        public ClientService(IRepository<Client> clientRep) 
        {
            clientReposytory = clientRep;
        }
        /// <summary>
        /// Иетод для добавления клиента в БД 
        /// </summary>
        /// <param name="obj">Новый Клиент</param>
        /// <param name="tokken">Токкен для асинхронных операций</param>
        /// <returns>Возвращает Id Нового клиента</returns>
        public async Task<int> Add(Client obj, CancellationToken tokken) 
        {
            return await  clientReposytory.Add(obj,  tokken);
        }

        /// <summary>
        /// Метод для удаления клиента из БД
        /// </summary>
        /// <param name="obj">Удаляемый Клиент</param>
        /// <param name="tokken">Токкен для асинхронных операций</param>
        /// <returns>void</returns>
        public async Task Delete(Client obj, CancellationToken tokken)
        {
          await   clientReposytory.Delete(obj,  tokken);
        }
        /// <summary>
        /// Метод для обновления данных Клиента в БД 
        /// </summary>
        /// <param name="obj">класс с новыми данными клиента</param>
        /// <param name="tokken">Токкен для асинхронных операций</param>
        /// <returns>void </returns>
        public async Task Update(Client obj, CancellationToken tokken)
        {
            await clientReposytory.Update(obj, tokken);
        }
        

    }
}
