using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)//При создании будут эти свойства
        {
            modelBuilder.Entity<Client>().HasKey(u => u.CLIENT_ID);//определили PK  
        }
    }
}
