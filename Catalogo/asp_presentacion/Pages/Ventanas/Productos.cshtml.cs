using lib_entidades;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TextTemplating;

namespace asp_presentacion.Pages.Ventanas
{
    public class ProductosModel : PageModel
    {
        private IProductosPresentacion? iPresentacion = null;

        public ProductosModel(IProductosPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Productos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Productos? Actual { get; set; }
        [BindProperty] public Productos? Filtro { get; set; }
        [BindProperty] public List<Productos>? Lista { get; set; }
        [BindProperty] public List<Categorias>? Categorias { get; set; }
        [BindProperty] public List<Fabricantes>? Fabricantes { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                Filtro!.Codigo = Filtro!.Codigo ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "CODIGO");
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
                Actual = new Productos()
                {
                    Precio = 0,
                    Costo = 0,
                    Cantidad = 0,
                    FechaCreacion = DateTime.Now,
                };
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
                    Actual!.Imagen = EncodingHelper.ToString(memoryStream.ToArray());
                    memoryStream.Dispose();
                }

                Task<Productos>? task = null;
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
            {
                if (!(Categorias == null || Categorias!.Count <= 0))
                    return;
                Categorias = new List<Categorias>()
                {
                    new Categorias() { Id = 0, Categoria = "Electrónica" },
                    new Categorias() { Id = 1, Categoria = "Ropa" },
                    new Categorias() { Id = 2, Categoria = "Alimentos" },
                };

                Fabricantes = new List<Fabricantes>()
                {
                    new Fabricantes() { Id = 0, Nombre = "Fabricante A", Contacto = "contacto@fabricanteA.com" },
                    new Fabricantes() { Id = 1, Nombre = "Fabricante B", Contacto = "contacto@fabricanteB.com" },
                };
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public string ConvertirCategoria(int id)
        {
            try
            {
                CargarCombox();
                return Categorias!.FirstOrDefault(x => x.Id == id)!.Categoria!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public string ConvertirFabricante(int id)
        {
            try
            {
                CargarCombox();
                return Fabricantes!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }
    }
}
