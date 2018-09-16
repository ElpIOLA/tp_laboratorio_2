using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Metodo que opera dos valores de tipo Numero segun la operacion aritmetica seleccionada.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = double.MinValue;
            if(!object.Equals(num1,null) && !object.Equals(num2, null))
            {
                switch (char.Parse(Calculadora.ValidarOperador(operador)))
                {
                    case '+':
                        retorno = num1 + num2;
                        break;
                    case '-':
                        retorno = num1 - num2;
                        break;
                    case '*':
                        retorno = num1 * num2;
                        break;
                    case '/':
                        retorno = num1 / num2;
                        break;
                }
            }
            return retorno;
         
        }

        /// <summary>
        /// Metodo que valida si el operador es de tipo char y que retorna dicho valor.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "";

            if(char.TryParse(operador,out char aux))
            {
                if (aux == '+' || aux == '-' || aux == '/' || aux == '*')
                {
                    retorno = aux.ToString();
                }
                else
                {
                    retorno = "+";
                }
            }
            else
            {
                Console.Write("\n\tError! operador no valido!");
                Console.ReadKey();
            }
            return retorno;
        }
        #endregion
    }
}
