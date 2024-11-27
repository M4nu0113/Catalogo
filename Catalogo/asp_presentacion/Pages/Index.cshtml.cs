using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using lib_presentaciones.Interfaces;
using lib_entidades.Modelos;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        private IUsuariosPresentacion? iUsuariosPresentacion = null;

        public IndexModel(IUsuariosPresentacion iUsuariosPresentacion)
        {
            try
            {
                this.iUsuariosPresentacion = iUsuariosPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contraseña { get; set; }
        

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Nombre = string.Empty;
                Correo = string.Empty;
                Contraseña = string.Empty;
                
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                // Validar que los campos no estén vacíos antes de consultar la base de datos.
                if (string.IsNullOrEmpty(Nombre) ||
                    string.IsNullOrEmpty(Correo) ||
                    string.IsNullOrEmpty(Contraseña))
                {
                    ViewData["Error"] = "Todos los campos son obligatorios.";
                    OnPostBtClean();
                    return;
                }

                if (ValidarUsuario(Nombre, Correo, Contraseña))
                {
                    ViewData["Logged"] = true;
                    HttpContext.Session.SetString("Usuario", Correo!);
                    EstaLogueado = true; 
                }
                else
                {
                    ViewData["Error"] = "Credenciales inválidas. Verifique su información.";
                    OnPostBtClean();
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData);
            }
        }

        // Método para validar el usuario en la base de datos.
        private bool ValidarUsuario(string nombre, string correo, string contraseña)
        {
            try
            {
                var usuarioBusqueda = new Usuarios
                {
                    Nombre = nombre,
                    Correo = correo,
                    Contraseña = contraseña
                };
                var task = iUsuariosPresentacion!.Buscar(usuarioBusqueda, "Validacion");
                task.Wait();
                var usuario = task.Result.FirstOrDefault();

                if (usuario == null)
                {
                    return false;
                }

                return true;
                
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData);
                return false;
            }
        }


        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}