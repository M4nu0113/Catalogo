using lib_entidades;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TextTemplating;

namespace asp_presentacion.Pages.Ventanas
{
    public class PublicacionesModel : PageModel
    {
        private IPublicacionesPresentacion? iPresentacion = null;
        private IEstadosPresentacion? iEstadosPresentacion = null;
        private IProductosPresentacion? iProductosPresentacion = null;
        private IImagenesPresentacion? iImagenesPresentacion = null;

        public PublicacionesModel(IPublicacionesPresentacion iPresentacion,
            IEstadosPresentacion iEstadosPresentacion, IProductosPresentacion iProductosPresentacion, IImagenesPresentacion iImagenesPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iEstadosPresentacion = iEstadosPresentacion;
                this.iProductosPresentacion = iProductosPresentacion;
                this.iImagenesPresentacion = iImagenesPresentacion;
                Filtro = new Publicaciones();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Publicaciones? Actual { get; set; }
        [BindProperty] public Publicaciones? Filtro { get; set; }
        [BindProperty] public List<Publicaciones>? Lista { get; set; }
        [BindProperty] public List<Estados>? Estados { get; set; }
        [BindProperty] public List<Productos>? Productos { get; set; }
        [BindProperty] public List<Imagenes>? Imagenes { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Publicacion");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Titulo = Filtro!.Titulo ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "TITULO");
                task.Wait();
                Lista = task.Result;
                CargarCombox();
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                CargarCombox();
                Actual = new Publicaciones();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {

                Task<Publicaciones>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!);
                else
                    task = this.iPresentacion!.Modificar(Actual!);
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarCombox()
        {
            try
            {   // Cargar Fabricantes
                if (Estados == null || Estados!.Count <= 0)
                {
                    var Task = this.iEstadosPresentacion!.Listar();
                    Task.Wait();
                    Estados = Task.Result;
                }
                //Cargar Imagenes 
                // Cargar Categorías
                if (Productos == null || Productos!.Count <= 0)
                {
                    var Task = this.iProductosPresentacion!.Listar();
                    Task.Wait();
                    Productos = Task.Result;
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirProducto(int id)
        {
            try
            {
                CargarCombox();
                return Productos!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public string ConvertirEstado(int id)
        {
            try
            {
                CargarCombox();
                return Estados!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }


        //public string ConvertirActivo(bool valor)
        //{
        //    try
        //    {
        //        return valor ? "Activo" : "Inactivo";
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //        return "Falso";
        //    }
        //}
        //Imagenes = Enumerables.Ventanas.Editar;
        //        if (FormFile != null)
        //        {
        //            var memoryStream = new MemoryStream();
        //FormFile.CopyToAsync(memoryStream).Wait();
        //Imagenes!.Archivo = EncodingHelper.ToString(memoryStream.ToArray());
        //            memoryStream.Dispose();
        //        }
}
}