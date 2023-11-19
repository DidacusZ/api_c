using Microsoft.EntityFrameworkCore;

namespace api4.Models
{
    public class Contexto : DbContext
    {
        //para que no de error en m-m poner distinto nombre entidad que en BD
        // <nombre entidad>     nombre en BD
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Acceso> Accesos { get; set; }

        public Contexto(DbContextOptions<Contexto> opciones) : base(opciones)
        {

        }

        public Contexto()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                      
            //Usuarios-Acceso
            modelBuilder.Entity<Usuario>()
            .HasOne(uno => uno.acceso)
            .WithMany(muchos => muchos.UsuarioAcceso)
            .HasForeignKey(uno => uno.id_acceso);

            // Ignorar la propiedad de navegación en la serialización
            //modelBuilder.Entity<Usuario>().Ignore(u => u.acceso);

        }
    }
}


