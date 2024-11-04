using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPublicacionesAplicacion
    {
        void Configurar(string string_conexion);
        List<Publicaciones> Buscar(Publicaciones entidad, string tipo);
        List<Publicaciones> Listar();
        Publicaciones Guardar(Publicaciones entidad);
        Publicaciones Modificar(Publicaciones entidad);
        Publicaciones Borrar(Publicaciones entidad);
    }
}