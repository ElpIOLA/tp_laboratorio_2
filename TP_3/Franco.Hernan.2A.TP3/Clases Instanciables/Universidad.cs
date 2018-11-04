using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributo
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i <= this.jornada.Count)
                {
                    return this.jornada[i];
                }   
                else { throw new Exception(); }   
            }
            set { this.jornada[i] = value; }
        }
        #endregion

        #region Constructor
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Este metodo de clase se encarga de cargar todos los datos de la universidad.
        /// </summary>
        /// <param name="uni">Objeto de tipo Universidad.</param>
        /// <returns>Retorna un string con toda su informacion.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Este metodo se encarga de guardar los datos de la universidad en un archivo xml.
        /// </summary>
        /// <param name="u">Objeto de tipo Universidad.</param>
        /// <returns>Retorna true si se guarda sino false.</returns>
        public static bool Guardar(Universidad u)
        {
            Xml<Universidad> x = new Xml<Universidad>();

            return x.Guardar((AppDomain.CurrentDomain.BaseDirectory) + @"\Universidad.Xml", u);
        }

        /// <summary>
        /// Este metodo se encarga de leer los datos del archivo.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad u = new Universidad();

            Xml<Universidad> x = new Xml<Universidad>();
            x.Leer((AppDomain.CurrentDomain.BaseDirectory) + @"\Universidad.Xml", out u);

            return u;
        }
        #endregion

        #region SobreCargas
        /// <summary>
        /// ToStriing muestra todos los datos de la Universidad.
        /// </summary>
        /// <returns>Retorna el metodo MostrarDatos con toda su informacion.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Una universidad es igual a un Alumno si este esta inscripto en la Universidad.
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Retorna true si el Alumno esta en la Universidad, sino retorna false.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool ret = false;
            foreach(Alumno item in g.alumnos)
            {
                if((Universitario)item == (Universitario)a)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Metodo que verifica que una Universidad sea distinta a un Alumno.
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="i">Objeto de tipo Alumno</param>
        /// <returns>Retorna false si son distintos sino retorna true.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una Universidad es igual a un Profesor si este pertenece a la Universidad.
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad.</param>
        /// <param name="i">Objeto de tipo Profesor.</param>
        /// <returns>Retorna true si el Profesor pertenece a la Universidad, sino retorna false.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ret = false;
            foreach(Profesor item in g.profesores)
            {
                if((Universitario)item == (Universitario)i)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Metodo que verifica que una Universidad sea distinta a un Profesor.
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="i">Objeto de tipo Profesor</param>
        /// <returns>Retorna false si son distintos sino retorna true.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="clase">Enumerado de tipo EClases</param>
        /// <returns>Retorna un objeto de tipo profesor.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor ret = new Profesor();
            int i, cantProfesor = g.profesores.Count;
            bool exiteProfesor = false;

            for(i = 0; i < cantProfesor; i++)
            {
                if(g.profesores[i] == clase)
                {
                    ret = g.profesores[i];
                    exiteProfesor = true;
                    break;
                }
            }
            if (exiteProfesor == false)
            {
                throw new SinProfesorException();
            }

            return ret;
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad.</param>
        /// <param name="clase">Enumerado de tipo EClases.</param>
        /// <returns>Objeto de tipo Profesor.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor ret = new Profesor();
            int i, cantProfesor = g.profesores.Count;
            for (i = 0; i < cantProfesor; i++)
            {
                if (g.profesores[i] != clase)
                {
                    ret = g.profesores[i];
                    break;
                }
            }
            
            return ret;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="clase">Objeto de tipo EClases</param>
        /// <returns>Retorna un objeto de tipo Universidad</returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    jornada += item;
                }

            }

            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega un alumno a la Universidad si este no esta en ella.
        /// </summary>
        /// <param name="u">Objeto de tipo Universidad</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Objeto de tipo Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(!(u == a))
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la Universidad si este no esta en ella.
        /// </summary>
        /// <param name="u">Objeto de tipo Universidad</param>
        /// <param name="a">Objeto de tipo Profesor</param>
        /// <returns>Objeto de tipo Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(u == i))
            {
                u.profesores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }
            return u;
        }
        #endregion

        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
