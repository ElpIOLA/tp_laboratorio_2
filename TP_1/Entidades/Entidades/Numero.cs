using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que llama a un metodo para validar el valor recibido y luego retornarlo.
        /// </summary>
        private string SetNumero
        {
            set
            {
                double aux;
                aux = ValidarNumero(value);
                numero = aux;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor que inicializa el valor en 0.
        /// </summary>
        public Numero() : this(0)
        {
            
        }

        /// <summary>
        /// Constructor que recibe un string y llama a la propiedad para ingresar el valor validado.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Constructor que recibe un double y lo guarda en el atributo.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que valida que el valor recibido sea numero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public double ValidarNumero(string strNumero)
        {
            double retorno;
            if(double.TryParse(strNumero,out double aux))
            {
                retorno = aux;
            }
            else
            {
                retorno = 0;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que convierte un numero binario (string) en decimal (double).
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static double BinarioDecimal(string binario)
        {
            int[] arrayEnteros = new int[binario.Length];
            double numero = 0;

            if(binario != "1" && binario != "0")
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    arrayEnteros[i] = (int)char.GetNumericValue(binario[i]);
                }
                for (int j = 0; j < binario.Length; j++)
                {
                    numero += (arrayEnteros[j] * Math.Pow(2, binario.Length - j - 1));
                }
            }
            else
            {
                Console.Write("\n\tValor invalido\n");
                Console.ReadKey();
            }
            return numero;
        }


        /// <summary>
        /// Metodo que recibe un numero decimal (string) y lo transforma en un numero binario (string).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string binario = "";
            int entero = int.Parse(numero);
            while (entero > 0)
            {
                binario = (entero % 2).ToString() + binario;
                entero = entero / 2;
            }
            if(entero < 0)
            {
                binario = "\n\tValor invalido\n";
            }
            return binario;
        }

        /// <summary>
        /// Metodo que transforma un numero decimal (double) en un numero binario (string).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";
            int entero = (int)numero;
            while (entero > 0)
            {
                binario = (entero % 2).ToString() + binario;
                entero = entero / 2;
            }
            if (entero < 0)
            {
                binario = "\n\tValor invalido\n";
            }
            return binario;
        }

        /// <summary>
        /// Metodo que suma dos valores de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(!object.Equals(n1,null) && !object.Equals(n2, null))
            {
                retorno = n1.numero + n2.numero;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que resta dos valores de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                retorno = n1.numero - n2.numero;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que multiplica dos valores de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                retorno = n1.numero * n2.numero;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que divide dos valores de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0)
            {
                if (!object.Equals(n1, null) && !object.Equals(n2, null))
                {
                    retorno = n1.numero / n2.numero;
                }
            }
            else
            {
                Console.Write("\n\tNo es posible dividir por cero.\n");
                Console.ReadKey();
            }
            return retorno;
        }
        #endregion
    }
}
