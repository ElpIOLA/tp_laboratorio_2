using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributo
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna y ingresa un dato de tipo string.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad que retorna y ingresa un dato de tipo string.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad que retorna y ingresa un dato de tipo Enum.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad que retorna y ingresa un dato de tipo int.
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad que ingresa un dato de tipo int.
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa todos sus atributos por default.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor que inicializa nombre, apellido y nacionalidad.
        /// </summary>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionaldad.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que inicializa nombre, apellido, dni y nacionalidad.
        /// </summary>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo int.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionaldad.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que inicializa nombre, apellido, dni(string) y nacionalidad.
        /// </summary>
        /// <param name="nombre">Variable de tipo string.</param>
        /// <param name="apellido">Variable de tipo string.</param>
        /// <param name="dni">Variable de tipo string.</param>
        /// <param name="nacionalidad">Variable de tipo ENacionaldad.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Este metodo se encarga de validar un entero (DNI) invocando a el otro metodo de validacion de DNI.
        /// </summary>
        /// <param name="nacionalidad">Variable de tipo ENacionalidad.</param>
        /// <param name="numero">Variable de tipo entera.</param>
        /// <returns>El DNI validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int numero)
        {
            return this.ValidarDni(nacionalidad, numero.ToString());
        }

        /// <summary>
        /// Este metodo se encarga de validar una variable string (DNI) y convertirla en entera y asignarla segun la longitud y nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Variable de tipo ENacionalidad</param>
        /// <param name="numero">Variable de tipo string.</param>
        /// <returns>Retorna el DNI validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string numero)
        {
            int retorno = -1;
            if (numero.Length <= 8 && Int32.TryParse(numero, out dni))
            {
                int dni = Int32.Parse(numero);
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dni > 0 && dni < 90000000)
                            retorno = dni;
                        else
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                        break;
                    case ENacionalidad.Extranjero:
                        if (dni >= 90000000 && dni <= 99999999)
                            retorno = dni;
                        else
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                        break;
                    default:
                        break;
                }
            }
            else
                throw new DniInvalidoException("La nacionalidad no se condice con el número de DNI.");

            return dni;
        }

        /// <summary>
        /// Valida la variable de tipo string recibida por parametro.
        /// </summary>
        /// <param name="palabra">Variable string a validar.</param>
        /// <returns>Un string con la variable validada.</returns>
        private string ValidarNombreApellido(string palabra)
        {
            bool validar = true;
            foreach (char item in palabra)
            {
                if (!(char.IsLetter(item)))
                {
                    validar = false;
                    break;
                }
            }

            if (validar == false)
            {
                throw new Exception("No se pudo cargar el string.");
            }

            return palabra;
        }
        #endregion

        #region SobreCarga
        /// <summary>
        /// Muestra todos los datos de Persona.
        /// </summary>
        /// <returns>Un string con todos los elementos de Persona.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nNombre completo: {0} {1}", this.Nombre, this.Apellido);
            sb.AppendFormat("\nNacionalidad: {0}", this.Nacionalidad);
            sb.AppendFormat("\nDNI: {0}", this.DNI);
            return sb.ToString();
        }
        #endregion

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
