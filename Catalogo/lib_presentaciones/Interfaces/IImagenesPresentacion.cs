using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEstadosPresentacion
    {
        Task<List<Casas>> Listar();
        Task<List<Casas>> Buscar(Casas entidad, string tipo);
        Task<Casas> Guardar(Casas entidad);
        Task<Casas> Modificar(Casas entidad);
        Task<Casas> Borrar(Casas entidad);
    }
}