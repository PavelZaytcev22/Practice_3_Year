using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebApplication3.Models;
using WebApplication3.Interfaces;
using WebApplication3.Repository;
using WebApplication3.Service;
using WebApplication3.Validators;
using Npgsql.EntityFrameworkCore.PostgreSQL;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//������� ����������� � ���������������
builder.Services.AddControllers();//������� �����������
builder.Services.AddFluentValidationAutoValidation();//������� ��������� 

builder.Services.AddDbContext<ApplicationContext>(
    options =>
    {
        //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"),
        op =>
        {
            op.EnableRetryOnFailure(3);//���������� ��������� �������
        });
        //����� ������ ����� ��� ��������� 
    }
    );
//builder.Services.AddDbContext<ApplicationContext>();

#region ����������� ������������
builder.Services.AddScoped<IRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IRepository<Employer>, EmployerRepository>();
builder.Services.AddScoped<IRepository<Manufacturer>, ManufacturerRepository>();
builder.Services.AddScoped<IRepository<Medicine>, MedicineRepository>();
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<IRepository<Supplie>,SupplieRepository>();
builder.Services.AddScoped<IRepository<Supplier>, SupplierRepository>();
builder.Services.AddScoped<IRepository<SaleMedicine>, SaleMedicineRepository>();
builder.Services.AddScoped<IRepository<SupplieMedicine>, SupplieMedicineRepository>();
builder.Services.AddScoped<IRepository<Cheque>, ChequeReposirory>();
#endregion

builder.Services.AddValidatorsFromAssemblyContaining<ClientValidator>();//��������������� ��� ����������


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );*/
app.Run();
