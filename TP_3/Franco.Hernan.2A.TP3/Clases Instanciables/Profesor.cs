using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de clase que inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor de instancia que inicializa los atributos por default.
        /// </summary>
        public Profesor() : this(0,"vacio","vacio","vacio", ENacionalidad.Argentino)
        {}

        /// <summary>
        /// Constructor de instancia que inicializa los atributos.
        /// </summary>
        /// <param name="id">Variable de tipo int.</param>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionalidad.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns>Retorna un string con las clases del Profesor.</returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "";
            foreach(EClases item in this.clasesDelDia)
            {
                retorno += "\nCLASES DEL DIA: " + item;
            }
            return retorno;
        }

        /// <summary>
        /// El método MostrarDatos con todos los datos del profesor.
        /// </summary>
        /// <returns>Retorna un string con todos los datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Este metodo calculas dos clases al azar.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue(((EClases)Profesor.random.Next(0 ,4)));
            this.clasesDelDia.Enqueue(((EClases)Profesor.random.Next(0, 4)));
        }
        #endregion

        #region SobreCargas
        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns>Retorna el metodo MostrarDatos.</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">Objeto de tipo Profesor</param>
        /// <param name="clase">Elemento de tipo EClases</param>
        /// <returns>Retorna true si el Profesor da esa clase, sino retorna false.</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool ret = false;
            foreach(EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
