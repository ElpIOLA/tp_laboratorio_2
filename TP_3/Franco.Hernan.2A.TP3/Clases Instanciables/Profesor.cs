using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
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
        public Profesor()
        {}

        /// <summary>
        /// Constructor de instancia que inicializa los atributos.
        /// </summary>
        /// <param name="id">Variable de tipo int.</param>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionalidad.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:\n");

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
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
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0 ,4)));
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
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
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool ret = false;
            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Metodo que verifica si un Profesor es distinto a una Universidad.
        /// </summary>
        /// <param name="i">Objeto de tipo Profesor</param>
        /// <param name="clase">Enumerados de tipo EClases</param>
        /// <returns>Retorna false si son distintos, sino true.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
