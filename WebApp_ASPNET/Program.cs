var builder = WebApplication.CreateBuilder(args);   // Création de la classe WebApplicationBuilder

// Add services to the container.
builder.Services.AddControllers();              // Ajout des services dans les controllers

// Configurer Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();     // Ajout des points d'entrée d'API
builder.Services.AddSwaggerGen();               // Ajout des services dans le SwaggerGen

var app = builder.Build();     // Instancie dans la variable app une WebApplication configurée

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    // Vérifie que l'hôte a le même nom que Environnement.Développement 
{
    app.UseSwagger();                   // Active le middleware Swagger
    app.UseSwaggerUI();                 // Active le middleware Swagger User Interface
}

app.UseHttpsRedirection();             // Redirige les requêtes HTTP vers HTTPS

app.UseAuthorization();               // Active le middleware d'autorisation

app.MapControllers();                 // Mappe les contrôleurs aux points de terminaison HTTP

app.Run();                            // Démarre l'exécution de l'application web ASP.NET Core