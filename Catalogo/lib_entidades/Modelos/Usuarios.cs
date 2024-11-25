using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public string? Email { get; set; }
        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
        public int Rol { get; set; } = 1;
        [ForeignKey("Rol")] public Roles? _Rol { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            if (string.IsNullOrEmpty(Nombre))
                return false;
            if (string.IsNullOrEmpty(Contraseña))
                return false;
            if (_Rol == null)
                return false;
            return true;

        }

    }
}


