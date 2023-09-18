using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace practicasASPNET.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "El peso es requerido")]
        public string Peso { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "La altura es requerida")]
        public string Altura { get; set; } = "";

        public double imc = 0;
        public string error = "";

        public void OnGet()
        {
        }

        public void OnPost() {

            if (!ModelState.IsValid)
            {
                error = "La validación de datos falló";
                return;
            }

            double pe = Convert.ToDouble(Peso);
            double al = Convert.ToDouble(Altura);

            imc = pe / (al * al);

            ModelState.Clear();
        }
    }
}
