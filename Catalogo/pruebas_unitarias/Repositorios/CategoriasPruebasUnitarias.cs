using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class CategoriasPruebasUnitarias
    {
        private ICategoriasRepositorio? iRepositorio = null;
        private Categorias? entidad = null;
        public CategoriasPruebasUnitarias()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=M4NU_HELPER\\DEV;database=bd_catalogo;uid=sa;pwd=STEMgirls>>>; TrustServerCertificate = true; ";
            var auditorias = new AuditoriasRepositorio(conexion);
            iRepositorio = new CategoriasRepositorio(conexion,auditorias);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }
        private void Guardar()
        {
            entidad = new Categorias()
            {
                Categoria = "Prueba",
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        private void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar()
        {
            entidad!.Categoria = "Prueba Modificada";
            entidad = iRepositorio!.Modificar(entidad);
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
