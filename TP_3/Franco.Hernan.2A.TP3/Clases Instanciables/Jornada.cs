using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado que inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia que inicializa los atributos clase y isntructor.
        /// </summary>
        /// <param name="clases">Variable de tipo EClases</param>
        /// <param name="instructor">Objeto de tipo Profesor</param>
        public Jornada(Universidad.EClases clases, Profesor instructor) : this()
        {
            this.clase = clases;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de Jornada
        /// </summary>
        /// <param name="jornada">Objeto de tipo Jornada</param>
        /// <returns>Retorna true si guardo sin errores, sino false.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            return text.Guardar((AppDomain.CurrentDomain.BaseDirectory) + @"\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee los datos del archivo
        /// </summary>
        /// <returns>Retorna los datos leidos.</returns>
        public static string Leer()
        {
            string ret = "";
            Texto text = new Texto();
            text.Leer((AppDomain.CurrentDomain.BaseDirectory) + @"\Jornada.txt", out ret);

            return ret;
        }
        #endregion

        #region SobreCargas
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Retorna true si el Alumno esta en Jornada, sino false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ret = false;
            foreach(Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Metodo que verifica que una Jornada sea distinta a un Alumno.
        /// </summary>
        /// <param name="j">bjeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Retorna false si son distintos, sino true.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Retorna un objeto de tipo Jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(!(j == a))
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }

        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns>Retorna un string con todos los datos.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendFormat("Clase de {0} por {1}", this.clase,this.instructor);
            sb.AppendLine(this.instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
