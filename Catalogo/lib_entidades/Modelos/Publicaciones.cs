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

        

        [NotMapped] public Productos? _Producto { get; set; }
        [NotMapped] public Estados? _Estado { get; set; }

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