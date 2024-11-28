using lib_utilidades;
using lib_presentaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TextTemplating;
using lib_entidades.Modelos;

namespace asp_presentacion.Pages.Ventanas
{
    public class ImagenesModel : PageModel
    {
        private IImagenesPresentacion? iPresentacion = null;

        public ImagenesModel(IImagenesPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Imagenes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Imagenes? Actual { get; set; }
        [BindProperty] public Imagenes? Filtro { get; set; }
        [BindProperty] public List<Imagenes>? Lista { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {

                Filtro!.Informacion = Filtro!.Informacion ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "INFORMACION");
                task.Wait();
                Lista = task.Result;
                Console.WriteLine("Datos recuperados: " + Lista.Count); 
                if (Lista.Count > 0) { 
                    foreach (var item in Lista) 
                    { 
                        Console.WriteLine("Información: " + item.Informacion + ", Archivo: " + item.Archivo); 
                    } 
                } 
                else 
                { 
                    Console.WriteLine("No se recuperaron datos."); 
                }
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
                Actual = new Imagenes();
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
                Accion = Enumerables.Ventanas.Editar;
                if (FormFile != null)
                {
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    Actual!.Archivo = Convert.ToBase64String(memoryStream.ToArray());
                    memoryStream.Dispose();
                }

                Task<Imagenes>? task = null;
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

    }
}
