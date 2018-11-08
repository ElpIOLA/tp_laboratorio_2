using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributo
        private double numero;
        #endregion

        #region Propiedad
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el valor recibido sea numerico.
        /// </summary>
        /// <param name="strNumero">Valor recibido</param>
        /// <returns>Si strNumero es numerico, lo retorna en formato double, sino retorna 0</returns>
        private static double ValidarNumero(string strNumero)
        {
            double auxNumero;
            if (double.TryParse(strNumero, out auxNumero))
            {
                return auxNumero;
            }

            return 0;
        }

        /// <summary>
        /// Convierte un binario a decimal
        /// </summary>
        /// <param name="binario">string recibido</param>
        /// <returns>Retorna un string decimal en caso favorable, sino retorna "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {

            string retorno = "Valor Invalido";
            char[] binary = binario.ToCharArray();
            int contEntero = 0;
            int contFlotante = -1;
            double potencia;
            double num1 = 0.0;
            double num2;
            double num3;

            int i;
            int j;
            for (i = 0; i < binario.Length && binario != "Valor invalido"; i++)
            {

                if (i == 0)
                {
                    retorno = "";
                }

                if (binary[i] == ',')
                {

                    contFlotante = binario.Length - (contEntero + 1);
                    for (j = 1; j <= contFlotante; j++)
                    {
                        if (binary[i + j] == '1')
                        {
                            potencia = Math.Pow(2, -j);
                            num1 += potencia;

                        }
                    }
                    break;
                }

                else
                {
                    contEntero++;
                    retorno += binary[i];
                }

            }

            if (contFlotante == -1 && binario.Length != 0 && binario != "Valor invalido")
            {

                num2 = Convert.ToInt64(retorno, 2);
                retorno = num2.ToString();

            }

            else if (contFlotante != -1 && binario != "Valor invalido" && binario.Length != 0)
            {
                num3 = Convert.ToInt32(retorno, 2);
                num3 += num1;
                retorno = num3.ToString();
            }

            for (i = 0; i < binario.Length && binario != "Valor invalido"; i++)
            {
                if (binary[i] != '1' && binary[i] != '0' && binary[i] != ',')
                {
                    retorno = "Valor invalido";
                    binario = "";
                    break;
                }
            }

            return retorno;

        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">valor recibido</param>
        /// <returns>Retorna un string binario </returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            int entero = (int)numero;
            double dec;
            double decimalProd;


            dec = numero - entero;
            decimalProd = dec;
            retorno = Convert.ToString(entero, 2);

            if (dec != 0)
            {
                retorno += ',';
                do
                {
                    decimalProd = decimalProd * 2;
                    if (decimalProd >= 1)
                    {
                        decimalProd -= 1;
                        retorno += 1;
                        if (decimalProd == 0)
                        {
                            continue;
                        }
                    }
                    else if (decimalProd < 1)
                    {
                        retorno += 0;
                    }
                } while (decimalProd != 0);
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">valor recibido</param>
        /// <returns>Retorna el nro en binario si es posible, sino retorna "valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            double nroDecimal;
            string retorno = "Valor invalido";
            if (double.TryParse(numero, out nroDecimal))
            {
                return DecimalBinario(nroDecimal);
            }
            return retorno;
        }
        #endregion

        #region SobreCargas
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;
            if(n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }
        #endregion
    }
}
