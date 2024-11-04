using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IFabricantesRepositorio
    {
        void Configurar(string string_conexion);
        List<Fabricantes> Listar();
        List<Fabricantes> Buscar(Expression<Func<Fabricantes, bool>>condiciones);
        Fabricantes Guardar(Fabricantes entidad);
        Fabricantes Modificar(Fabricantes entidad);
        Fabricantes Borrar(Fabricantes entidad);
    }
}
