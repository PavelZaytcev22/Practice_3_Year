using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Cheque> Cheques { get; set; } = null!;

        public DbSet<Employer> Emploers { get; set; } = null!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public DbSet<Medicine> Medicines { get; set; } = null!;

        public DbSet<Post> Posts { get; set; } =null!;

        public DbSet<Sale_Medicine> Sale_Medicines { get; set; } = null!;

        public DbSet<Supplie> Supplies { get; set; } = null!;

        public DbSet<Supplie_Medicine> Supplie_Medicines { get; set; } = null!;

        public DbSet<Supplier> Suppliers { get; set; } = null!;


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)//При создании будут эти свойства
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
                .WithMany(u => u.Employers)
                .HasForeignKey(u=>u.POST_ID)
                .IsRequired();

            //Для сущности Medicine 
            modelBuilder.Entity<Medicine>().HasKey(u => u.MEDICINE_ID);

            modelBuilder.Entity<Medicine>()
                .HasOne(u => u.MANUFACTURER)
                .WithMany(u => u.Medicines)
                .HasForeignKey(u => u.MUNUFACTURER_ID)
                .IsRequired();//Создание внешнего ключа 

            //Для сущности Supplie 
            modelBuilder.Entity<Supplie>().HasKey(u => u.SUPPLIE_ID);
            modelBuilder.Entity<Supplie>()
                .HasOne(u => u.SUPPLIER)
                .WithMany(u => u.Supplies)
                .HasForeignKey(u => u.SUPPLIER_ID)
                .IsRequired();
            
            //Для сущности Supplie_Med
            modelBuilder.Entity<Supplie_Medicine>().HasKey(u => u.SUPPL_MED_ID);

            modelBuilder.Entity<Supplie_Medicine>()
                .HasOne(u=>u.SUPPLIE)
                .WithMany(u=>u.Suppl_Med)
                .HasForeignKey(u=>u.SUPLIE_ID)
                .IsRequired();
            modelBuilder.Entity<Supplie_Medicine>()
               .HasOne(u => u.MEDICINE)
               .WithMany(u => u.Suppl_Med)
               .HasForeignKey(u => u.MEDICINE_ID)
               .IsRequired();


            //Для сущности sale_Medicine
            modelBuilder.Entity<Sale_Medicine>().HasKey(u => u.SALE_MED_ID);

            modelBuilder.Entity<Sale_Medicine>()
                .HasOne(u => u.CHEQUE)
                .WithMany(u => u.Sale_Medicines)
                .HasForeignKey(u => u.CHEQUE_ID)
                .IsRequired();

            modelBuilder.Entity<Sale_Medicine>()
               .HasOne(u => u.MEDICINE)
               .WithMany(u => u.Sale_Med)
               .HasForeignKey(u => u.MEDICINE_ID)
               .IsRequired();

            //Для сущности Cheque 
            modelBuilder.Entity<Cheque>().HasKey(u => u.CHEQUE_ID);

            modelBuilder.Entity<Cheque>()
                .HasOne(u => u.CLIENT)
                .WithMany(u => u.Cheques)
                .HasForeignKey(u => u.CLIENT_ID)
                .IsRequired();//Создание внешнего ключа 

            modelBuilder.Entity<Cheque>()
               .HasOne(u => u.EMPLOEYER)
               .WithMany(u => u.Cheques)
               .HasForeignKey(u => u.EMPLOYER_ID)
               .IsRequired();//Создание внешнего ключа 

        }
    }
}
