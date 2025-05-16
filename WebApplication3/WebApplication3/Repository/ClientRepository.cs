using Microsoft.EntityFrameworkCore;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class ClientRepository:IRepository<Client>
    {
        private ApplicationContext db;//Через контекст для каждой сущьности нужно делать 

        public ClientRepository(ApplicationContext database)
        {
            db = database;
        }
        public async Task Add(Client bb, CancellationToken tokken) 
        {
           await db.AddAsync(bb,tokken);
           await db.SaveChangesAsync(tokken);
        }
        public async Task Delete(Client bb, CancellationToken tokken)
        {
             await db.Clients.AddAsync(bb,tokken);
             await db.SaveChangesAsync(tokken);
        }
        public async Task Update(Client bb, CancellationToken tokken)
        {
            db.Clients.Update(bb);
            await db.SaveChangesAsync(tokken);
        }
      
    }
}
