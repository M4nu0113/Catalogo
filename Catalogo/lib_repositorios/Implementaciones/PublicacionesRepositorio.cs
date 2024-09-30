using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PublicacionesRepositorio : IPublicacionesRepositorio
    {
        private Conexion? conexion = null;

        public PublicacionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Publicaciones> Listar()
        {
            return conexion!.Listar<Publicaciones>();
        }
        public List<Publicaciones> Buscar(Expression<Func<Publicaciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        public Publicaciones Guardar(Publicaciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Publicaciones Modificar(Publicaciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Publicaciones Borrar(Publicaciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}
