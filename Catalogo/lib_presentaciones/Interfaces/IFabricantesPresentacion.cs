using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IFabricantesPresentacion
    {
        Task<List<Fabricantes>> Listar();
        Task<List<Fabricantes>> Buscar(Fabricantes entidad, string tipo);
        Task<Fabricantes> Guardar(Fabricantes entidad);
        Task<Fabricantes> Modificar(Fabricantes entidad);
        Task<Fabricantes> Borrar(Fabricantes entidad);
    }
}