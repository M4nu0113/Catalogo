using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public string? Tabla { get; set; }
        public int Referencia { get; set; }
        public string? Accion { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
