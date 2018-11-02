using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributo
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa sus atributos por default.
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor que inicializa el id, nombre, apellido, dni, nacionalidad y la clase que toma.
        /// </summary>
        /// <param name="id">Variable de tipo int.</param>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionaldad.</param>
        /// <param name="claseQueToma">Variable de tipo EClases.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionaldad nacionalidad, EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que inicializa el id, nombre, apellido, dni, nacionalidad, la clase que toma y estado de cuenta.
        /// </summary>
        /// <param name="id">Variable de tipo int.</param>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionaldad.</param>
        /// <param name="ClaseQueToma">Variable de tipo EClases.</param>
        /// <param name="estadoCuenta">Variable de tipo EEstadoCuenta.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionaldad nacionalidad, EClases ClaseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, ClaseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra el tipo de EClases que tiene el Alumno.
        /// </summary>
        /// <returns>Retorna EClases del Alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this.claseQueToma;
        }

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns>Retorna un string con todos los datos.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat("\nClase que toma: {0}", this.ParticiparEnClase());
            sb.AppendFormat("\nEstado de cuenta: {0}", this.estadoCuenta);
            return sb.ToString();
        }
        #endregion

        #region SobreCargas
        /// <summary>
        /// ToString hará públicos los datos del Alumno.
        /// </summary>
        /// <returns>Retorna el metodo MostrarDatos.</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <param name="clase">Enumerado de tipo EEStadoCuenta</param>
        /// <returns>Retorna true si son iguales, sino false.</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool ret = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase / deja de lado el estadoCuenta
        /// </summary>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <param name="clase">Enumerado de tipo EEStadoCuenta</param>
        /// <returns>Retorna true si son distintos, sino retorna false.</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool ret = false;
            if(a.claseQueToma != clase)
            {
                ret = true;
            }
            return ret;
        }
        #endregion
    }
}
