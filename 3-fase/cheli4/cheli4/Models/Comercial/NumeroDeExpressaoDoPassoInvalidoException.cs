using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    public class NumeroDeExpressaoDoPassoInvalidoException : Exception
    {
        public NumeroDeExpressaoDoPassoInvalidoException()
        {
        }

        public NumeroDeExpressaoDoPassoInvalidoException(string msg) : base(msg)
        {
        }
    }
}
