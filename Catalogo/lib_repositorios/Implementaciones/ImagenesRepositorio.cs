using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class ImagenesRepositorio : IImagenesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public ImagenesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Imagenes> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Imagenes",
                Referencia = 0,
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return Buscar(x => x != null);
        }
        public List<Imagenes> Buscar(Expression<Func<Imagenes, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Imagenes",
                Referencia = 0,
                Accion = "Buscar",
                Fecha = DateTime.Now
            });
            return conexion!.Buscar(condiciones);
        }
        public Imagenes Guardar(Imagenes entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Imagenes",
                Referencia = entidad.Id,
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Imagenes Modificar(Imagenes entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Imagenes",
                Referencia = entidad.Id,
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Imagenes Borrar(Imagenes entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Imagenes",
                Referencia = entidad.Id,
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}
