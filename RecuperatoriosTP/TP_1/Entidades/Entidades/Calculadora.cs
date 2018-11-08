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
        /// Valida que el operador recibido sea +,-,*,/ y retornarlo, caso contrario retorna +
        /// </summary>
        /// <param name="operador">operador ingresado</param>
        /// <returns>Operador en caso favorable, sino retorna +</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }

        /// <summary>
        /// valida y realiza la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador">Operador ingresado</param>
        /// <returns>Operador que se utilizara</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }
        #endregion
    }
}
