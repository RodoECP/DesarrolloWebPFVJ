using Microsoft.EntityFrameworkCore; // Espacio de nombres para Entity Framework Core
using PFVJ1.Models; // Espacio de nombres para los modelos de la aplicación

var builder = WebApplication.CreateBuilder(args); // Crear el constructor para la aplicación web

// Agregar servicios para controladores con vistas al contenedor de servicios.
builder.Services.AddControllersWithViews();

// Configurar el contexto de la base de datos para usar SQL Server con la cadena de conexión especificada.
builder.Services.AddDbContext<VideojuegoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoJuegosConnection"))
);

var app = builder.Build(); // Construir la aplicación web

// Configuración para manejar excepciones en entornos que no son de desarrollo.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Usar una página de error genérica.
}

// Habilitar el uso de archivos estáticos (como archivos CSS, JS, imágenes, etc.)
app.UseStaticFiles();

app.UseRouting(); // Habilitar el enrutamiento de la aplicación.

app.UseAuthorization(); // Habilitar la autorización.

// Configurar la ruta predeterminada para los controladores.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicación.
app.Run();
