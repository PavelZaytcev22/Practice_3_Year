using WebApplication3.Interfaces;

namespace WebApplication3.Service
{
    public class ClientServices: Interfaces.IService<Models.Client>
    {
        private IReposytory<Models.Client> clientReposytory;

        public ClientServices(IReposytory<Models.Client> clientRep) 
        {
            clientReposytory = clientRep;
        }

        public  void CreateAsync(Models.Client obj) 
        {
            clientReposytory.Add(obj);
        }
        public bool DeleteAsync(Models.Client obj)
        {
            return clientReposytory.Delete(obj);
        }

        public bool UpdateAsync(Models.Client obj)
        {
            return clientReposytory.Update(obj);
        }
        

    }
}
