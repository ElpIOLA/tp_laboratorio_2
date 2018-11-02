using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
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
            set { this.jornada.Add(value); }
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

        #region SobreCargas
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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool profesorQueDeClase = false;
            int cantProfesores = g.profesores.Count, i;

            for (i = 0; i < cantProfesores; i++)
            {
                if(g.profesores[i] == clase)
                {
                    profesorQueDeClase = true;
                    break;
                }
            }

            if(profesorQueDeClase)
            {
                Jornada jornada = new Jornada(clase, g.profesores[i]);
                int cantAlumnos = g.alumnos.Count;

                for(int j = 0; j < cantAlumnos; j++)
                {
                    if(g.alumnos[j] == clase)
                    {
                        jornada += g.alumnos[j];
                    }
                }
            }

            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(!(u == a))
            {
                u.alumnos.Add(a);
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(u == i))
            {
                u.profesores.Add(i);
            }
            return u;
        }
        #endregion
    }
}
