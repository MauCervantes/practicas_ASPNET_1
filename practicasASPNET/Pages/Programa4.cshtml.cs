using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace practicasASPNET.Pages
{
    public class Programa4Model : PageModel
    {

        public string res = "";
        public string or = "";
        public int prom = 0;
        public int sum = 0;
        public int media = 0;
        public string moda = "";

        public int[] arr = new int[20];

        public void OnGet(){
        }

        public void OnPost() {
            var arrOrd = new int[20];

            var ran = new Random();
            int num;

            for (int i = 0; i < arr.Length; i++) {
                num = ran.Next(1, 100);
                arr[i] = num;
                res = res + num + ", ";
            }
            suma(arr);
            promedio(sum);

            arrOrd = arr;
            var temp = 0;
            for (int i = 0;i < arrOrd.Length;i++) { 
                for (int j = i + 1; j < arrOrd.Length; j++){
                    if (arrOrd[i] > arrOrd[j]){
                        temp = arrOrd[i];
                        arrOrd[i] = arrOrd[j];
                        arrOrd[j] = temp;
                    }
                }
            }

            for (int i = 0; i < arrOrd.Length; i++)
                or = or + arrOrd[i] + ", ";
            
            media = (arrOrd[9] + arrOrd[10])/2;
            modaCalc();

        }

        public void suma(int[] arr){
            for(int i = 0; i < arr.Length; i++){
                sum += arr[i];
            }
        }
        public void promedio(int sum){
            prom = sum / 20;
        }

        public void modaCalc() {
            //Se utilizo la ayuda de como utilizar Diccionarios en C
            var modas = new Dictionary<int, int>();

            //Guarda dentro de un diccionario los datos y las veces que se repite.
            //No duplica numeros. 
            foreach (var numeros in arr){
                if (modas.ContainsKey(numeros)){
                    modas[numeros]++;
                }else{
                    modas[numeros] = 1;
                }
            }

            //Guarda los valores máximos que se hayan guardado
            //En si, los "contadores con más repeticiones"
            var maximos = modas.Values.Max();

            //Ahora sacamos los valores (llaves) de los contadores más encontrados.
            //Recorre el diccionario y en donde encuentra los valores maximos los va guardando 
            //en un arreglo :) utilizando la funcion where
            var modasFinal = modas.Where(x => x.Value == maximos).Select(x => x.Key);

            //Guardamos las modas encontradas dentro del resultado de Moda.
            foreach (var n in modasFinal){
                moda += n + ", "; 
            }
        }
    }
}
