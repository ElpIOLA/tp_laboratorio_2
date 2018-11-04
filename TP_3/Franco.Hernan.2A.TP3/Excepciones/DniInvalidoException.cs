using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Atributo
        private string mensajeBase;
        #endregion

        #region Constructores
        public DniInvalidoException() : base()
        { }

        public DniInvalidoException(Exception e) : base("El dni presenta el siguiente error: ",e)
        { }

        public DniInvalidoException(string message) : base(message)
        { }

        public DniInvalidoException(string message, Exception e) : base(message,e)
        {
            this.mensajeBase = message;
        }
        #endregion
    }
}
