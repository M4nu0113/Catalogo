using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                //var variable_session = HttpContext.Session.GetString("usuario");
                //if (String.IsNullOrEmpty(variable_session))
                //    HttpContext.Session.SetString("usuario", "Pruebas");
                ViewData["Logeado"] = true;
            }
            catch (Exception ex)
            {
                ViewData["Logeado"] = false;
            }
        }
    }
}
