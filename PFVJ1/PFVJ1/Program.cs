using Microsoft.EntityFrameworkCore; // Espacio de nombres para Entity Framework Core
using PFVJ1.Models; // Espacio de nombres para los modelos de la aplicaci�n

var builder = WebApplication.CreateBuilder(args); // Crear el constructor para la aplicaci�n web

// Agregar servicios para controladores con vistas al contenedor de servicios.
builder.Services.AddControllersWithViews();

// Configurar el contexto de la base de datos para usar SQL Server con la cadena de conexi�n especificada.
builder.Services.AddDbContext<VideojuegoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoJuegosConnection"))
);

var app = builder.Build(); // Construir la aplicaci�n web

// Configuraci�n para manejar excepciones en entornos que no son de desarrollo.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Usar una p�gina de error gen�rica.
}

// Habilitar el uso de archivos est�ticos (como archivos CSS, JS, im�genes, etc.)
app.UseStaticFiles();

app.UseRouting(); // Habilitar el enrutamiento de la aplicaci�n.

app.UseAuthorization(); // Habilitar la autorizaci�n.

// Configurar la ruta predeterminada para los controladores.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicaci�n.
app.Run();
