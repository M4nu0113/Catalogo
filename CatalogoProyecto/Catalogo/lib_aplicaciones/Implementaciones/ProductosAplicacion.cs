using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IProductosRepositorio? iRepositorio = null;

        public ProductosAplicacion(IProductosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Productos Guardar(Productos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Productos> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Productos> Buscar(Productos entidad, string tipo)
        {
            Expression<Func<Productos, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                case "CODIGO": condiciones = x => x.Codigo!.Contains(entidad.Codigo!); break;
                case "PRECIO": condiciones = x => x.Precio == entidad.Precio; break;
                case "DESDE PRECIO": condiciones = x => x.Precio >= entidad.Precio; break;
                case "FABRICANTE": condiciones = x => x.Fabricante == entidad.Fabricante; break;
                case "CATEGORIA": condiciones = x => x.Categoria == entidad.Categoria; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Productos Modificar(Productos entidad)
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