using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstadosRepositorio : IEstadosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public EstadosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Estados> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Estados",
                Referencia = 0,
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return conexion!.Listar<Estados>();
        }
        public List<Estados> Buscar(Expression<Func<Estados, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Estados",
                Referencia = 0,
                Accion = "Buscar",
                Fecha = DateTime.Now
            });
            return conexion!.Buscar(condiciones);
        }
        public Estados Guardar(Estados entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Estados",
                Referencia = entidad.Id,
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Estados Modificar(Estados entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Estados",
                Referencia = entidad.Id,
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Estados Borrar(Estados entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Estados",
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
