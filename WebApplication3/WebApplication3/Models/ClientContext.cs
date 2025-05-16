using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace WebApplication3.Models
{
    public class ClientContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ClientContext() : base() { }
        public Microsoft.EntityFrameworkCore.DbSet<Client> clients { get; set; }

        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//При создании будут эти свойства
        {
            modelBuilder.Entity<Client>().HasKey(u=>u.CLIENT_ID);//определили PK  
        }
    }
 }

