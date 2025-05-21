using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Models
{
    
    /// <summary>
    /// Контекст базы данных со всеми сущностями и настройками их ключей 
    /// <summary>
    public class ApplicationContext:DbContext
    {

        #region Коллекции БД 

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Cheque> Cheques { get; set; } = null!;
        public DbSet<Employer> Emploers { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Medicine> Medicines { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } =null!;
        public DbSet<Sale_Medicine> Sale_Medicines { get; set; } = null!;
        public DbSet<Supplie> Supplies { get; set; } = null!;
        public DbSet<SupplieMedicine> Supplie_Medicines { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;

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
            //Для сущности Client 
            modelBuilder.Entity<Client>().HasKey(u => u.CLIENT_ID);//PK

            //Для сущности Post 
            modelBuilder.Entity<Post>().HasKey(u=>u.POST_ID);

            //Для сущности Manufacturer 
            modelBuilder.Entity<Manufacturer>().HasKey(u=>u.MUNUFACTURER_ID);
            
            //Для сущности Suplier 
            modelBuilder.Entity<Supplier>().HasKey(u=>u.SUPPLIER_ID);

            //Для сущности Employer 
            modelBuilder.Entity<Employer>().HasKey(u=>u.EMPLOYER_ID);
            modelBuilder.Entity<Employer>()
                .HasOne(u => u.Post)
                .WithMany()
                .HasForeignKey(u=>u.POST_ID)
                .IsRequired();

            //Для сущности Medicine 
            modelBuilder.Entity<Medicine>().HasKey(u => u.MEDICINE_ID);

            modelBuilder.Entity<Medicine>()
                .HasOne(u => u.MANUFACTURER)
                .WithMany()
                .HasForeignKey(u => u.MUNUFACTURER_ID)
                .IsRequired();//Создание внешнего ключа 

            //Для сущности Supplie 
            modelBuilder.Entity<Supplie>().HasKey(u => u.SUPPLIE_ID);
            modelBuilder.Entity<Supplie>()
                .HasOne(u => u.SUPPLIER)
                .WithMany()
                .HasForeignKey(u => u.SUPPLIER_ID)
                .IsRequired();
            
            //Для сущности Supplie_Med
            modelBuilder.Entity<SupplieMedicine>().HasKey(u => u.SUPPL_MEDICINE_ID);

            modelBuilder.Entity<SupplieMedicine>()
                .HasOne(u=>u.SUPPLIE)
                .WithMany()
                .HasForeignKey(u=>u.SUPLIE_ID)
                .IsRequired();
            modelBuilder.Entity<SupplieMedicine>()
               .HasOne(u => u.MEDICINE)
               .WithMany()
               .HasForeignKey(u => u.MEDICINE_ID)
               .IsRequired();


            //Для сущности sale_Medicine
            modelBuilder.Entity<Sale_Medicine>().HasKey(u => u.SALE_MEDICINE_ID);

            modelBuilder.Entity<Sale_Medicine>()
                .HasOne(u => u.CHEQUE)
                .WithMany()
                .HasForeignKey(u => u.CHEQUE_ID)
                .IsRequired();

            modelBuilder.Entity<Sale_Medicine>()
               .HasOne(u => u.MEDICINE)
               .WithMany()
               .HasForeignKey(u => u.MEDICINE_ID)
               .IsRequired();

            //Для сущности Cheque 
            modelBuilder.Entity<Cheque>().HasKey(u => u.CHEQUE_ID);

            modelBuilder.Entity<Cheque>()
                .HasOne(u => u.CLIENT)
                .WithMany()
                .HasForeignKey(u => u.CLIENT_ID)
                .IsRequired();//Создание внешнего ключа 

            modelBuilder.Entity<Cheque>()
               .HasOne(u => u.EMPLOEYER)
               .WithMany()
               .HasForeignKey(u => u.EMPLOYER_ID)
               .IsRequired();//Создание внешнего ключа 

        }

    }
}
