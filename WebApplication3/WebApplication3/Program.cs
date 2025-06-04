using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebApplication3.Models;
using WebApplication3.Interfaces;
using WebApplication3.Repository;
using WebApplication3.Service;
using WebApplication3.Validators;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Controllers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationContext>(
    options =>
    {
        //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"),
        op =>
        {
            op.EnableRetryOnFailure(3);//количество повторных попыток
        });
        //много разных опций для настройки 
    }
    );

//builder.Services.AddDbContext<ApplicationContext>();
#region Регистрация репозиториев
builder.Services.AddScoped<IRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IRepository<Employer>, EmployerRepository>();
builder.Services.AddScoped<IRepository<Manufacturer>, ManufacturerRepository>();
builder.Services.AddScoped<IRepository<Medicine>, MedicineRepository>();
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<IRepository<Supplie>, SupplieRepository>();
builder.Services.AddScoped<IRepository<Supplier>, SupplierRepository>();
builder.Services.AddScoped<IRepository<SaleMedicine>, SaleMedicineRepository>();
builder.Services.AddScoped<IRepository<SupplieMedicine>, SupplieMedicineRepository>();
builder.Services.AddScoped<IRepository<Cheque>, ChequeReposirory>();
#endregion

#region Registration Services 
builder.Services.AddScoped<IService<Client>, ClientService>()
.AddScoped<IService<Employer>, EmployerService>()
.AddScoped<IService<Manufacturer>, ManufacturerService>()
.AddScoped<IService<Medicine>, MedicineService>()
.AddScoped<IService<Post>, PostService>()
.AddScoped<IService<Supplie>, SupplieService>()
.AddScoped<IService<Supplier>, SupplierService>()
.AddScoped<IService<SaleMedicine>, SaleMedicineService>()
.AddScoped<IService<SupplieMedicine>, SupplieMedicineService>()
.AddScoped<IService<Cheque>, ChequeService>();
#endregion

#region Registration Controllers
builder.Services.AddScoped<ControllerBase, ClientController>()
    .AddScoped<ControllerBase, ManufacturerController>()
    .AddScoped<ControllerBase, PostController>()
    .AddScoped<ControllerBase, ChequeController>()
    .AddScoped<ControllerBase, EmployerController>()
    .AddScoped<ControllerBase, MedicineController>()
    .AddScoped<ControllerBase, SaleMedicineController>()
    .AddScoped<ControllerBase, SupplieController>()
    .AddScoped<ControllerBase, SupplieMedicineController>()
    .AddScoped<ControllerBase, SaleMedicineController>()
    .AddScoped<ControllerBase, SupplierController>();
#endregion

builder.Services.AddControllers();//Добавил контроллеры
builder.Services.AddFluentValidationAutoValidation();//Добавил валидацию 
builder.Services.AddValidatorsFromAssemblyContaining<ClientValidator>();//зарегистрировал все валидаторы

builder.Services.AddSwaggerGen(sw =>
{
    sw.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "api",
        Version = "v1",
        Description = "API",
    });
    var file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var path = Path.Combine(AppContext.BaseDirectory, file);
    sw.IncludeXmlComments(path);
});

var app = builder.Build();

//Check DB connetion 
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    try
    {
        dbContext.Database.OpenConnection();
        dbContext.Database.CloseConnection();
        Console.WriteLine("Подключение работает!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка подключения к БД: {ex.Message}");
    }
}

app.MapGet("/", () => "Hello World!!!!");
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json","Demo"); });

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );*/
app.Run();
