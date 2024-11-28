using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class RolesRepositorio : IRolesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public RolesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Roles> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Roles",
                Referencia = 0,
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return conexion!.Listar<Roles>();
        }
        public List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Roles",
                Referencia = 0,
                Accion = "Buscar",
                Fecha = DateTime.Now
            });
            return conexion!.Buscar(condiciones);
        }
        public Roles Guardar(Roles entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Roles",
                Referencia = entidad.Id,
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Roles",
                Referencia = entidad.Id,
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Roles",
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
