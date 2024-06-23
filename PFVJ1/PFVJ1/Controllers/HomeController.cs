using Microsoft.AspNetCore.Mvc.Rendering; // Espacio de nombres para SelectListItem
using Microsoft.AspNetCore.Mvc; // Espacio de nombres para clases de controladores
using Microsoft.EntityFrameworkCore; // Espacio de nombres para funcionalidades de Entity Framework Core
using PFVJ1.Models; // Espacio de nombres para modelos
using PFVJ1.Models.ViewModels; // Espacio de nombres para modelos de vista
using System.Diagnostics; // Espacio de nombres para funcionalidades de diagnósticos

namespace PFVJ1.Controllers
{
    // HomeController maneja las operaciones principales relacionadas con las entidades Videojuego.
    public class HomeController : Controller
    {
        // Contexto de base de datos para acceder a la base de datos de Videojuego.
        private readonly VideojuegoContext _DBContext;

        // Constructor para inicializar el contexto de la base de datos.
        public HomeController(VideojuegoContext context)
        {
            _DBContext = context;
        }

        // Método de acción para mostrar la lista de videojuegos.
        public IActionResult Index()
        {
            // Recuperar la lista de videojuegos incluyendo sus categorías relacionadas.
            List<Datos> lista = _DBContext.Datos.Include(c => c.VideojuegosDB).ToList();
            return View(lista); // Pasar la lista a la vista.
        }

        // Método GET para mostrar los detalles de un videojuego específico o un formulario para crear uno nuevo.
        [HttpGet]
        public IActionResult VideoJuego_Detalle(int IdVideojuego)
        {
            // Inicializar el modelo de vista para los detalles del videojuego.
            VideojuegosVM oVideojuegoVM = new VideojuegosVM()
            {
                oDatos = new Datos(), // Crear un nuevo objeto Datos.
                oLista = _DBContext.Categoria.Select(categoria => new SelectListItem()
                {
                    Text = categoria.NombreCategoria, // Nombre de la categoría.
                    Value = categoria.CategoriaID.ToString() // ID de la categoría.
                }).ToList() // Convertir a una lista de SelectListItem.
            };

            // Si se proporciona un ID de videojuego existente, recuperar sus detalles.
            if (IdVideojuego != 0)
            {
                oVideojuegoVM.oDatos = _DBContext.Datos.Find(IdVideojuego);
            }
            return View(oVideojuegoVM); // Pasar el modelo de vista a la vista.
        }

        // Método POST para guardar los detalles del videojuego (crear o actualizar).
        [HttpPost]
        public IActionResult VideoJuego_Detalle(VideojuegosVM oVideojuegoVM)
        {
            // Si el videojuego es nuevo (ID es 0), agregarlo a la base de datos.
            if (oVideojuegoVM.oDatos.IdVideojuego == 0)
            {
                _DBContext.Datos.Add(oVideojuegoVM.oDatos);
            }
            else
            {
                // Si el videojuego existe, actualizar sus detalles en la base de datos.
                _DBContext.Datos.Update(oVideojuegoVM.oDatos);
            }
            _DBContext.SaveChanges(); // Guardar los cambios en la base de datos.
            return RedirectToAction("Index", "Home"); // Redirigir a la acción Index.
        }

        // Método GET para mostrar la página de confirmación para eliminar un videojuego.
        [HttpGet]
        public IActionResult Eliminar(int IdVideojuego)
        {
            // Recuperar el videojuego que se va a eliminar incluyendo su categoría relacionada.
            Datos oDatos = _DBContext.Datos.Include(c => c.VideojuegosDB).Where(e => e.IdVideojuego == IdVideojuego).FirstOrDefault();
            return View(oDatos); // Pasar los detalles del videojuego a la vista.
        }

        // Método POST para eliminar el videojuego.
        [HttpPost]
        public IActionResult Eliminar(Datos oDatos)
        {
            // Eliminar el videojuego de la base de datos.
            _DBContext.Datos.Remove(oDatos);
            _DBContext.SaveChanges(); // Guardar los cambios en la base de datos.
            return RedirectToAction("Index", "Home"); // Redirigir a la acción Index.
        }
    }
}

