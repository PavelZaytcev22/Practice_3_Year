using WebApplication3.Interfaces;
using WebApplication3.Models; 

namespace WebApplication3.Service
{
    public class ClientService: IService<Client>
    {
        private IRepository<Client> clientReposytory;

        public ClientService(IRepository<Client> clientRep) 
        {
            clientReposytory = clientRep;
        }

        public async Task CreateAsync(Client obj, CancellationToken tokken) 
        {
            await  clientReposytory.Add(obj,  tokken);
        }
        public async Task DeleteAsync(Client obj, CancellationToken tokken)
        {
          await   clientReposytory.Delete(obj,  tokken);
        }

        public async Task UpdateAsync(Client obj, CancellationToken tokken)
        {
            await clientReposytory.Update(obj, tokken);
        }
        

    }
}
