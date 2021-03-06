﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Genera y guarda un archivo xml.
        /// </summary>
        /// <param name="path">Variable de tipo String</param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si lo guarda, sino lanza excepcion.</returns>
        public bool Guardar(string path, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter archivo = new XmlTextWriter(path, Encoding.UTF8);
                serializer.Serialize(archivo, datos);
                archivo.Close();
                retorno = true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;

        }

        /// <summary>
        /// Lee un archivo de tipo Xml.
        /// </summary>
        /// <param name="path">Variable de tipo String</param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si es leido con exito, sino lanza excepcion.</returns>
        public bool Leer(string path, out T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader archivo = new XmlTextReader(path);
                datos = (T)serializer.Deserialize(archivo);
                archivo.Close();

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
