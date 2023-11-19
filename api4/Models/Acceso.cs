using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api4.Models
{
    public class Acceso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id_acceso { get; set; }
        public string codigo_acceso { get; set; }
        public string descripcion_acceso { get; set; }


        public ICollection<Usuario> UsuarioAcceso { get; set; }//una acceso puede tener muchos Usuarios
    }
}
