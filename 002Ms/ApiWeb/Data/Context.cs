using Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        #region Constructor
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions){}
        #endregion
        #region Entidades
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        #endregion
        #region Configuracion de las entidades para moldear a la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicación de las configuraciones específicas para moldear a la base de datos
            Usuario.Configure(modelBuilder);

            // Llamar a la configuración base al final (recomendado)
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
