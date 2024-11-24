using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Publicaciones
    {
        [Key] public int Id { get; set; }
        public int Producto { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }

        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Estado")] public Estados? _Estado { get; set; }

        public bool Validar()
        {
            if (_Producto == null) 
                return false;
            if (_Estado == null)
                return false;
            if (Fecha == null)
                return false;
            if (string.IsNullOrEmpty(Titulo))
                return false;
            return true;

        }

        public void Publicar()
        {
            // contenido del método
        }
        public void ValidarEstado()
        {
            // contenido del método
        }
        public void CambiarEstado()
        {
            // contenido del método
        }
        public void FiltrarRangoPrecio()
        {
            // contenido del método
        }
    }
}