using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class EstadosPruebaUnitaria
    {
        private IEstadosComunicacion? iComunicacion = null;
        private Estados? entidad = null;
        private List<Estados>? lista = null;
        public EstadosPruebaUnitaria()
        {
            iComunicacion = new EstadosComunicacion();
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
            lista = JsonConversor.ConvertirAObjeto<List<Estados>>(
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
            lista = JsonConversor.ConvertirAObjeto<List<Estados>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Estados()
            {
                Nombre = "Prueba"
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Estados>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre = "Test";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Estados>(
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
            entidad = JsonConversor.ConvertirAObjeto<Estados>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}