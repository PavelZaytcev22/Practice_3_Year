using WebApplication3.Interfaces;
using WebApplication3.Models; 

namespace WebApplication3.Service
{
    /// <summary>
    /// Класс сервис для клиента 
    /// </summary>
    public class ClientService: IService<Client>
    {
        private IRepository<Client> repository;

        /// <summary>
        /// Конструктор клиента 
        /// </summary>
        /// <param name="clientRep">Репозиторий клиента</param>
        public ClientService(IRepository<Client> clientRep) 
        {
            repository = clientRep;
        }
        /// <summary>
        /// Иетод для добавления клиента в БД 
        /// </summary>
        /// <param name="obj">Новый Клиент</param>
        /// <param name="tokken">Токен http запросов</param>
        /// <returns>Возвращает Id Нового клиента</returns>
        public async Task<int> AddAsync(Client obj, CancellationToken tokken) 
        {
            if (obj==null) 
            {
                throw new ArgumentNullException();
            }
            return await  repository.AddAsync(obj,  tokken);
        }

        /// <summary>
        /// Метод удаления клиента из БД
        /// </summary>
        /// <param name="key">PK атрибута сущьности/param>
        /// <param name="tokken">Токен http запросов</param>
        /// <returns>void</returns>
        public async Task DeleteAsync(int key, CancellationToken tokken)
        {
            if (key<=0)
            {
                throw new Exception("id не может быть 0");
            }
          await   repository.DeleteAsync(key,  tokken);
        }
        /// <summary>
        /// Метод для обновления данных Клиента в БД 
        /// </summary>
        /// <param name="obj">класс с новыми данными клиента</param>
        /// <param name="tokken">Токен http запросов</param>
        /// <returns>void </returns>
        public async Task UpdateAsync(Client obj, CancellationToken tokken)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            await repository.UpdateAsync(obj, tokken);
        }

        /// <summary>
        /// Метод получения всех записей сущности
        /// </summary>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронныя операция, которая возвращает коллекцию записей сущности</returns>
        public async Task<IEnumerable<Client>> GetAllAsync(CancellationToken token)
        {
           return await repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод получения записи из сущьности по PK
        /// </summary>
        /// <param name="key">PK сущности</param>
        /// <param name="token">Токен для асинхронных операций</param>
        /// <returns>Асинхронныя операция, которая возвращает атрибут сущности</returns>
        public async Task<Client> GetByIdAsync(int key, CancellationToken token) 
        {
            if (key <= 0)
            {
                throw new Exception("id не может быть 0");
            }
            return await repository.GetByIdAsync(key,token);
        }

    }
}
