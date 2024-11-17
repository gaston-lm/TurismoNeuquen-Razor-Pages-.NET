using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TurismoNeuquen.Data;
using TurismoNeuquen.Services;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System;
using TurismoNeuquen.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using EjemploComponentes.Services;
using TurismoNeuquen.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar los servicios
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;  // Deshabilitar el enrutamiento de endpoint para usar MVC clásico
})
.AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/index", "home");  // Rutas personalizadas para Razor Pages
    options.Conventions.AddPageRoute("/index", "start");
});

builder.Services.AddLogging();  // Agregar servicios de logging
builder.Services.AddHealthChecks();  // Agregar Health Checks

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

// Registrar DbContext con base de datos en memoria
builder.Services.AddDbContext<dataContext>(options =>
{
    //options.UseInMemoryDatabase("bookTestDb");
    options.UseSqlServer(
        connection, 
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,       // Number of retry attempts (default is 6)
            maxRetryDelay: TimeSpan.FromSeconds(2), // Delay between retries
            errorNumbersToAdd: null // Custom list of SQL error numbers to add (optional)
        )
    );
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Default scheme
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/AdminLogin"; // Default login path for first cookie
})
.AddCookie("UserCookie", options => // Custom authentication scheme for the second cookie
{
    options.LoginPath = "/UserLogin"; // Redirect here for the second cookie
});

builder.Services.AddHttpClient<IUploadImageAPIService, UploadImageAPIService>();
builder.Services.AddScoped<IPoiRepository, PoiRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IPoiService, PoiService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
app.UseHealthChecks("/health");  // Ruta para health check

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Página de excepciones en desarrollo
}
else
{
    app.UseExceptionHandler("/Error");  // Manejador de errores en producción
    app.UseHsts();  // Seguridad HSTS
}

app.UseHttpsRedirection();  // Redirección a HTTPS
app.UseStaticFiles();  // Servir archivos estáticos

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Para compatibilidad con MVC (al desactivar el enrutamiento de endpoint)
app.UseMvc();

app.MapGet("/PointsOfInterest", (dataContext context) =>
{
    return context.PointsOfInterest.ToList();
})
.WithName("GetPOIs")
.WithOpenApi();

app.MapPost("/PointsOfInterest", (PointOfInterest poi, dataContext context) =>
{
    context.Add(poi);
    context.SaveChanges();
})
.WithName("CreatePOI")
.WithOpenApi();

app.Run();