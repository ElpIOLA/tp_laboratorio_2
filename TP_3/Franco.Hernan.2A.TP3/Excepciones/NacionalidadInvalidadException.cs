using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidadException : Exception
    {
        public NacionalidadInvalidadException() : base()
        { }

        public NacionalidadInvalidadException(string message) : base(message)
        { }
    }
}
