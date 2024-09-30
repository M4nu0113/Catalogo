using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public int Fabricante { get; set; }
        public int Categoria { get; set; }

        [NotMapped] public Fabricantes? _Fabricante { get; set; }
        [NotMapped] public Categorias? _Categoria { get; set; }
        public void ObtenerPublicaciones()
        {
            // contenido del método
        }
        public void FiltrarRangoPrecio()
        {
            // contenido del método
        }
        public void AgregarImagen()
        {
            // contenido del método
        }
        public void RemoverImagen()
        {
            // contenido del método
        }
    }
}
