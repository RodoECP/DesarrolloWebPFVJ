using System; // Espacio de nombres para funcionalidades básicas de .NET
using System.Collections.Generic; // Espacio de nombres para colecciones genéricas
using Microsoft.EntityFrameworkCore; // Espacio de nombres para Entity Framework Core
using Microsoft.EntityFrameworkCore.Metadata; // Espacio de nombres para metadatos de Entity Framework Core

namespace PFVJ1.Models
{
    // Contexto de la base de datos para la aplicación de Videojuegos.
    public partial class VideojuegoContext : DbContext
    {
        // Constructor por defecto.
        public VideojuegoContext()
        {
        }

        // Constructor que acepta opciones de configuración para el contexto.
        public VideojuegoContext(DbContextOptions<VideojuegoContext> options)
           : base(options)
        {
        }

        // Conjunto de entidades de la tabla Categoria.
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;

        // Conjunto de entidades de la tabla Datos.
        public virtual DbSet<Datos> Datos { get; set; } = null!;

        // Método para configurar las opciones del contexto. Aquí se puede configurar la conexión a la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Este método se deja vacío ya que la configuración se realiza en el método principal de la aplicación.
        }

        // Método para configurar el modelo de la base de datos utilizando el ModelBuilder.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Categoria.
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaID).HasName("PK_IDCATEGORIA"); // Definir la llave primaria.
                entity.ToTable("Categoria"); // Nombre de la tabla en la base de datos.

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(50) // Longitud máxima de 50 caracteres.
                    .IsUnicode(false); // No se utiliza codificación Unicode.
            });

            // Configuración de la entidad Datos.
            modelBuilder.Entity<Datos>(entity =>
            {
                entity.HasKey(e => e.IdVideojuego).HasName("PK_IDVideojuego"); // Definir la llave primaria.
                entity.ToTable("Datos"); // Nombre de la tabla en la base de datos.

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60) // Longitud máxima de 60 caracteres.
                    .IsUnicode(false); // No se utiliza codificación Unicode.

                entity.Property(e => e.Precio)
                    .HasMaxLength(60) // Longitud máxima de 60 caracteres.
                    .IsUnicode(false); // No se utiliza codificación Unicode.

                entity.Property(e => e.Stock)
                    .HasMaxLength(60) // Longitud máxima de 60 caracteres.
                    .IsUnicode(false); // No se utiliza codificación Unicode.

                // Definir la relación entre Datos y Categoria.
                entity.HasOne(d => d.VideojuegosDB)
                    .WithMany(p => p.Datos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Cargo"); // Nombre de la restricción de clave foránea.
            });

            // Método parcial para configuraciones adicionales en el modelo.
            OnModelCreatingPartial(modelBuilder);
        }

        // Método parcial para permitir configuraciones adicionales en subclases.
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
