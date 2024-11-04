using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Categorias
    {
        [Key] public int Id { get; set; }
        public string? Categoria { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Categoria))
                return false;
            return true;
        }

        public void FiltrarProductoCategoria()
        {
            // contenido del método
        }
    }
}
