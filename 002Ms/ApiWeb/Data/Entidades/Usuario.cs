using Microsoft.EntityFrameworkCore;

namespace Data.Entidades
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        /// <summary>
        /// Configuración personalizada usando ModelBuilder
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                // Nombre de la tabla en PostgreSQL (con comillas para evitar conflictos)
                entity.ToTable("usuario");

                // Clave primaria
                entity.HasKey(e => e.IdUsuario).HasName("pk_usuario");

                // Propiedades
                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(150)
                    .IsRequired().HasComment("Correo electrónico único para cada usuario");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(15);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(200);
            });
        }
    }
}
