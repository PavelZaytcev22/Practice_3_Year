using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models
{    
    /// <summary>
    /// Контекст базы данных со всеми сущностями и настройками их ключей 
    /// <summary>
    public class ApplicationContext:DbContext
    {
        #region Коллекции БД 
        public DbSet<Client> Client { get; set; } = null!;
        public DbSet<Cheque> Cheque { get; set; } = null!;
        public DbSet<Employer> Employer { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturer { get; set; } = null!;
        public DbSet<Medicine> Medicine { get; set; } = null!;
        public DbSet<Post> Post { get; set; } =null!;
        public DbSet<SaleMedicine> SaleMedicine { get; set; } = null!;
        public DbSet<Supplie> Supplie { get; set; } = null!;
        public DbSet<SupplieMedicine> SupplieMedicine { get; set; } = null!;
        public DbSet<Supplier> Supplier { get; set; } = null!;
        #endregion

        /// <summary>
        /// Конструктор БД 
        /// </summary>
        /// <param name="options"> Класс с настройками для БД </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {            
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        
        /// <summary>
        /// Метод для настройки модели БД через ModelBilder 
        /// </summary>
        /// <param name="modelBuilder">Класс для конфигурации БД </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Для сущности Client 
            modelBuilder.Entity<Client>().HasKey(u => u.ClientId);//PK
            modelBuilder.Entity<Client>().Property(p => p.ClientId).ValueGeneratedOnAdd().IsRequired();//Автоинкремент и not null
            #endregion

            #region Для сущности Post 
            modelBuilder.Entity<Post>().HasKey(u => u.PostId);
            modelBuilder.Entity<Post>().Property(p => p.PostId).ValueGeneratedOnAdd();//Автоинкремент 
            #endregion

            #region Для сущности Manufacturer 
            modelBuilder.Entity<Manufacturer>().HasKey(u=>u.ManufacturerId);
            modelBuilder.Entity<Manufacturer>().Property(p => p.ManufacturerId).ValueGeneratedOnAdd();//Автоинкремент 
            #endregion

            #region Для сущности Supplier 
            modelBuilder.Entity<Supplier>().HasKey(u=>u.SupplierId);
            modelBuilder.Entity<Supplier>().Property(p => p.SupplierId).ValueGeneratedOnAdd();//Автоинкремент 
            #endregion

            #region Для сущности Employer 
            modelBuilder.Entity<Employer>().HasKey(u=>u.EmployerId);
            modelBuilder.Entity<Employer>().Property(p => p.EmployerId).ValueGeneratedOnAdd();//Автоинкремент и not null
            modelBuilder.Entity<Employer>()
                .HasOne(u => u.Post)
                .WithMany()
                .HasForeignKey(u=>u.PostId);
            #endregion

            #region Для сущности Medicine 
            modelBuilder.Entity<Medicine>().HasKey(u => u.MedicineId);
            modelBuilder.Entity<Medicine>().Property(p => p.MedicineId).ValueGeneratedOnAdd();//Автоинкремент и not null
            modelBuilder.Entity<Medicine>()
                .HasOne(u => u.Manufacturer)
                .WithMany()
                .HasForeignKey(u => u.ManufacturerId);//Создание внешнего ключа 
            #endregion

            #region Для сущности Supplie 
            modelBuilder.Entity<Supplie>().HasKey(u => u.SupplieId);
            modelBuilder.Entity<Supplie>().Property(p => p.SupplieId).ValueGeneratedOnAdd();//Автоинкремент 
            modelBuilder.Entity<Supplie>()
                .HasOne(u => u.Supplier)
                .WithMany()
                .HasForeignKey(u => u.SupplierId);
            #endregion

            #region Для сущности SupplieMed
            modelBuilder.Entity<SupplieMedicine>().HasKey(u => u.SuplieMedicineId);
            modelBuilder.Entity<SupplieMedicine>().Property(p => p.SuplieMedicineId).ValueGeneratedOnAdd();//Автоинкремент
            modelBuilder.Entity<SupplieMedicine>()
                .HasOne(u=>u.Supplie)
                .WithMany()
                .HasForeignKey(u=>u.SuplieId);
            modelBuilder.Entity<SupplieMedicine>()
               .HasOne(u => u.Medicine)
               .WithMany()
               .HasForeignKey(u => u.MedicineId);
            #endregion

            #region Для сущности SaleMedicine
            modelBuilder.Entity<SaleMedicine>().HasKey(u => u.SaleMedecineId);
            modelBuilder.Entity<SaleMedicine>().Property(p => p.SaleMedecineId).ValueGeneratedOnAdd();//Автоинкремент
            modelBuilder.Entity<SaleMedicine>()
                .HasOne(u => u.Cheque)
                .WithMany()
                .HasForeignKey(u => u.ChequeId);

            modelBuilder.Entity<SaleMedicine>()
               .HasOne(u => u.Medicine)
               .WithMany()
               .HasForeignKey(u => u.MedicineId);
            #endregion

            #region Для сущности Cheque 
            modelBuilder.Entity<Cheque>().HasKey(u => u.ChequeId);
           modelBuilder.Entity<Cheque>().Property(p => p.ChequeId).ValueGeneratedOnAdd();//Автоинкремент
            modelBuilder.Entity<Cheque>()
                .HasOne(u => u.Client)
                .WithMany()
                .HasForeignKey(u => u.ClientId);//Создание внешнего ключа 

            modelBuilder.Entity<Cheque>()
               .HasOne(u => u.Employer)
               .WithMany()
               .HasForeignKey(u => u.EmployerId);//Создание внешнего ключа 
            #endregion

            //Преобразование названий таблиц  и полей таблиц в UpperCase
            foreach (var i in modelBuilder.Model.GetEntityTypes())
            {
                i.SetTableName(Functions.PascalCaseToUpperCase(i.GetTableName()));
                foreach (var j in i.GetProperties())
                {
                    j.SetColumnName(Functions.PascalCaseToUpperCase(j.GetColumnName()));
                }
            }

        }

    }
}
