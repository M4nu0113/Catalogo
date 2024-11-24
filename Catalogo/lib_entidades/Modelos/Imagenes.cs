using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Imagenes
    {
        [Key] public int Id { get; set; }
        public int Producto { get; set; }
        public string? Archivo { get; set; }
        public string? Informacion { get; set; }

        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

        public bool Validar()
        {
            if (_Producto == null)
                return false;
            if (string.IsNullOrEmpty(Archivo))
                return false;
            return true;
        }

        public void ConvertirFormato()
        {
            // contenido del método
        }
        public void ValidarFormato()
        {
            // contenido del método
        }
    }
}
