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
            modelBuilder.Entity<Client>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11).HasAnnotation("RegularExpression",new Regex("^(7|8)(d{10})$"));
            modelBuilder.Entity<Client>().Property(p => p.Discount).IsRequired().HasAnnotation("Range",new Range(0,100));
            #endregion

            #region Для сущности Post 
            modelBuilder.Entity<Post>().HasKey(u=>u.PostId);
            #endregion

            #region Для сущности Manufacturer 
            modelBuilder.Entity<Manufacturer>().HasKey(u=>u.ManufacturerId);
            #endregion

            #region Для сущности Suplier 
            modelBuilder.Entity<Supplier>().HasKey(u=>u.SupplierId);
            #endregion

            #region Для сущности Employer 
            modelBuilder.Entity<Employer>().HasKey(u=>u.EmployerId);
            modelBuilder.Entity<Employer>()
                .HasOne(u => u.Post)
                .WithMany()
                .HasForeignKey(u=>u.PostId)
                .IsRequired();
            #endregion

            #region Для сущности Medicine 
            modelBuilder.Entity<Medicine>().HasKey(u => u.MedicineId);

            modelBuilder.Entity<Medicine>()
                .HasOne(u => u.Manufacturer)
                .WithMany()
                .HasForeignKey(u => u.ManufacturerId)
                .IsRequired();//Создание внешнего ключа 
            #endregion

            #region Для сущности Supplie 
            modelBuilder.Entity<Supplie>().HasKey(u => u.SupplieId);
            modelBuilder.Entity<Supplie>()
                .HasOne(u => u.Supplier)
                .WithMany()
                .HasForeignKey(u => u.SupplierId)
                .IsRequired();
            #endregion

            #region Для сущности Supplie_Med
            modelBuilder.Entity<SupplieMedicine>().HasKey(u => u.SuplieMedicineId);

            modelBuilder.Entity<SupplieMedicine>()
                .HasOne(u=>u.Suplie)
                .WithMany()
                .HasForeignKey(u=>u.SuplieId)
                .IsRequired();
            modelBuilder.Entity<SupplieMedicine>()
               .HasOne(u => u.Medicine)
               .WithMany()
               .HasForeignKey(u => u.MedicineId)
               .IsRequired();
            #endregion

            #region Для сущности sale_Medicine
            modelBuilder.Entity<SaleMedicine>().HasKey(u => u.SaleMedecineId);

            modelBuilder.Entity<SaleMedicine>()
                .HasOne(u => u.Cheque)
                .WithMany()
                .HasForeignKey(u => u.ChequeId)
                .IsRequired();

            modelBuilder.Entity<SaleMedicine>()
               .HasOne(u => u.Medecine)
               .WithMany()
               .HasForeignKey(u => u.MedecineId)
               .IsRequired();
            #endregion

            #region Для сущности Cheque 
            modelBuilder.Entity<Cheque>().HasKey(u => u.ChequeId);

            modelBuilder.Entity<Cheque>()
                .HasOne(u => u.Client)
                .WithMany()
                .HasForeignKey(u => u.ClientId)
                .IsRequired();//Создание внешнего ключа 

            modelBuilder.Entity<Cheque>()
               .HasOne(u => u.Employer)
               .WithMany()
               .HasForeignKey(u => u.EmployerId)
               .IsRequired();//Создание внешнего ключа 
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
