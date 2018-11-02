using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        private int legajo;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa sus atributos por default.
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor que inicializa legajo, nombre(base), apellido(base), dni(base) y nacionalidad(base).
        /// </summary>
        /// <param name="legajo">Variable de tipo int.</param>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionaldad.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base (nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region SobreCarga
        /// <summary>
        /// Esta sobrecarga retorna true si dos Universitario tienen en comun el tipo, el dni o legajo.
        /// </summary>
        /// <param name="pg1">Objeto de tipo Universitario.</param>
        /// <param name="pg2">Objeto de tipo Universitario.</param>
        /// <returns>Retorna true si son iguales sino false.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2) //Dos Universitario serán iguales si y sólo si 
        {                                                                       //son del mismo Tipo y su Legajo o DNI son iguales.
            bool ret = false;
            if(pg1.Nacionalidad == pg2.Nacionalidad && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Esta sobrecarga retorna false si dos objetos de tipo Universitario no son iguales.
        /// </summary>
        /// <param name="pg1">Objeto de tipo Universitario.</param>
        /// <param name="pg2">Objeto de tipo Universitario.</param>
        /// <returns>Retorna false.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        
        /// <summary>
        /// Si el objeto es de tipo Universitario retorna true.
        /// </summary>
        /// <param name="obj">Objeto</param>
        /// <returns>Retorna true si el objeto es Universitario sino retorna false.</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj is Universitario)
            {
                if(this == (Universitario)obj)
                {
                    ret = true;
                }
            }
            return ret;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los datos del Universitario.
        /// </summary>
        /// <returns>Retorna un string todos los datos.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("\nLegajo: {0}", this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto.
        /// </summary>
        /// <returns>Retorna un string.</returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
