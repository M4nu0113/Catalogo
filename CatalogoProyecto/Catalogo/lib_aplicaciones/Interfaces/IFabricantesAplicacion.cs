using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IFabricantesAplicacion
    {
        void Configurar(string string_conexion);
        List<Fabricantes> Buscar(Fabricantes entidad, string tipo);
        List<Fabricantes> Listar();
        Fabricantes Guardar(Fabricantes entidad);
        Fabricantes Modificar(Fabricantes entidad);
        Fabricantes Borrar(Fabricantes entidad);
    }
}
