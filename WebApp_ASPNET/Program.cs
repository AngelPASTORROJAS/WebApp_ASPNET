using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp_ASPNET.Interfaces;
using WebApp_ASPNET.repositories;
using WebApp_ASPNET.Services;

var builder = WebApplication.CreateBuilder(args);   // Cr�ation de la classe WebApplicationBuilder

// Add services to the container.
builder.Services.AddControllers();              // Ajout des services dans les controllers

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Configurer Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();     // Ajout des points d'entr�e d'API
builder.Services.AddSwaggerGen();               // Ajout des services dans le SwaggerGen

var app = builder.Build();     // Instancie dans la variable app une WebApplication configur�e

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    // V�rifie que l'h�te a le m�me nom que Environnement.D�veloppement 
{
    app.UseSwagger();                   // Active le middleware Swagger
    app.UseSwaggerUI();                 // Active le middleware Swagger User Interface
}

app.UseHttpsRedirection();             // Redirige les requ�tes HTTP vers HTTPS

app.UseAuthorization();               // Active le middleware d'autorisation

app.MapControllers();                 // Mappe les contr�leurs aux points de terminaison HTTP

app.Run();                            // D�marre l'ex�cution de l'application web ASP.NET Core