using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo que guarda valores de tipo string en un archivo de texto.
        /// </summary>
        /// <param name="path">Variable de tipo string.</param>
        /// <param name="datos">Variable de tipo string.</param>
        /// <returns>Retorna true si el archivo se guarda con exito.</returns>
        public bool Guardar(string path, string datos)
        {
            bool ret = false;

            try
            {
                using (StreamWriter archivo = new StreamWriter(path, false))
                {
                    archivo.WriteLine(datos);
                }
                ret = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return ret;
        }

        /// <summary>
        /// Metodo que lee valores de un archivo y los guarda en una variable string.
        /// </summary>
        /// <param name="path">Vaiable de tipo string</param>
        /// <param name="datos">Variable de tipo string</param>
        /// <returns>Retorna true si el archivo es leido con exito.</returns>
        public bool Leer(string path, out string datos)
        {
            bool retorno = false;
            datos = "";
            try
            {
                using (StreamReader archivo = new StreamReader(path))
                {
                    datos = archivo.ReadToEnd();
                }
                retorno = true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
