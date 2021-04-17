using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        //Campos 
        private double numero;

        //Propiedades
        public string SetNumero
        {
            set { numero = Numero.ValidarNumero(value); }
        }

        //Metodos
        #region constructores
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero) //: this()
        {
            this.numero = numero;
        }
        public Numero(string strNumero) //: this()
        {
            this.SetNumero = strNumero;
        }
        #endregion

        private static double ValidarNumero(string strNumero)
        {
            double ret = 0;
            double n;
            bool isNumeric = double.TryParse(strNumero, out n);
            if (isNumeric == true)
            {
                ret = n;
            }
            return ret;
        }

        #region conversiones binarias
        private static bool EsBinario(string binario)
        {
            bool ret = true;
            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                {
                    ret = false;
                }
            }
            return ret;
        }

        public static string BinarioDecimal(string binario)
        {
            //Numero auxNum = new Numero();
            string ret;
            double retNum = 0;

            if (Numero.EsBinario(binario) == true)
            {
                string cadenaInvertida = "";
                for (int i = binario.Length - 1; i >= 0; i--) 
                {
                    cadenaInvertida += binario[i];
                }

                for (int i = 0; i < cadenaInvertida.Length; i++)
                {
                    if (cadenaInvertida[i] == '1')
                    {
                        retNum += (double)Math.Pow(2, i);
                    }
                }
                ret = retNum.ToString();
            }
            else
            {
                ret = "Valor inválido";
            }

            return ret;
        }

        public static string DecimalBinario(string numero)
        {
            string resto = ""; 
            string cadenaInvertida = ""; //como son string se va concatenando los numeros en los for
            int n;

            if (Numero.EsBinario(numero) == false)
            {
                if (int.TryParse(numero, out n) == true)
                {
                    for (; n >= 2;) //se repite siempre que el cociente sea >= 2
                    {
                        resto += n % 2; //obtenemos el resto de la division 
                        n = n / 2;    //obtenemos cociente
                    }
                    resto += n;

                    for (int i = resto.Length - 1; i >= 0; i--)
                    {
                        cadenaInvertida += resto[i];
                    }
                }
            }
            else
            {
                cadenaInvertida = "Valor inválido";
            }

            return cadenaInvertida;
        }
        public static string DecimalBinario(double numero)
        {
            return Numero.DecimalBinario(numero.ToString());
        }

        #endregion

        #region operator overloads
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero; 
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }
        #endregion



    }
}
