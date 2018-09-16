using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            string numero = "";
            numero = Numero.DecimalBinario(-2);
            Console.WriteLine(numero);
            Console.ReadLine();
        }
    }
}
