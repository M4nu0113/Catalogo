using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class PublicacionesAplicacion : IPublicacionesAplicacion
    {
        private IPublicacionesRepositorio? iRepositorio = null;

        public PublicacionesAplicacion(IPublicacionesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Publicaciones Borrar(Publicaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Publicaciones Guardar(Publicaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Publicaciones> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Publicaciones> Buscar(Publicaciones entidad, string tipo)
        {
            Expression<Func<Publicaciones, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "TITULO": condiciones = x => x.Titulo!.Contains(entidad.Titulo!); break;
                case "FECHA": condiciones = x => x.Fecha == entidad.Fecha; break;
                case "ESTADO": condiciones = x => x.Estado == entidad.Estado; break;
                case "PRODUCTO": condiciones = x => x.Producto == entidad.Producto; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Publicaciones Modificar(Publicaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}