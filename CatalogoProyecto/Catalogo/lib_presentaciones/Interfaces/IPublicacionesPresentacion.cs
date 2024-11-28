using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPublicacionesPresentacion
    {
        Task<List<Publicaciones>> Listar();
        Task<List<Publicaciones>> Buscar(Publicaciones entidad, string tipo);
        Task<Publicaciones> Guardar(Publicaciones entidad);
        Task<Publicaciones> Modificar(Publicaciones entidad);
        Task<Publicaciones> Borrar(Publicaciones entidad);
    }
}