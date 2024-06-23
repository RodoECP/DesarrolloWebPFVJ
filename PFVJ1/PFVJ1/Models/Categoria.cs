using static System.Runtime.InteropServices.JavaScript.JSType; // Importa la clase JSType del espacio de nombres System.Runtime.InteropServices.JavaScript
using System.ComponentModel.DataAnnotations.Schema; // Espacio de nombres para atributos de esquema de base de datos
using System.ComponentModel.DataAnnotations; // Espacio de nombres para atributos de validación de datos

namespace PFVJ1.Models
{
    // Clase que representa una categoría de videojuegos.
    public class Categoria
    {
        // Constructor que inicializa la colección de Datos.
        public Categoria()
        {
            Datos = new HashSet<Datos>(); // Inicializa la colección de Datos.
        }

        // Llave primaria, generada automáticamente por la base de datos.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaID { get; set; }

        // Nombre de la categoría. Puede ser nulo.
        public string? NombreCategoria { get; set; }

        // Colección de Datos relacionados con la categoría.
        public virtual ICollection<Datos> Datos { get; set; }
    }
}
