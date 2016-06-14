using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class NumbersNotAllowedException : Exception
    {
        public NumbersNotAllowedException(string message)
            : base(message)
        {

        }
    }
}
