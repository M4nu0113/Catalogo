using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Cuenta
{
    public class LoginModel : PageModel
    {
        public string? ErrorMessage { get; set; } 

        public void OnGet()
        {
        }
    }
}
