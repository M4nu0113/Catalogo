using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IUsuariosRepositorio
    {
        void Configurar(string string_conexion);
        List<Usuarios> Listar();
        List<Usuarios> Buscar(Expression<Func<Usuarios, bool>> condiciones);
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
    }
}
