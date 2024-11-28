using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IPublicacionesRepositorio
    {
        void Configurar(string string_conexion);
        List<Publicaciones> Listar();
        List<Publicaciones> Buscar(Expression<Func<Publicaciones, bool>> condiciones);
        Publicaciones Guardar(Publicaciones entidad);
        Publicaciones Modificar(Publicaciones entidad);
        Publicaciones Borrar(Publicaciones entidad);
    }
}