using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IImagenesAplicacion
    {
        void Configurar(string string_conexion);
        List<Imagenes> Buscar(Imagenes entidad, string tipo);
        List<Imagenes> Listar();
        Imagenes Guardar(Imagenes entidad);
        Imagenes Modificar(Imagenes entidad);
        Imagenes Borrar(Imagenes entidad);
    }
}