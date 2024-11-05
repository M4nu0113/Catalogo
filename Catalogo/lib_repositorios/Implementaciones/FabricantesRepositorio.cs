using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class FabricantesRepositorio : IFabricantesRepositorio
    {
        private Conexion? conexion = null;

        public FabricantesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Fabricantes> Listar()
        {
            return conexion!.Listar<Fabricantes>();
        }
        public List<Fabricantes> Buscar(Expression<Func<Fabricantes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        public Fabricantes Guardar(Fabricantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Fabricantes Modificar(Fabricantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Fabricantes Borrar(Fabricantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}
