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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApplication3.Controllers;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using WebApplication3.Settings;

var builder = WebApplication.CreateBuilder(args);


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

#region Registration Repositories
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
    .AddScoped<ControllerBase, SupplierController>()

    .AddTransient<ControllerBase, AuthorizationController>()
    .AddScoped<ControllerBase, Ex�elController>();
#endregion

builder.Services.AddControllers();//������� �����������
builder.Services.AddFluentValidationAutoValidation();//������� ��������� 
builder.Services.AddValidatorsFromAssemblyContaining<ClientValidator>();//��������������� ��� ����������

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


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        };
    }
    );

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("DepartmentOnly", policy => policy.RequireRole("Director", "Maneger", "Employer"));
    opt.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
}
);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

//Check DB connetion 
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    try
    {
        dbContext.Database.OpenConnection();
        dbContext.Database.CloseConnection();
        Console.WriteLine("����������� ��������!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"������ ����������� � ��: {ex.Message}");
    }
}

app.MapGet("/", () => "Hello World!!!!");

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json","Demo"); });
app.UseDeveloperExceptionPage();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
