using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace practicasASPNET.Pages
{
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public string a { get; set; } = "";
        
        [BindProperty]
        public string b { get; set; } = "";
        
        [BindProperty]
        public string x { get; set; } = "";
        
        [BindProperty]
        public string y { get; set; } = "";
        
        [BindProperty]
        public string n { get; set; } = "";

        public double res = 0;

        public void OnGet()
        {
        }

        public void OnPost() {
            //Transformamos a int los valores 
            int varA = Convert.ToInt32(a);
            int varB = Convert.ToInt32(b);
            int varX = Convert.ToInt32(x);
            int varY = Convert.ToInt32(y);
            int varN = Convert.ToInt32(n);

            //Variables auxiliares
            int fac = 0;
            int potA = 0;
            int potB = 0;

            //contador
            int k = 0;

            do{
                fac = fact(varN) / (fact(varN - k) * fact(k));
                potA = potencia((varA * varX),(varN - k));
                potB = potencia((varB * varY), (k));
                res += fac * potA * potB;
                k++;
            } while (k <= varN);

            ModelState.Clear();
        }

        //Metodo recursivo para el factorial
        public int fact(int num){
            if(num == 1 || num == 0){
                return 1;
            }else{
                return num * fact(num - 1);
            }
        }

        //Potencia de un numero
        public int potencia(int num, int pot){
            int po = 1;
            for(int i = 0; i < pot; i++){
                po = po * num;
            }
            return po;
        }
    }
}
