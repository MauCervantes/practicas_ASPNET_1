using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Security.Cryptography.X509Certificates;

namespace practicasASPNET.Pages
{
    public class Programa2Model : PageModel
    {

        public char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 
                                 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        [BindProperty]
        public string entrada { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";
        [BindProperty] 
        public string metodo { get; set; } = "";

        public string salida = "La salida es: ";
        public int tam = 0;
        public int cont = 0;
        public int cont2;
        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            char[] letrasEntrada = entrada.ToUpper().ToCharArray();
            int num = Convert.ToInt32(n);
            tam = entrada.Length;
            int dif;
            
            do{
                cont2 = 0;
                while (cont2 < letras.Length) {
                    if (letrasEntrada[cont].Equals(letras[cont2])) {
                        dif = num;
                        if (metodo.Equals("Codificar entrada"))
                            codi(num, dif);
                        else if (metodo.Equals("Decodificar entrada"))
                            deco(num, dif);
                        break;
                    }
                    else if (letrasEntrada[cont] == Convert.ToChar(" "))
                        salida += letrasEntrada[cont];
                    cont2++;
                }
                cont++;
            } while (cont < tam);

            ModelState.Clear();
        }

        //Metodo, arreglo hacia dereha (+)
        public void codi(int num, int dif){
            if ((cont2 + num) >= (letras.Length)){
                dif = num + cont2 - letras.Length;
                cont2 = 0;
            }
            salida += letras[cont2 + dif];
        }

        //Metodo, arreglo hacia izquierda (-)
        public void deco(int num, int dif){
            if ((cont2 - num) < 0){
                dif = num - cont2;
                cont2 = 26;
            }
            salida += letras[cont2 - dif];
        }
    }
}
