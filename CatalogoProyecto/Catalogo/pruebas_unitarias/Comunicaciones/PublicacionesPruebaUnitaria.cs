using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class PublicacionesPruebaUnitaria
    {
        private IPublicacionesComunicacion? iComunicacion = null;
        private Publicaciones? entidad = null;
        private List<Publicaciones>? lista = null;
        public PublicacionesPruebaUnitaria()
        {
            iComunicacion = new PublicacionesComunicacion();
        }
        [TestMethod]
        public void Executar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }
        private void Listar()
        {
            var datos = new Dictionary<string, object>();
            var task = iComunicacion!.Listar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Publicaciones>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "Prueba";
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Publicaciones>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Publicaciones()
            {
                Producto = 1,
                Estado = 1,
                Imagen = 1,
                Fecha = DateTime.Now,
                Titulo = "Prueba",
                Descripcion = "Prueba unitaria publicaciones",
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Publicaciones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Titulo = "Test";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Publicaciones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        public void Borrar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Borrar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Publicaciones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}