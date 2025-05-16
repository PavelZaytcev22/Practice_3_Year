

using WebApplication3.Interfaces;

namespace WebApplication3.Repository
{
    public class ClientRepository:IReposytory<Models.Client>
    {
        private Models.ClientContext db;//Через контекст для каждой сущьности нужно делать 
         Models.ApplicationContext db2; //Через контекст общий ????
        public void Add(Models.Client bb) 
        {
            db.Add(bb);
        }
        public bool Delete(Models.Client bb)
        {
            if (db.clients.Find(bb)!=null) {
                db.clients.Remove(bb);
                return true; 
            }
            return false;
        }
        public bool Update(Models.Client bb)
        {
            Models.Client buff = db.clients.Find(bb);
            if (buff!=null) 
            {
                db.clients.Remove(bb);
                db.clients.Add(bb);
                return true;
            }
            return false; 
        }
      
    }
}
