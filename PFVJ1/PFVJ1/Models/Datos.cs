using System.ComponentModel.DataAnnotations.Schema; // Espacio de nombres para atributos de esquema de base de datos
using System.ComponentModel.DataAnnotations; // Espacio de nombres para atributos de validación de datos

namespace PFVJ1.Models
{
    // Clase que representa los datos de un videojuego.
    public class Datos
    {
        // Llave primaria, generada automáticamente por la base de datos.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVideojuego { get; set; }

        // Nombre del videojuego.
        public string? Nombre { get; set; }

        // Precio del videojuego. 
        public decimal? Precio { get; set; }

        // Cantidad de stock del videojuego.
        public int? Stock { get; set; }

        // Identificador de la categoría del videojuego.
        public int? IdCategoria { get; set; }

        // Relación de clave foránea con la tabla de categorías.
        [ForeignKey("IdCategoria")]
        public virtual Categoria? VideojuegosDB { get; set; }
    }
}
