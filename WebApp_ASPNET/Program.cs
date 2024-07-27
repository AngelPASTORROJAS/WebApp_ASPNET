var builder = WebApplication.CreateBuilder(args);   // Cr�ation de la classe WebApplicationBuilder

// Add services to the container.
builder.Services.AddControllers();              // Ajout des services dans les controllers

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