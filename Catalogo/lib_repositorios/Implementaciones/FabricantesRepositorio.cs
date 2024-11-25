using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class FabricantesRepositorio : IFabricantesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public FabricantesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Fabricantes> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Fabricantes",
                Referencia = 0,
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return conexion!.Listar<Fabricantes>();
        }
        public List<Fabricantes> Buscar(Expression<Func<Fabricantes, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Fabricantes",
                Referencia = 0,
                Accion = "Buscar",
                Fecha = DateTime.Now
            });
            return conexion!.Buscar(condiciones);
        }
        public Fabricantes Guardar(Fabricantes entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Fabricantes",
                Referencia = entidad.Id,
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Fabricantes Modificar(Fabricantes entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Fabricantes",
                Referencia = entidad.Id,
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Fabricantes Borrar(Fabricantes entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias
            {
                Tabla = "Fabricantes",
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
